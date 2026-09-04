# BizTalk to Azure — Concise Engineering Learning Notes

These short Q&A notes capture engineering concepts and architecture decisions encountered in the hands-on migration lab. They support technical review and interview preparation without claiming experience beyond the verified lab work.

## Lab Architecture

### Why does the lab use an isolated virtualized environment?

The Hyper-V VM keeps the legacy integration stack separate from the host and provides a controlled, repeatable environment. This limits configuration impact and makes recovery points practical.

### What is the role of a Hyper-V checkpoint in this lab?

A checkpoint preserves VM configuration and virtual disk state before significant changes. It supports short-term rollback during lab work but is not an independent backup.

### Why is the software stack installed on Windows Server rather than the host?

The VM represents a realistic server boundary for BizTalk and its dependencies. It avoids coupling the host workstation to legacy middleware configuration.

### What is the current lab topology?

Windows Server 2019, SQL Server 2019 Developer CU32, Visual Studio Enterprise 2019, and local MSDTC run inside one VM. BizTalk prerequisites are satisfied, but BizTalk Server 2020 is not installed.

```text
Host Windows
    |
Hyper-V
    |
BizTalk-Lab VM
    +-- Windows Server 2019
    +-- SQL Server 2019 Developer CU32
    +-- Visual Studio Enterprise 2019
    +-- Local MSDTC
    +-- BizTalk Server 2020 (planned)
```

## BizTalk Architecture Context

### What role will BizTalk Server have in the lab?

BizTalk will host a legacy integration solution that can be inspected, documented, and later migrated pattern by pattern. No BizTalk application has been selected or deployed yet.

### Why is BizTalk considered integration middleware?

BizTalk sits between systems and mediates communication across different protocols, message formats, and process rules. It can receive, validate, transform, route, orchestrate, and send messages.

### Why does BizTalk rely on SQL Server?

BizTalk persists configuration, messages, processing state, and tracking data in SQL Server. The detailed roles of the individual BizTalk databases have not yet been studied in this lab.

### Why was SQL Server installed before BizTalk?

SQL Server is a core BizTalk dependency. Installing and validating it first isolates database readiness from the later BizTalk installation and configuration work.

## SQL Server Baseline

### Why is SQL Server Developer Edition appropriate here?

Developer Edition provides SQL Server capabilities for non-production development and testing. This repository documents a learning lab, not a production deployment.

### What is the SQL Server instance configuration?

The lab uses the default Database Engine instance, identified by the service name `MSSQLSERVER`. Local connections can use the machine name without a named-instance suffix.

### Why does the lab use Windows Authentication?

Windows Authentication uses Windows identities and avoids introducing separate SQL credentials. It is sufficient for the verified local lab connectivity.

### Why was SQL Server patched before BizTalk installation?

SQL Server was updated from RTM to CU32 (`15.0.4430.1`) to establish a serviced and verified baseline before BizTalk is added.

### What is a SQL Server Cumulative Update?

A Cumulative Update packages SQL Server fixes released up to that servicing point. Applying a CU changes the product build while keeping it within the SQL Server 2019 release.

## Prerequisite Engineering

### Why verify prerequisites before installing additional components?

Verification distinguishes missing requirements from components already present. It reduces unnecessary changes, version conflicts, configuration drift, and attack surface.

### Which BizTalk prerequisites have been verified?

The verified baseline includes the required .NET Framework level, Visual C++ x86 and x64 runtimes, Microsoft OLE DB Driver 18.x, and local MSDTC. BizTalk Server itself remains uninstalled.

### Why are optional BizTalk components excluded from the initial lab?

Components such as BAM Portal, EDI, SSIS, Analysis Services, and SharePoint are outside the current core-lab scope. Excluding them keeps the baseline smaller and avoids configuration without a demonstrated requirement.

### Why is IIS not enabled for the current scope?

