# BizTalk to Azure Learning Roadmap

This roadmap tracks execution and independent understanding. A checkbox is complete only when the work has been performed and the learner can explain it without relying on an agent.

## Completion Standard

There are three levels of completion. For important topics, the main topic is complete only when all three levels have been reached.

### Level 1 — Understand

I can explain:

- What the concept is
- Why it exists
- When it is useful
- When it should not be used

### Level 2 — Implement

I have:

- Seen the implementation
- Run it
- Changed it
- Tested it
- Intentionally triggered important failures
- Observed the behavior

### Level 3 — Architect

I can:

- Identify the pattern from requirements
- Compare alternative implementations
- Explain trade-offs
- Challenge an AI-generated design
- Select an appropriate Azure service
- Justify the decision
- Discuss reliability, scalability, security, observability, and cost

## Phase 0 — Lab Foundation


### Verified Completed Items

- [x] GitHub repository created
- [x] Repository documentation structure created
- [x] Hyper-V selected as the local virtualization platform
- [x] BizTalk-Lab VM created
- [x] Windows Server 2019 Standard Evaluation (Desktop Experience) installed
- [x] VM networking verified
- [x] Clean-Windows-Server-2019 checkpoint created
- [x] Windows Server 2019 patched to latest security baseline (10.0.17763.9121)
- [x] Install SQL Server 2019 Developer
- [x] Verify SQL Server services
- [x] Verify SQL connectivity
- [x] Create SQL-Server-2019-Ready checkpoint
- [x] Update SQL Server 2019 to supported CU level (CU32 15.0.4430.1)
- [x] Install Visual Studio Enterprise 2019
- [x] Verify Visual Studio launch
- [x] Verify and configure BizTalk Server 2020 prerequisites (.NET 4.8, VC++ 2015-2019 x86/x64, OLE DB 18.7.4.0, MSDTC)

### Remaining Work

- [ ] Obtain official BizTalk Server 2020 Developer installation media
- [ ] Install BizTalk Server 2020 core components
- [ ] Configure BizTalk Server 2020 (single-machine configuration)
- [ ] Apply latest BizTalk Server 2020 Cumulative Update
- [ ] Verify BizTalk Administration Console
- [ ] Verify BizTalk development tools in Visual Studio
- [ ] Verify BizTalk services and host instances
- [ ] Create post-BizTalk checkpoint

### Current Active Task

Updating SQL Server 2019 from RTM to an appropriate supported CU/security build before BizTalk Server installation.

### Exit Criteria

- [ ] I can explain why BizTalk depends on SQL Server.
- [ ] I can explain the role of the BizTalk Management database.
- [ ] I can explain the role of the MessageBox database.
- [ ] I understand why this lab uses a VM.
- [ ] I can explain the purpose of the clean checkpoint.


## Phase 1 — BizTalk Core Concepts


### BizTalk Application

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

I must understand:
- what a BizTalk Application is,
- what artifacts it contains,
- how deployment works.

### Schema

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

I must understand:
- XML schemas,
- message contracts,
- validation,
- namespaces,
- why schema changes affect integrations.

### Map

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

I must understand:
- transformation,
- source schema,
- destination schema,
- XSLT concept,
- mapping risks.

### Pipeline

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

I must understand:
- receive pipeline,
- send pipeline,
- decode,
- disassemble,
- validate,
- assemble,
- encode.

### Orchestration

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

I must understand:
- workflow,
- long-running processes,
- persistence,
- correlation,
- transactions,
- exception handling.

### Receive Port

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### Receive Location

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### Send Port

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### Adapter

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### MessageBox

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

I must understand:
- publish/subscribe behavior,
- subscriptions,
- persistence,
- routing,
- why MessageBox is central to BizTalk architecture.

### Host

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### Host Instance

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### Suspended Messages

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### Tracking

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### Binding files

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### Business Rules Engine

- [ ] Understand
- [ ] Implement/Observe
- [ ] Architect-level explanation

### Exit Criteria

- [ ] I can draw a basic BizTalk message flow from memory.
- [ ] I can explain how a message enters BizTalk.
- [ ] I can explain how BizTalk decides where the message goes.
- [ ] I can explain where messages are persisted.
- [ ] I can explain the difference between orchestration logic and messaging/routing logic.
- [ ] I can inspect a BizTalk application without an agent and identify the major artifacts.


