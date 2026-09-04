# BizTalk to Azure Migration Lab

## Overview

This repository is a hands-on learning and architecture lab for understanding a legacy BizTalk integration environment and migrating it to Azure Integration Services.

The goal is not a one-to-one lift and shift. The lab will first document the existing artifacts, dependencies, workloads, and integration patterns. Those findings will then guide an appropriate Azure design.

## Why this lab exists

The lab is intended to build practical experience with:

- BizTalk architecture
- Legacy integration discovery
- Integration patterns
- Migration decisions
- Azure Integration Services
- Architecture trade-offs

## Migration approach

The intended lifecycle is:

**Discover → Plan → Convert → Validate → Deploy**

The project takes a patterns-first, tools-second approach. Technology choices will follow discovery and analysis rather than precede them.

## Current architecture status

The project is currently in the legacy environment setup phase. Windows Server is installed; the legacy middleware and development tools are not.

```mermaid
flowchart LR
    Host[Host Windows] --> HyperV[Hyper-V]
    HyperV --> VM[BizTalk-Lab VM]
    VM --> OS[Windows Server 2019<br/>Installed]
    OS -. planned .-> SQL[SQL Server 2019<br/>Not yet installed]
    OS -. planned .-> VS[Visual Studio 2019<br/>Not yet installed]
    OS -. planned .-> BTS[BizTalk Server 2020<br/>Not yet installed]
```

## Current progress

### Completed

- [x] Repository initialized
- [x] Documentation structure created
- [x] Hyper-V lab created
- [x] Windows Server 2019 Standard Evaluation (Desktop Experience) installed
- [x] VM network verified
- [x] Clean Windows Server checkpoint created

### In progress

- [ ] Preparing the legacy BizTalk development environment

### Next

- [ ] Install SQL Server 2019
- [ ] Install Visual Studio 2019
- [ ] Install BizTalk Server 2020
- [ ] Select and deploy a BizTalk sample application
- [ ] Perform discovery and dependency analysis
- [ ] Identify integration patterns
- [ ] Design the Azure target architecture
- [ ] Begin migration implementation

## Planned learning areas

- Schemas
- Maps
- Orchestrations
- Pipelines
- Receive Ports
- Receive Locations
- Send Ports
- MessageBox concepts
- Synchronous and asynchronous integration
- Request/reply
- Publish/subscribe
- Content-based routing
- Transformation
- Retry and resilience
- Dead-letter handling
- Distributed transactions and Saga patterns
- Observability
- Security and managed identity

## Repository structure

- `docs/` contains discovery notes, architecture records, pattern analysis, the migration roadmap, and the lab setup log.
- `legacy-biztalk/` is reserved for the legacy sample solution and related artifacts after they exist.
- `azure/` is reserved for future Azure implementation artifacts after migration design is complete.

## Status

This repository is a work in progress and will evolve as the migration lab progresses.