The planned core runtime, administration, development tools, and SDK do not require IIS. IIS should be introduced only if a selected scenario requires an IIS-hosted endpoint or related feature.

### What does least privilege mean in integration infrastructure?

Services, permissions, features, and network access should be enabled only when the selected topology and workload require them. This reduces exposure and makes configuration intent easier to audit.

## Distributed Transactions

### What is MSDTC used for?

Microsoft Distributed Transaction Coordinator coordinates transactions that span multiple transactional resource managers. It enables participants to commit or roll back as one transaction.

### Why can BizTalk require MSDTC?

BizTalk uses transactional processing across its runtime and SQL-backed persistence. MSDTC requirements depend on where BizTalk services, SQL Server, and other transactional resources are deployed.

### What is the difference between local MSDTC and Network DTC?

Local MSDTC coordinates transactional work on one machine. Network DTC permits transaction coordination across machine boundaries and requires additional network, authentication, and firewall configuration.

### Why is Network DTC disabled in the current lab?

The planned BizTalk runtime, SQL Server, and MSDTC are all inside one VM. Network DTC adds no capability required by this topology, so inbound, outbound, remote client, and remote administration access are disabled.

### Which other DTC capabilities were disabled?

XA and LU transactions are disabled, and DTC firewall exposure was removed. Local MSDTC remains running with Mutual authentication.

### When would Network DTC become necessary?

It may become necessary if BizTalk and SQL Server, or another transactional participant, are separated across machines. The requirements must then be reassessed for connectivity, authentication, firewall policy, and failure behavior.

### Is the current DTC configuration a universal BizTalk rule?

No. It is a least-privilege decision for the current single-machine topology. A distributed topology can require a different configuration.

## Operational Validation

### Why verify services after patching or hardening?

A successful installer or restart does not prove the environment is healthy. Service state, startup mode, connectivity, version, firewall posture, and pending-reboot state provide stronger evidence.

### What was verified after MSDTC hardening?

MSDTC, SQL Server, and SQL Server Agent were running with automatic startup. Local Windows-authenticated SQL connectivity, the SQL CU32 build, VM health, and the absence of a pending reboot were also verified.

### Why remain at the stable prerequisite milestone for now?

The pause separates infrastructure execution from architecture understanding. BizTalk installation will begin only after the current topology and prerequisite decisions have been reviewed.

## Agent-Assisted Engineering

### How are AI agents used in this project?

Agents assist with repetitive inspection, setup, verification, documentation, and later implementation tasks. Architecture understanding, acceptance of risk, and final decisions remain human responsibilities.

### Why must agent recommendations be reviewed?

An agent can miss topology, security, licensing, or operational context. Recommendations should be tested against verified state, official requirements, alternatives, and failure modes.

### What does “patterns first, tools second” mean?

Identify the integration problem, constraints, and pattern before selecting an Azure service. Tool selection should follow the architecture need rather than define it.

## Migration Approach

### Why does discovery precede migration design?

Discovery establishes the actual artifacts, dependencies, message flows, and operational constraints. Without that evidence, migration decisions depend on assumptions.

### What is the distinction between AS-IS and TO-BE architecture?

AS-IS describes the verified current environment and behavior. TO-BE describes the intended future architecture after requirements and trade-offs are understood.

### Why migrate one pattern or sample at a time?

Small migration slices make behavior, failure modes, and Azure alternatives easier to compare and validate. They also reduce the combined risk of a Big Bang migration.

### Why is this not a lift-and-shift exercise?

The goal is to understand each integration and select an appropriate Azure design. Reproducing the existing platform structure without analysis would preserve constraints without proving they remain useful.

## How This Document Grows

This file is updated only when a concept or architecture decision has actually been studied or encountered in the lab.

Future notes may cover BizTalk artifacts, integration patterns, Azure services, resilience, security, observability, distributed transactions, and migration architecture. They will be added only after the corresponding work is performed.