## Phase 2 — Microsoft BizTalk Pattern Labs


We will use official Microsoft BizTalk samples where suitable.

Important:
Complete the labs one by one, not all at once.

Each pattern lab uses the same completion standard. Labs are completed one at a time.

### Patterns in Learning Order

### 2.1 Content-Based Router

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

#### Senior-Level Questions
- What data determines routing?
- Where should routing rules live?
- What happens when routing rules change frequently?
- When is routing in Logic Apps appropriate?
- When should routing happen in Service Bus subscriptions?
- What happens if no route matches?

### 2.2 Message Transformation

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

#### Learning Topics
- XML-to-XML
- schema evolution
- canonical model concept
- transformation ownership

#### Senior-Level Questions
- Should transformation occur at the producer, intermediary, or consumer?
- When does a canonical model help?
- When does it become an unnecessary abstraction?

### 2.3 Splitter

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

#### Senior-Level Questions
- What happens if one child message fails?
- How do we preserve correlation?
- What happens with large batches?
- Do we need ordering?

### 2.4 Aggregator

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

#### Required Topics
- correlation
- completion condition
- timeout
- partial results

#### Senior-Level Questions
- How long do we wait?
- Where is aggregation state stored?
- What happens when a message never arrives?
- How do we scale the aggregator?

### 2.5 Recipient List

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

### 2.6 Publish / Subscribe

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

#### Required Comparison
- Service Bus Queue
- Service Bus Topic
- Event Grid

#### Senior-Level Questions
- Is this a command or event?
- Is durable delivery required?
- Can subscribers be temporarily unavailable?
- Does every subscriber need every message?

### 2.7 Scatter-Gather

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

#### Required Understanding
- parallel fan-out
- result collection
- timeout
- partial failure

### 2.8 Correlation

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

### 2.9 Sequential Convoy

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

#### Required Understanding
- ordering
- related messages
- state
- concurrency risks

### 2.10 Retry / Suspend

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

#### Required Understanding
- transient vs permanent failure
- retry safety
- duplicate processing
- retry storms

### 2.11 Compensation

- [ ] Obtain official Microsoft sample or equivalent official implementation
- [ ] Deploy sample
- [ ] Run sample successfully
- [ ] Inspect BizTalk artifacts
- [ ] Draw the message flow
- [ ] Explain the pattern in my own words
- [ ] Explain why this pattern was selected
- [ ] Identify advantages
- [ ] Identify disadvantages
- [ ] Identify common failure modes
- [ ] Trigger an important failure or edge case
- [ ] Observe BizTalk behavior
- [ ] Identify Azure implementation options
- [ ] Compare at least two Azure alternatives
- [ ] Choose an Azure design
- [ ] Explain why the chosen Azure design is appropriate
- [ ] Challenge the agent's proposed design
- [ ] Implement the Azure version
- [ ] Test the Azure version
- [ ] Compare BizTalk and Azure behavior
- [ ] Document the architecture decision

#### Required Understanding
- rollback vs compensation
- distributed transactions
- Saga relationship
- eventual consistency


## Phase 3 — Discovery / Sprint Zero


### Goal
Learn to inspect an existing BizTalk estate before migration.

Checklist:

- [ ] Inventory BizTalk applications
- [ ] Inventory schemas
- [ ] Inventory maps
- [ ] Inventory orchestrations
- [ ] Inventory pipelines
- [ ] Inventory receive ports
- [ ] Inventory receive locations
- [ ] Inventory send ports
- [ ] Inventory adapters
- [ ] Inventory host instances
- [ ] Inventory business rules
- [ ] Inventory binding files
- [ ] Identify SQL dependencies
- [ ] Identify external databases
- [ ] Identify APIs
- [ ] Identify SOAP services
- [ ] Identify file integrations
- [ ] Identify SFTP integrations
- [ ] Identify external queues/topics
- [ ] Identify security mechanisms
- [ ] Identify credentials/secrets handling
- [ ] Identify message sizes
- [ ] Identify message volumes
- [ ] Identify peak traffic
- [ ] Identify latency requirements
- [ ] Identify synchronous flows
- [ ] Identify asynchronous flows
- [ ] Identify critical business flows
- [ ] Identify downstream dependencies
- [ ] Identify upstream dependencies
- [ ] Identify unsupported/deprecated components

