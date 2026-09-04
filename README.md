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

The project has reached a stable prerequisite baseline. Windows Server, SQL Server 2019 CU32, Visual Studio 2019, and the BizTalk Server 2020 prerequisites are installed or verified as applicable; BizTalk Server itself is not installed.

```mermaid
flowchart LR
    Host[Host Windows] --> HyperV[Hyper-V]
    HyperV --> VM[BizTalk-Lab VM]
    VM --> OS[Windows Server 2019<br/>Installed & Patched]
    OS --> SQL[SQL Server 2019 CU32<br/>Installed & Verified]
    OS --> VS[Visual Studio 2019<br/>Installed & Verified]
    OS --> PREREQ[BizTalk 2020 Prerequisites<br/>Verified & Configured]
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
- [x] Windows Server 2019 patched to latest security baseline (10.0.17763.9121)
- [x] SQL Server 2019 Developer installed and verified
- [x] SQL Server readiness checkpoint created
- [x] SQL Server 2019 updated to supported CU level (CU32 15.0.4430.1)
- [x] Visual Studio 2019 Enterprise installed and verified
- [x] Visual Studio 2019 component readiness verified for BizTalk Developer Tools
- [x] BizTalk Server 2020 prerequisites verified and configured (.NET 4.8, VC++ x86/x64, OLE DB 18.7.4.0, Hardened Local MSDTC)

### In progress

- [ ] Obtain official BizTalk Server 2020 Developer installation media

### Next

- [ ] Install BizTalk Server 2020 core components
- [ ] Configure BizTalk Server 2020 single-machine environment
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

## Learning Notes

Concise Q&A notes are maintained alongside the hands-on migration work for quick review and architecture recall. See [BizTalk to Azure — Learning Notes](docs/LEARNING-NOTES.md).

## Learning & Migration Roadmap

The project tracks both hands-on implementation and the ability to understand, explain, and defend architecture decisions. The [master learning roadmap](docs/ROADMAP.md) defines completion standards, phased labs, expected deliverables, and senior-level readiness criteria.

| Area | Status |
| --- | --- |
| Lab Foundation | Complete |
| Windows Server | Installed and patched |
| SQL Server | Installed and patched (CU32) |
| Visual Studio | Installed |
| BizTalk Prerequisites | Verified & configured (Hardened Local MSDTC) |
| BizTalk Server | Not installed |
| Microsoft BizTalk Pattern Labs | Not started |
| Discovery | Not started |
| Azure Migration | Not started |
| Validation | Not started |
| Deployment | Not started |

## Repository structure

- `docs/` contains discovery notes, architecture records, pattern analysis, the migration roadmap, and the lab setup log.
- `legacy-biztalk/` is reserved for the legacy sample solution and related artifacts after they exist.
- `azure/` is reserved for future Azure implementation artifacts after migration design is complete.

## Status

The stable prerequisite baseline and its learning review are complete. The next technical phase is Visual Studio readiness verification followed by obtaining official BizTalk Server 2020 Developer media; BizTalk Server is not installed.
