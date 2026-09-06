using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace F11SBCons;

public class ProcessOrderMessage
{
    private static readonly string[] RequiredFields = ["orderId", "customerId", "amount"];

    private readonly ILogger<ProcessOrderMessage> _logger;

    public ProcessOrderMessage(ILogger<ProcessOrderMessage> logger)
    {
        _logger = logger;
    }

    [Function(nameof(ProcessOrderMessage))]
    public async Task Run(
        [ServiceBusTrigger(
            "q1",
            Connection = "sbbiztalkmigrationmina_SERVICEBUS",
            AutoCompleteMessages = false)]
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions)
    {
        _logger.LogInformation("Processing message {MessageId}", message.MessageId);

        JsonDocument document;

        try
        {
            document = JsonDocument.Parse(message.Body.ToString());
        }
        catch (JsonException exception)
        {
            _logger.LogWarning(
                exception,
                "Message {MessageId} contains invalid JSON and will be dead-lettered",
                message.MessageId);

            await messageActions.DeadLetterMessageAsync(
                message,
                deadLetterReason: "InvalidJson",
                deadLetterErrorDescription: "The message body is not valid JSON.");

            return;
        }

        using (document)
        {
            if (document.RootElement.ValueKind != JsonValueKind.Object)
            {
                await DeadLetterAsync(
                    message,
                    messageActions,
                    "InvalidJsonStructure",
                    "The JSON root must be an object.");

                return;
            }

            var missingFields = FindMissingFields(document.RootElement);

            if (missingFields.Count > 0)
            {
                await DeadLetterAsync(
                    message,
                    messageActions,
                    "MissingRequiredField",
                    $"Missing required field(s): {string.Join(", ", missingFields)}.");

                return;
            }

            var testAction = GetTestAction(document.RootElement);

            switch (testAction)
            {
                case "complete":
                    await messageActions.CompleteMessageAsync(message);
                    _logger.LogInformation(
                        "Message {MessageId} completed successfully",
                        message.MessageId);
                    return;

                case "abandon":
                    _logger.LogInformation(
                        "Abandoning message {MessageId}. DeliveryCount: {DeliveryCount}",
                        message.MessageId,
                        message.DeliveryCount);

                    // The queue's current MaxDeliveryCount is 10, so repeated abandonment is bounded.
                    // Service Bus moves the message to the dead-letter queue after the limit.
                    await messageActions.AbandonMessageAsync(message);
                    return;

                case "defer":
                    _logger.LogInformation(
                        "Deferring message {MessageId}. SequenceNumber: {SequenceNumber}",
                        message.MessageId,
                        message.SequenceNumber);

                    // Deferred messages are not returned by normal receive operations.
                    // A later receiver needs this SequenceNumber to retrieve the message.
                    await messageActions.DeferMessageAsync(message);
                    return;

                default:
                    await DeadLetterAsync(
                        message,
                        messageActions,
                        "InvalidTestAction",
                        $"Unsupported testAction '{testAction}'. Use complete, abandon, or defer.");
                    return;
            }
        }
    }

    private static string GetTestAction(JsonElement order)
    {
        if (!order.TryGetProperty("testAction", out var value))
        {
            return "complete";
        }

        return value.ValueKind == JsonValueKind.String
            ? value.GetString()?.Trim().ToLowerInvariant() ?? string.Empty
            : string.Empty;
    }

    private static List<string> FindMissingFields(JsonElement order)
    {
        var missingFields = new List<string>();

        foreach (var field in RequiredFields)
        {
            if (!order.TryGetProperty(field, out var value) ||
                value.ValueKind is JsonValueKind.Null or JsonValueKind.Undefined)
            {
                missingFields.Add(field);
            }
        }

        return missingFields;
    }

    private async Task DeadLetterAsync(
        ServiceBusReceivedMessage message,
        ServiceBusMessageActions messageActions,
        string reason,
        string description)
    {
        _logger.LogWarning(
            "Message {MessageId} will be dead-lettered. Reason: {Reason}. Description: {Description}",
            message.MessageId,
            reason,
            description);

        await messageActions.DeadLetterMessageAsync(
            message,
            deadLetterReason: reason,
            deadLetterErrorDescription: description);
    }
}