### Deliverables

- [ ] Artifact inventory
- [ ] Dependency matrix
- [ ] AS-IS architecture diagram
- [ ] Integration landscape diagram
- [ ] Message-flow diagrams
- [ ] Risk register
- [ ] Migration candidate list

### Senior Exit Criteria

- [ ] I can explain why migration should not start before discovery.
- [ ] I can identify hidden dependencies.
- [ ] I can distinguish business-critical flows from low-risk flows.
- [ ] I can explain which integrations should migrate first and why.


## Phase 4 — Integration Pattern Analysis


For every integration answer:

- [ ] Synchronous or asynchronous?
- [ ] Request, command, event, or document transfer?
- [ ] One consumer or many?
- [ ] Reliable delivery required?
- [ ] At-least-once or effectively-once behavior?
- [ ] Ordering required?
- [ ] Duplicate messages possible?
- [ ] Can processing be idempotent?
- [ ] Message size?
- [ ] Message volume?
- [ ] Peak throughput?
- [ ] Latency requirement?
- [ ] Long-running process?
- [ ] Transaction boundary?
- [ ] Eventual consistency acceptable?
- [ ] What happens if a downstream system is unavailable?
- [ ] Retry safe?
- [ ] Compensation required?
- [ ] Human intervention required?
- [ ] Security boundary?
- [ ] PII/sensitive data?
- [ ] Observability requirement?
- [ ] SLA requirement?
- [ ] Cost sensitivity?

### Patterns to Recognize

- [ ] Request / Reply
- [ ] Asynchronous Messaging
- [ ] Publish / Subscribe
- [ ] Content-Based Router
- [ ] Message Filter
- [ ] Message Transformation
- [ ] Splitter
- [ ] Aggregator
- [ ] Recipient List
- [ ] Scatter-Gather
- [ ] Correlation
- [ ] Routing Slip
- [ ] Claim Check
- [ ] Competing Consumers
- [ ] Idempotent Consumer
- [ ] Retry
- [ ] Dead Letter Queue
- [ ] Circuit Breaker
- [ ] Saga
- [ ] Compensating Transaction
- [ ] Eventual Consistency

### Senior Exit Criteria

- [ ] Given a new integration scenario, I can identify the likely patterns before discussing Azure products.
- [ ] I can detect when an agent jumps directly from a BizTalk artifact to an Azure service without understanding requirements.


## Phase 5 — Migration Strategy


### Learning Objectives

- [ ] Why lift-and-shift is often inappropriate
- [ ] Why Big Bang migration is risky
- [ ] Incremental migration
- [ ] Strangler-style coexistence
- [ ] Hybrid integration
- [ ] Migration waves
- [ ] Rollback strategy
- [ ] Parallel run
- [ ] Cutover
- [ ] Decommissioning

### Classification

- [ ] Keep
- [ ] Refactor
- [ ] Replace
- [ ] Retire

### Prioritization Factors

- [ ] Business criticality
- [ ] Complexity
- [ ] Technical debt
- [ ] Dependency count
- [ ] Support lifecycle
- [ ] Migration risk
- [ ] Cost
- [ ] Business value

### Deliverables

- [ ] Migration waves
- [ ] Migration sequence
- [ ] Coexistence design
- [ ] Cutover plan
- [ ] Rollback plan


## Phase 6 — Azure Service Selection


### Services

### Azure Logic Apps

- [ ] Consumption
- [ ] Standard
- [ ] Stateful workflows
- [ ] Stateless workflows
- [ ] Connectors
- [ ] Error scopes
- [ ] Workflow decomposition

### Azure Service Bus

- [ ] Queue
- [ ] Topic
- [ ] Subscription
- [ ] Sessions
- [ ] Dead-letter queue
- [ ] Duplicate detection
- [ ] Scheduled messages
- [ ] TTL
- [ ] Locking
- [ ] Competing consumers

### Azure Event Grid

- [ ] Event-driven architecture
- [ ] Push delivery
- [ ] Event distribution
- [ ] Delivery semantics

### Azure API Management

