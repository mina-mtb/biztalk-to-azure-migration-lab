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
| BizTalk Prerequisites | Verified and configured (VC++ x86/x64, OLE DB 18.7.4.0, .NET Framework, local MSDTC) |
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

## BizTalk Server 2020 Prerequisites Verification & Configuration

Evaluated all prerequisites against official Microsoft BizTalk Server 2020 documentation:

### Prerequisite Classification

1. **.NET Framework**:
   - Status: **Already satisfied**.
   - Detected: .NET Framework 4.7.2 / 4.8 baseline (Release `461814`, Version `4.7.03190`) with security update `KB5121645`.
   - Satisfies the BizTalk 2020 minimum requirement (.NET 4.7.2).

2. **Microsoft Visual C++ 2015–2019 Redistributables**:
   - Status: **Already satisfied**.
   - Detected:
     - `Microsoft Visual C++ 2015-2019 Redistributable (x86) - 14.29.30157`
     - `Microsoft Visual C++ 2015-2019 Redistributable (x64) - 14.29.30157`
   - Both 32-bit and 64-bit runtimes are present and satisfied.

3. **Microsoft OLE DB Driver for SQL Server (MSOLEDBSQL)**:
   - Status: **Already satisfied**.
   - Detected: `Microsoft OLE DB Driver for SQL Server` version `18.7.4.0` (compatible 18.x series).
   - Satisfies the BizTalk 2020 minimum requirement (18.3.0 or newer 18.x).

4. **Microsoft Distributed Transaction Coordinator (MSDTC)**:
   - Status: **Configured & Hardened (Least Privilege)**.
   - **Configuration Evolution & Security Review**:
     - *Initial Setup*: Configured with broad Network DTC capabilities (`Inbound`, `Outbound`, `RemoteClientAccess`, `RemoteAdministrationAccess`, `XA`, `LU6.2`, `NoAuth`, and enabled DTC firewall rules).
     - *Topology Analysis & Reconsideration*: A security review evaluated the requirements of our single-machine lab topology where BizTalk Server and SQL Server execute on the same Windows Server 2019 VM.
     - *Rationale for Hardening*: In a single-machine architecture, BizTalk host instances (`BTSNTSvc.exe`) and SQL Server (`sqlservr.exe`) interact with the local MSDTC proxy via local inter-process communication (LPC / shared memory). Remote network DTC protocols, external RPC endpoints, XA/LU gateways, and open firewall rules are unnecessary and needlessly widen the attack surface.
     - *Applied Least-Privilege Settings*:
       - `InboundTransactionsEnabled`: `False`
       - `OutboundTransactionsEnabled`: `False`
       - `RemoteClientAccessEnabled`: `False`
       - `RemoteAdministrationAccessEnabled`: `False`
       - `XATransactionsEnabled`: `False`
       - `LUTransactionsEnabled`: `False`
       - `AuthenticationLevel`: `Mutual`
       - Distributed Transaction Coordinator firewall rule group: **Disabled** (0 active rules).
   - **Post-Hardening Service & Connectivity Verification**:
     - `MSDTC` service: `Running` with `Automatic` startup.
     - `MSSQLSERVER` and `SQLSERVERAGENT` services: `Running` with `Automatic` startup.
     - Local Windows-authenticated SQL connectivity: Verified via ADO.NET query against SQL Server 2019 CU32 (`15.0.4430.1`).
     - Reboot pending: `False`.

5. **Windows Features**:
   - Status: **Already satisfied**.
   - Windows Server 2019 standard components verified.

6. **Internet Information Services (IIS)**:
   - Status: **Not required for current core-lab scope** (Kept disabled).
   - IIS is required only for BAM Portal, REST APIs, or HTTP/SOAP adapter endpoints hosted in IIS. Core Runtime, Administration Tools, Developer Tools, and SDK do not require IIS.

7. **Optional Components (BAM, EDI, SSIS, Analysis Services, SharePoint)**:
   - Status: **Intentionally excluded** to maintain a lean, stable developer lab.

### Post-Prerequisite Verification

- Operating System: `Windows Server 2019 Standard Evaluation (10.0.17763.9121)`.
- SQL Server: `MSSQLSERVER` and `SQLSERVERAGENT` running healthy on `15.0.4430.1` (CU32).
- Local SQL Windows Authentication connectivity: Verified.
- MSDTC service: `Running` (Automatic) with verified transaction settings.
- Visual Studio 2019: Launchable and healthy (16.11.37530.7).
- Reboot pending: `False` (No reboot required).
- Guest disk space: `119.75 GB` free.

