# Azure Integration Pattern Labs

## Purpose

This execution plan advances Azure integration learning while BizTalk Server installation is blocked by legitimate media availability. It does not replace the BizTalk track and does not claim that any BizTalk-to-Azure migration has been validated.

```text
Requirement -> Pattern -> Technology
            -> Deploy -> Configure -> Observe
            -> Change -> Fail -> Diagnose
            -> Compare -> Record migration lesson -> Clean up
```

Official guidance and Portal-based exercises are preferred. Application code is introduced only when the required behavior cannot be observed another way; any .NET Service Bus code must use `Azure.Messaging.ServiceBus` rather than the retiring legacy SDKs.

The consolidation principle is **minimum labs, maximum competency coverage**. Closely related queue behaviors should extend the same lab; a new lab is justified only when the integration pattern, topology, or Azure capability materially changes.

## Completion Standard

An exercise is complete only when all applicable evidence exists.

### Understand

- [ ] Explain the requirement and constraints.
- [ ] Identify the integration pattern and why it exists.
- [ ] Explain when the pattern should not be used.

### Implement and Observe

- [ ] Record the official Microsoft guide or sample selected.
- [ ] Deploy only the required resources.
- [ ] Run the scenario and inspect the resources and message flow.
- [ ] Change one meaningful configuration.
- [ ] Trigger a controlled failure or edge case.
- [ ] Observe, diagnose, and recover.

### Architect

- [ ] Compare at least one alternative implementation.
- [ ] Explain reliability, scalability, security, operations, and cost trade-offs.
- [ ] Justify the selected service from the requirement.

### Migration

- [ ] Answer: What did this experiment teach us about designing or executing a real BizTalk-to-Azure migration?

Azure observation and BizTalk migration validation are recorded separately. The migration item cannot be completed until relevant BizTalk behavior has also been observed or verified from an actual workload.

## Execution Sequence

### A1 — Queue Delivery and Settlement

**Question:** What happens to work when the destination processor is unavailable or does not complete processing?

The exercise began with one Service Bus queue and the Portal's Service Bus Explorer, then extended the same lab with a minimal Azure Function consumer to observe explicit settlement in code. No separate producer, VM, or competing-consumer implementation is required for A1.

**Patterns and behavior:** asynchronous point-to-point messaging, temporal decoupling, durable buffering, peek-lock settlement, and redelivery.

**Migration relevance:** determine when a BizTalk flow needs durable asynchronous handoff rather than a synchronous API or event notification.

**Official references:**