- [ ] API gateway
- [ ] Authentication
- [ ] Authorization
- [ ] Rate limiting
- [ ] Transformation
- [ ] Versioning
- [ ] Circuit breaker policies

### Azure Functions

- [ ] Event-driven compute
- [ ] When Functions are preferable to Logic Apps
- [ ] Scaling implications

### Azure Blob Storage

- [ ] Large payload storage
- [ ] Claim Check pattern

### Azure Key Vault

### Managed Identity

### Application Insights

### Decision Record Requirements

- [ ] Requirement
- [ ] Pattern
- [ ] Candidate options
- [ ] Chosen option
- [ ] Why chosen
- [ ] Why alternatives rejected
- [ ] Reliability trade-off
- [ ] Scalability trade-off
- [ ] Security trade-off
- [ ] Operational trade-off
- [ ] Cost trade-off

### Senior Exit Criteria

- [ ] I can explain why Service Bus Queue, Topic, and Event Grid are not interchangeable.
- [ ] I can explain when Logic Apps is not the right choice.
- [ ] I can challenge a service recommendation based on requirements.


## Phase 7 — Core Azure Migration Labs


### Hands-on Labs

- [ ] Synchronous API flow
- [ ] Asynchronous queue flow
- [ ] Publish/Subscribe
- [ ] Content-Based Routing
- [ ] Transformation
- [ ] Splitter
- [ ] Aggregator
- [ ] Scatter-Gather
- [ ] Claim Check
- [ ] Competing Consumers
- [ ] Long-running workflow
- [ ] Saga / compensation

For each:

- [ ] Build
- [ ] Run
- [ ] Test
- [ ] Break intentionally
- [ ] Observe
- [ ] Recover
- [ ] Monitor
- [ ] Document decision


## Phase 8 — Resilience & Failure Engineering


### Learning and Implementation

- [ ] Transient failure
- [ ] Permanent failure
- [ ] Retry
- [ ] Exponential backoff
- [ ] Jitter
- [ ] Timeout
- [ ] Dead Letter Queue
- [ ] Poison messages
- [ ] Circuit Breaker
- [ ] Bulkhead concept
- [ ] Idempotency
- [ ] Duplicate detection
- [ ] Compensation
- [ ] Partial failure
- [ ] Graceful degradation

### Hands-on Requirement

For each applicable mechanism:

- [ ] Cause the failure intentionally
- [ ] Predict what should happen
- [ ] Observe actual behavior
- [ ] Explain differences
- [ ] Recover
- [ ] Document findings

### Senior Exit Criteria

- [ ] I can distinguish retryable from non-retryable failures.
- [ ] I understand why blind retry can make an outage worse.
- [ ] I can design failure handling rather than only happy-path workflows.


## Phase 9 — Distributed Transactions


### Learning Objectives

- [ ] Local transaction
- [ ] Distributed transaction
- [ ] Two-Phase Commit concept
- [ ] Why 2PC is problematic in cloud/distributed systems
- [ ] Saga
- [ ] Orchestration-based Saga
- [ ] Choreography-based Saga
- [ ] Compensating action
- [ ] Eventual consistency

### Hands-on

- [ ] Payment succeeds / inventory fails scenario
- [ ] Compensation executes
- [ ] Duplicate event scenario
- [ ] Delayed event scenario
- [ ] Partial failure scenario

### Senior Exit Criteria

- [ ] I can explain why rollback and compensation are different.
- [ ] I can reason about inconsistent intermediate state.
- [ ] I can design recovery behavior.


## Phase 10 — Security


### Learning and Implementation

- [ ] Authentication vs authorization
- [ ] Managed Identity
- [ ] Key Vault
- [ ] Secret rotation
- [ ] Least privilege
- [ ] API authentication
- [ ] API authorization
- [ ] Network boundaries
- [ ] Private endpoints concept
- [ ] Hybrid connectivity
- [ ] Zero Trust principles
- [ ] Sensitive-data handling

### Senior Exit Criteria

- [ ] I can identify hard-coded credential risks.
- [ ] I can explain why identity-based access is preferred.
- [ ] I can discuss application identity vs human identity.


## Phase 11 — Observability


### Learning Objectives

