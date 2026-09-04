# Lab Setup Log

## Milestones

1. Repository initialized and documentation structure created.
2. Hyper-V selected to isolate the legacy lab from the host environment.
3. `BizTalk-Lab` Generation 2 VM created.
4. VM configured with 8192 MB startup memory, Dynamic Memory, 8 virtual processors, a dynamically expanding 150 GB VHDX, Default Switch networking, and Microsoft Secure Boot.
5. Windows Server 2019 installation ISO attached and verified as bootable x64 UEFI media.
6. Windows Server 2019 Standard Evaluation (Desktop Experience) installed successfully.
7. Guest network and Hyper-V heartbeat verified.
8. `Clean-Windows-Server-2019` Standard checkpoint created and verified.

## Current Lab State

| Component | Status |
| --- | --- |
| VM | Running and healthy |
| Windows Server | Installed and patched (10.0.17763.9121) |
| SQL Server | SQL Server 2019 Developer CU32 (15.0.4430.1) installed and verified |
| Visual Studio | Visual Studio 2019 Enterprise installed and verified |
| BizTalk Server | Not installed |
| Legacy application | Not deployed |
| Azure migration | Not started |

## SQL Server 2019 Pre-Installation Check

- Guest operating system verified as 64-bit Windows Server 2019 Standard Evaluation.
- Approximately 139 GB of free guest disk space was available.
- No SQL Server services or installed SQL Server instances were detected.
- No SQL Server 2019 installation media was available in the checked host download location.
- SQL Server installation has not started.

## SQL Server 2019 Installation Media

- Official SQL Server 2019 Developer x64 English ISO downloaded inside the guest.
- ISO readability and expected Setup content verified.
- SQL Server Setup has a valid Microsoft digital signature.
- Installation has not started; license terms have not been accepted.

## SQL Server 2019 Installation

- Installed SQL Server 2019 Developer Edition (64-bit).
- Installed the Database Engine for the default `MSSQLSERVER` instance.
- Configured Windows Authentication only; no SQL credentials were created.
- Database Engine and SQL Server Agent services verified as running with automatic startup.
- Local database connectivity verified with a successful query.
- SQL Server version verified as 15.0.2000.5 (RTM).
- TCP/IP remains disabled because the current lab uses a single-machine local connection.
- Analysis Services, Reporting Services, Machine Learning Services, PolyBase, and BizTalk Server were not installed.
- Created and verified the `SQL-Server-2019-Ready` Standard Hyper-V checkpoint.

## Visual Studio 2019 Installation

- Installed Visual Studio Enterprise 2019 version 16.11.37530.7.
- Installed the .NET desktop development workload and its recommended components.
- Restarted the VM after Setup requested a reboot.
- Verified that Visual Studio is fully installed and launchable.
- BizTalk Developer Tools, BizTalk Server, and additional Visual Studio workloads were not installed.

## Phase 1 — Windows Server Update Baseline

- Before: `10.0.17763.3650`.
- After: `10.0.17763.9121`.

- Windows Update service queried and verified active.
- Initial build: Windows Server 2019 Standard Evaluation Build `10.0.17763.3650`.
- Identified, downloaded, and installed current critical, security, and cumulative updates:
  - `KB5120238`: 2026-08 Cumulative Update for Windows Server 2019 (1809)
  - `KB5121645`: 2026-08 Cumulative Update for .NET Framework 3.5, 4.7.2 and 4.8
  - `KB4589208`: 2021-01 Update for Windows Server 2019 for x64-based Systems
  - `KB890830`: Windows Malicious Software Removal Tool
- Performed a graceful operating-system restart to commit update packages.
- Post-reboot verification confirmed:
  - Operating system build updated to `10.0.17763.9121`.
  - Windows Firewall profiles (Domain, Private, Public) remained enabled and intact.
  - UAC (`EnableLUA`) remained enabled and active.
  - `MSSQLSERVER` and `SQLSERVERAGENT` services started automatically and are running healthy.
  - Guest disk space: approximately 121.4 GB free.

### Git Milestone

- Commit: `a6c4d40`.
- Message: `chore: patch Windows Server 2019 to latest security baseline`.

## SQL Server 2019 Servicing (Cumulative Update 32)

- Queried official Microsoft SQL Server 2019 servicing information:
  - Official Microsoft CU: `KB5054833` (SQL Server 2019 Cumulative Update 32).
  - Target build: `15.0.4430.1`.
- Downloaded official update package `SQLServer2019-KB5054833-x64.exe` directly from Microsoft Update Catalog CDN.
- Verified Microsoft digital signature on installer package (`CN=Microsoft Corporation`).
- Extracted and applied patch unattended: `SETUP.EXE /q /IAcceptSQLServerLicenseTerms /Action=Patch /AllInstances`.
- Setup finished with ExitCode `0` (Success).
- Post-patch verification confirmed:
  - SQL Server build updated from `15.0.2000.5` (RTM) to `15.0.4430.1` (RTM-CU32).
  - `MSSQLSERVER` service: `Running` with `Automatic` startup.
  - `SQLSERVERAGENT` service: `Running` with `Automatic` startup.
  - Local Windows-authenticated SQL connection verified via ADO.NET query against `master`.
  - No unexpected SQL components or instances were added.
  - No reboot was required (pending reboot flags verified as `False`).
  - Existing Hyper-V checkpoints (`Clean-Windows-Server-2019`, `SQL-Server-2019-Ready`) remained intact and VM health verified.