- [Create a Service Bus namespace and queue in the Azure portal](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-quickstart-portal)
- [Use Service Bus Explorer for data operations](https://learn.microsoft.com/azure/service-bus-messaging/explorer)
- [Prevent message loss and duplicate processing](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-message-loss-and-duplicates)

#### Verified environment

- Azure for Students subscription: active
- Region: Sweden Central
- Service Bus namespace: Basic tier, provisioning succeeded
- Queue: `q1`, 1 GB maximum size, 1-minute lock duration, maximum delivery count `10`
- Function App: `F11`, Flex Consumption, .NET 10 isolated, running
- Resource identifiers and directory details are intentionally omitted from this public document.

#### Verified work

- [x] Create the Service Bus namespace and queue.
- [x] Send multiple JSON order messages.
- [x] Inspect messages with Peek and Peek from start.
- [x] Confirm that Peek does not consume or settle a message.
- [x] Receive messages in PeekLock mode.
- [x] Complete a message and observe its removal from the active queue.
- [x] Dead-letter a selected message and inspect the result.
- [x] Confirm that Service Bus accepts a malformed JSON body without schema validation.
- [x] Verify the current maximum delivery count of `10`.
- [x] Explore dead-letter settings and behavior.
- [x] Abandon a locked message and observe redelivery.
- [ ] Explain the queue configuration trade-offs and complete the architecture review.
- [ ] Record the final A1 migration lesson.
- [ ] Delete temporary resources and verify cleanup.

#### Consumer extension — deployed and partially exercised

`ProcessOrderMessage` is deployed to the `F11` Flex Consumption Function App using the .NET 10 isolated worker model. Its Service Bus trigger reads from `q1`, references an Azure-side connection setting, and keeps `AutoCompleteMessages = false` so the consumer controls settlement explicitly.

The Release build and publish succeeded. The deployment package was verified to contain `.azurefunctions/` and `host.json` at its root and to exclude `local.settings.json`. An initial VS Code deployment failed because the source tree, rather than the publish output, was packaged; deploying the correctly packaged publish output through One Deploy succeeded.

- [x] Implement explicit Complete, Dead-letter, Abandon, and Defer paths.
- [x] Implement consumer validation for malformed JSON and missing required fields.
- [x] Build and publish the .NET 10 isolated project.
- [x] Deploy the correct publish artifact and discover ProcessOrderMessage in F11.
- [x] Inspect Function metadata, integration, and a successful invocation.
- [x] Observe a valid `testAction = "complete"` message completing successfully.
- [x] Observe malformed JSON being dead-lettered with reason `InvalidJson`.
- [x] Observe `testAction = "abandon"` making the message available for redelivery.
- [ ] Send and observe a `testAction = "defer"` message and record its sequence number.
- [ ] Retrieve the deferred message explicitly by sequence number.

The app setting `AzureWebJobs.ProcessOrderMessage.Disabled` has been used as the operational enable/disable control during deployment and controlled testing. The Service Bus connection value remains in Azure configuration and is not stored in source control.

### A2 — Small Workflow and Competing Consumers

Connect a small Logic Apps Consumption workflow to the queue, inspect run history, and then introduce a second receiver to observe competing-consumer behavior. Consumption is the initial lab choice, not a production migration conclusion; Logic Apps Standard must be evaluated later because Microsoft migration guidance emphasizes it for BizTalk migration scenarios.

**Official references:**

- [Connect to Service Bus from Azure Logic Apps workflows](https://learn.microsoft.com/azure/connectors/connectors-create-api-servicebus)
- [Create a Consumption workflow in the Azure portal](https://learn.microsoft.com/azure/logic-apps/quickstart-create-example-consumption-workflow)
- [Competing Consumers pattern](https://learn.microsoft.com/azure/architecture/patterns/competing-consumers)

### A3 — Publish/Subscribe and Content-Based Routing

Create one topic and two independent subscriptions, then add simple subscription filters. Compare one-message/one-receiver queue behavior with one-message/multiple-subscription delivery.

**Official references:**

- [Service Bus queues, topics, and subscriptions](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-queues-topics-subscriptions)
- [Topic filters and actions](https://learn.microsoft.com/azure/service-bus-messaging/topic-filters)
- [Publisher-Subscriber pattern](https://learn.microsoft.com/azure/architecture/patterns/publisher-subscriber)

### A4 — Contract Validation and Transformation

Extend the same observable flow with prepared valid and invalid payloads. Inspect content types, parse a defined contract, transform fields for a destination shape, and make invalid input fail visibly.

**Official reference:** [Handle content types in Azure Logic Apps](https://learn.microsoft.com/azure/logic-apps/logic-apps-content-type)

### A5 — Failure and Reprocessing

Exercise retry, timeout, delivery count, TTL, dead-lettering, inspection, replay, and protection against duplicate business effects. Distinguish resend from moving or deleting the original dead-lettered message.

**Official references:**

- [Prevent message loss and duplicate processing](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-message-loss-and-duplicates)
- [Handle errors and exceptions in Azure Logic Apps](https://learn.microsoft.com/azure/logic-apps/error-exception-handling)
- [Service Bus Explorer data operations](https://learn.microsoft.com/azure/service-bus-messaging/explorer)

### A6 — API Mediation and Event Notification

Evaluate API Management separately from messaging, and compare durable Service Bus messaging with Event Grid notification. API Management Consumption and a backend-free mock-response exercise are candidates, subject to subscription availability and current cost verification.

**Official references:**

- [Mock API responses in API Management](https://learn.microsoft.com/azure/api-management/mock-api-responses)
- [Choose an Azure messaging service](https://learn.microsoft.com/azure/architecture/guide/technology-choices/messaging)
- [Event-driven architecture style](https://learn.microsoft.com/azure/architecture/guide/architecture-styles/event-driven)

### A7 — Advanced Pattern Exercises

Continue with Splitter, Service Bus sessions and ordering, Aggregator, Scatter-Gather, Claim Check, and Saga only after the core observable flow is understood. These remain mapped to the existing roadmap phases rather than becoming a duplicate roadmap.

**Official references:**

- [Service Bus message sessions](https://learn.microsoft.com/azure/service-bus-messaging/message-sessions)
- [Claim-Check pattern](https://learn.microsoft.com/azure/architecture/patterns/claim-check)
- [BizTalk Server migration approaches for Azure Logic Apps](https://learn.microsoft.com/azure/logic-apps/biztalk-server-migration-approaches)

## SDK Selection

Microsoft plans to retire support for `WindowsAzure.ServiceBus`, `Microsoft.Azure.ServiceBus`, and `com.microsoft.azure.servicebus` on 30 September 2026. New code-based exercises must use a current SDK such as `Azure.Messaging.ServiceBus`; older samples are references only and are not selected for implementation.

- [Current Azure Service Bus client library for .NET](https://github.com/Azure/azure-sdk-for-net/tree/main/sdk/servicebus/Azure.Messaging.ServiceBus)
- [Microsoft Service Bus SDK retirement notice](https://learn.microsoft.com/azure/service-bus-messaging/service-bus-queues-topics-subscriptions)

## Cost and Cleanup Guardrails

The Azure for Students credit is limited, and a budget alert does not stop resource consumption. Before each exercise:

- [ ] Verify subscription eligibility, regional availability, and current pricing.
- [ ] List every required resource and justify it.
- [ ] Estimate active and idle costs.
- [ ] Define the cleanup command or Portal steps.
- [ ] Obtain approval before deployment.
- [ ] Delete temporary resources immediately after evidence is captured.
- [ ] Verify that deletion completed and no billable dependency remains.

Use the smallest suitable tier. Basic Service Bus can support the first queue-only exercise, while topics and sessions require Standard or Premium; a shared Standard namespace may reduce rework but has a base charge. Premium, always-on compute, unnecessary VMs, dedicated plans, and unrelated services are excluded unless a later requirement justifies them.

Logic Apps Consumption is preferred for early exercises, but connector operations and polling can incur charges even when no useful message is processed. Disable or remove experimental workflows after use. Logic Apps Standard remains a required architecture comparison, not the default student-lab deployment.

API Management tier availability and cost must be checked against the actual subscription immediately before its exercise. If the suitable option would consume disproportionate credit, document the decision and defer deployment.

## Current State

- Official sources for the sequence have been reviewed.
- The first exercise is A1 — Queue Delivery and Settlement.
- A Basic Service Bus namespace and queue have been created and exercised through Service Bus Explorer.
- The F11 Function App and ProcessOrderMessage consumer have been deployed and verified.
- Complete, consumer-driven dead-letter, and Abandon/redelivery behavior have been observed.
- A1 remains in progress because Defer retrieval, the final architecture review, migration lesson, and cleanup are not complete.
- No BizTalk behavior comparison or migration claim has been completed.