- [ ] Logging
- [ ] Metrics
- [ ] Tracing
- [ ] Correlation ID
- [ ] Distributed tracing
- [ ] Application Insights
- [ ] Failure diagnostics
- [ ] Alerts
- [ ] Dashboards
- [ ] Message tracking

### Hands-on

- [ ] Trace one message from entry to final destination
- [ ] Trace a failed message
- [ ] Trace a retry
- [ ] Trace a DLQ path
- [ ] Correlate logs between multiple components

### Senior Exit Criteria

- [ ] I can answer "where did this message fail?" without guessing.
- [ ] I can design observability as part of architecture rather than adding it afterward.


## Phase 12 — Performance, Scale & Cost


### Learning Objectives

- [ ] Throughput
- [ ] Latency
- [ ] Backpressure
- [ ] Queue depth
- [ ] Scaling consumers
- [ ] Competing consumers
- [ ] Throttling
- [ ] Message batching
- [ ] Logic Apps Consumption pricing
- [ ] Logic Apps Standard pricing
- [ ] Service Bus tiers
- [ ] Cost impact of high message volume
- [ ] Cost impact of retries
- [ ] Cost impact of logging

### Hands-on

- [ ] Create load
- [ ] Observe queue growth
- [ ] Scale processing
- [ ] Compare behavior
- [ ] Document cost considerations

### Senior Exit Criteria

- [ ] I can discuss architecture and cost together.
- [ ] I understand that technically valid architecture may still be economically poor.


## Phase 13 — Validation


### Validation Checklist

- [ ] Functional test
- [ ] Contract/schema test
- [ ] Transformation test
- [ ] Failure test
- [ ] Retry test
- [ ] DLQ test
- [ ] Duplicate-message test
- [ ] Ordering test where required
- [ ] Security test
- [ ] Performance test
- [ ] Message integrity test
- [ ] End-to-end trace
- [ ] Compare BizTalk output with Azure output


## Phase 14 — Deployment & Operations


### Learning and Implementation

- [ ] Infrastructure as Code
- [ ] Environment separation
- [ ] Configuration management
- [ ] CI/CD
- [ ] Secret management
- [ ] Deployment validation
- [ ] Rollback
- [ ] Versioning
- [ ] Operational runbook
- [ ] Production readiness


## Phase 15 — Final Architecture Review


### Deliverables

- [ ] Final AS-IS architecture
- [ ] Final TO-BE architecture
- [ ] Integration inventory
- [ ] Dependency map
- [ ] BizTalk-to-Azure migration matrix
- [ ] Pattern-by-pattern decisions
- [ ] Architecture Decision Records
- [ ] Migration waves
- [ ] Reliability design
- [ ] Security design
- [ ] Observability design
- [ ] Cost analysis
- [ ] Risk summary
- [ ] Lessons learned
- [ ] Final migration report


## Senior-Level Readiness Check


Create a final section called:

## Senior-Level Readiness Check

Do NOT mark these complete now.

Add:

- [ ] I can receive a new integration scenario and ask the right discovery questions before proposing technology.

- [ ] I can identify integration patterns from requirements.

- [ ] I can explain BizTalk message flow and major artifacts without assistance.

- [ ] I can review an existing BizTalk integration and identify dependencies and risks.

- [ ] I can decide between synchronous and asynchronous architecture.

- [ ] I can distinguish command, event, and request/reply semantics.

- [ ] I can choose between Service Bus Queue, Topic, Event Grid, API Management, Logic Apps, and Functions based on requirements.

- [ ] I can explain why I rejected alternative architectures.

- [ ] I can design idempotency, retries, DLQ, timeouts, and circuit breaking.

- [ ] I can reason about distributed transactions, Saga, compensation, and eventual consistency.

- [ ] I can design security using identity rather than embedded credentials.

- [ ] I can design observability and distributed tracing.

- [ ] I can evaluate scalability, reliability, operations, and cost together.

- [ ] I can design an incremental BizTalk migration rather than a Big Bang migration.

- [ ] I can challenge an AI agent when its architecture recommendation is unsupported by requirements.

- [ ] I can defend my architecture decisions in a senior technical interview or architecture review.

### Final Completion Rule

The roadmap is not considered complete merely because all software and labs have been executed.

It is complete only when I can independently explain and defend the major architecture decisions.