## Stable Prerequisite Milestone

- Stable prerequisite baseline reached.
- Windows Server 2019 is installed and patched.
- SQL Server 2019 Developer is installed, verified, and updated to CU32 (`15.0.4430.1`).
- Visual Studio Enterprise 2019 is installed and verified.
- Required BizTalk prerequisites were inspected and satisfied.
- Local MSDTC is running and hardened for the current single-machine topology.
- Network DTC capabilities and DTC firewall exposure remain disabled because they are not required by this topology.
- SQL Server, MSDTC, and VM health checks passed after hardening.
- BizTalk Server 2020 is not installed; pattern labs and Azure migration work have not started.
- Learning review for the stable prerequisite milestone completed.
- Next technical phase: verify Visual Studio readiness for BizTalk Developer Tools, then obtain official BizTalk Server 2020 Developer media.

## Phase 4 — Visual Studio 2019 Readiness Verification

- **Visual Studio Edition**: Visual Studio Enterprise 2019 (`Microsoft.VisualStudio.Product.Enterprise`).
- **Version / Build**: `16.11.37530.7` (Channel: `VisualStudio.16.Release`).
- **Installation Health**: `IsComplete: True`, `IsLaunchable: True`, `IsRebootRequired: False`.
- **Workload Verification (against BizTalk Server 2020 Requirements)**:
  - `.NET desktop development` workload (`Microsoft.VisualStudio.Workload.ManagedDesktop`): **Installed & Active**.
  - .NET Framework 4.8 SDK (`Microsoft.Net.Component.4.8.SDK`): **Installed**.
  - .NET Framework 4.7.2 Targeting Pack (`Microsoft.Net.Component.4.7.2.TargetingPack`): **Installed**.
  - MSBuild (`Microsoft.Component.MSBuild`): **Installed**.
  - Roslyn Language Services & Compilers (`Microsoft.VisualStudio.Component.Roslyn.LanguageServices`): **Installed**.
  - Additional targeting packs: .NET Framework 4.0, 4.5, 4.5.1, 4.5.2, 4.6, 4.6.1.
- **Missing Components**: None. No additional Visual Studio workloads or components are required for BizTalk Developer Tools.
- **Licensing & Evaluation State**:
  - Operates under the standard Visual Studio Enterprise 30-day evaluation period.
  - Evaluation mode is fully functional and does not restrict BizTalk Developer Tools installation or project compilation.
  - Can be activated with a Visual Studio subscription or product key if extended usage is required.
- **Readiness Conclusion**: Environment is **ready** for BizTalk Server 2020 Developer Tools integration.

## Phase 5 — Official BizTalk Server 2020 Media Discovery & Acquisition Path

- **Host and VM Media Search**:
  - Searched host directories (`Downloads`, `Desktop`, `Documents`, `C:\ISO`, `C:\Setup`, `C:\Media`) and VM guest storage.
  - No existing BizTalk Server 2020 base installation media ISO was present on the host or VM.
- **Official Microsoft Distribution Channels Evaluated**:
  - *Visual Studio Subscriptions Portal (`my.visualstudio.com`)*: The exclusive official distribution channel for the **BizTalk Server 2020 Developer Edition** base ISO (`.iso`). Requires a qualifying paid/commercial Visual Studio Subscription (Enterprise or Professional with standard MSDN benefits).
  - *Azure for Students / Education Software Hub*: Authenticated verification confirmed that the Azure Education Software catalog includes Windows Server and SQL Server Developer, but **does not include BizTalk Server 2020**.
  - *Azure Marketplace VM Images*: Microsoft does not provide a pre-configured "BizTalk Server 2020 Developer" VM image in Azure (and is deprecating commercial BizTalk VM offers). Deploying a VM in Azure provides only base Windows/SQL compute and does not solve the BizTalk media entitlement requirement.
  - *Microsoft Download Center*: Publicly provides only Cumulative Updates (CU1 through CU6), accelerators, and adapters, but no base installation media.
- **Entitlement Conclusion**:
  - BizTalk Server 2020 Developer ISO is not available through Azure for Students or Dev Essentials.
  - Obtaining the local BizTalk Server 2020 installer ISO requires an account with a qualifying standard Visual Studio (MSDN) Subscription or Microsoft Volume Licensing agreement.
