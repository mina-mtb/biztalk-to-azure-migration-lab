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
| Windows Server | Installed |
| SQL Server | SQL Server 2019 Developer installed and verified |
| Visual Studio | Not installed |
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
