# Discovery

## Purpose

Discovery establishes what the legacy environment contains, how integrations behave, and which systems and operational constraints depend on them. Migration decisions should be based on verified artifacts and flows rather than assumptions or direct product-to-product mapping.

## Current Lab Environment

| Setting | Verified configuration |
| --- | --- |
| Hypervisor | Hyper-V |
| VM name | BizTalk-Lab |
| Generation | 2 |
| Startup memory | 8192 MB |
| Dynamic memory | Enabled |
| vCPU | 8 |
| Disk | Dynamically expanding VHDX, 150 GB maximum |
| Network | Hyper-V Default Switch |
| Secure Boot | Enabled, `MicrosoftWindows` template |

## Operating System

Windows Server 2019 Standard Evaluation with Desktop Experience is installed and patched to build `10.0.17763.9121`.

## Planned Legacy Stack

| Component | Status |
| --- | --- |
| Windows Server 2019 | Installed and patched (10.0.17763.9121) |
| SQL Server 2019 | Installed and patched (15.0.4430.1 CU32 Developer) |
| Visual Studio 2019 | Installed (16.11.37530.7 Enterprise) |
| BizTalk Prerequisites | Verified & configured (.NET 4.8, VC++ x86/x64, OLE DB 18.7.4.0, MSDTC) |
| BizTalk Server 2020 | Planned |

## Recovery Point

`Clean-Windows-Server-2019` is a verified Standard Hyper-V checkpoint created after successful operating-system installation. It provides a safe rollback point before middleware and development tooling are installed.

## Discovery Questions

Once BizTalk and a legacy sample application are installed, discovery will answer:

- What BizTalk applications exist?
- Which schemas are used?
- Which maps are used?
- Which orchestrations exist?
- Which pipelines exist?
- Which receive ports and receive locations exist?
- Which send ports exist?
- Which adapters are used?
- Which systems depend on the integrations?
- Which integrations are synchronous?
- Which integrations are asynchronous?
- Which integrations are high-volume?
- Which messages are large?
- Which transformations exist?
- Which dependencies are tightly coupled?
- Which business rules exist?
- Which error-handling mechanisms exist?
- Which security mechanisms exist?
- Which integration patterns are present?

## Discovery Output

The discovery phase will eventually produce:

- Artifact inventory
- Dependency map
- Integration flow diagrams
- Integration pattern classification
- Risk assessment
- Migration candidates
- Migration priority
