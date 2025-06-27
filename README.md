# MareKwenta POS System

MareKwenta is a custom-built Point-of-Sale (POS) system designed for Mare Café in Caloocan City. It addresses the high costs of third-party POS subscriptions by offering an in-house, fully functional solution tailored to small business needs — with the long-term goal of supporting other startups at no cost.

## 📌 Project Description

MareKwenta streamlines key café operations such as:
- Order processing
- Sales tracking
- Inventory management

The system improves efficiency, accountability, and decision-making by providing staff with simple tools and owners with actionable insights.

## 🎯 Goals

- Eliminate subscription-based POS costs
- Simplify sales and inventory workflows
- Enhance employee accountability
- Create a scalable system for other cafés and small businesses

## 💡 Planned Features

### 👥 Employee System
- Secure login with webcam photo and timestamp
- Password-protected access
- Logs for time-in/out and break durations
- Future support for role-based access (Admin, Cashier, Staff)

### 🧾 Ticketing & Sales
- Fast product selection and ticket creation
- Real-time order updates
- Discount & multiple payment support
- Auto-change calculation

### 📜 Sales History
- Filter by date/time
- View full ticket details (items, payments, discounts)

### 📦 Inventory Management
- Track stock levels in real time
- Alerts for low or expiring ingredients
- Manage fast/slow-moving items
- Easy ingredient updates

### 💰 Cash Drawer
- Track daily cash/card/other payment flows
- Record café-related expenses for net revenue

### 📊 Summary Dashboard
- Visual analytics on:
  - Best-sellers
  - Peak hours
  - Payment trends
  - Revenue summaries (daily/weekly/monthly)

## 🛠️ Tools & Technologies

- **Language:** C#
- **Framework:** .NET (Windows Forms)
- **IDE:** Visual Studio
- **Database:** Microsoft SQL Server
- **Version Control:** Git

## 🚀 Expected Output

1. **Login Screen** – Includes webcam prompt and timestamp
2. **Main Dashboard** – Displays:
   - Product list & ticket panel
   - Navigation icons for:
     - Employee Logs
     - Sales History
     - Cash Drawer
     - Inventory
     - Dashboard Analytics

## 🔐 Security & Data Integrity

- Passwords stored securely with hashing
- Admin-only access to sensitive features
- Regular database backups (with optional future cloud sync)

## 📈 Scalability & Future Enhancements

- Multi-branch support
- Remote monitoring via web access
- Receipt printer and barcode scanner integration
- PWA or full Web App version
- Cloud-based analytics and dashboards

---
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
git clone https://github.com/ejay-detera/MareKwenta-POS.git
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
- Or You can use Tools > NuGet Package Manager > Manage NuGet Package For Solution....
Then search for the needed packages.
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

