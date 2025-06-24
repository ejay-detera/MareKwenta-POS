# 📘 MareKwenta: Set Up Guide

This guide will walk you through setting up an environment to run MareKwenta-POS

---

## ✅ Part 1: Install Visual Studio Community 2022

🔗 [Download Visual Studio](https://visualstudio.microsoft.com/downloads/)

1. Visit the Visual Studio official site.
2. Download the **Community Edition** by clicking **Free download**.
3. Run the installer (`vs_community.exe`) and allow changes when prompted.
4. On the **Workloads** screen, select:
   - ✅ `.NET Desktop Development` (includes Windows Forms)
   - (Optional) ✅ `ASP.NET and Web Development` if needed
5. Click **Install**, then wait for it to finish.
6. Restart your PC if prompted.

---

## ✅ Part 2: Install MySQL (Windows Installer)

🔗 [Download MySQL Installer (64-bit)](https://dev.mysql.com/downloads/file/?id=541637)

1. Download the **MySQL Installer** from the link above.
2. Sign in or create an **Oracle account**.
   - For **Company Name**, enter: `Polytechnic University of the Philippines`
3. Once logged in, the download should begin.
4. Run the installer.
5. Select **Full Setup** to install:
   - MySQL Server
   - MySQL Workbench
   - MySQL .NET Connectors

---

## ✅ Part 3: Clone the Repository

1. Open **Git Bash** or your preferred terminal.
2. Run the following command to clone the repo:

```bash
git clone https://github.com/your-username/your-repo-name.git
`````
`````bash
git fetch --all
git checkout main
git pull origin main
`````
---
## ✅ Part 4: Add Required NuGet Packages

Open Visual Studio and go to:

**Tools > NuGet Package Manager > Package Manager Console**, then run these commands:

```powershell
Install-Package MySql.Data
Install-Package CuoreUI.Winforms
Install-Package LiveChartsCore
Install-Package LiveChartsCore.SkiaSharpView
Install-Package LiveChartsCore.SkiaSharpView.WinForms
`````

---

## 👨‍💻 Project Team

| Name                   | Role                          |
|------------------------|-------------------------------|
| **E-jay P. Detera**    | 👑 Leader, Fullstack Developer |
| **Aliah Del Rosario**  | 🎨 UI Designer, Frontend Developer |
| **Angela Raquedan**    | 🎨 UI Designer, Frontend Developer |
| **Liberty Cañares**    | 💻 Frontend Developer           |
| **Rheana Cerise Aquino** | 🖧 Backend Developer           |
| **Iyah Puso**          | 🖧 Backend Developer           |

---
