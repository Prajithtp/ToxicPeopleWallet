# 💰 Toxic People Wallet

**Toxic People Wallet** is a shared wallet and expense tracking web application built using **ASP.NET Core MVC**.

The application allows a group of friends to maintain a shared wallet, submit deposit and expense requests, track individual contributions, and view the complete group transaction history.

An administrator reviews and approves or rejects transaction requests before they affect wallet balances.

---

## ✨ Features

### 👤 Member

- Register and login securely
- View personal wallet dashboard
- View group wallet balance
- Submit deposit requests
- Upload payment proof for deposits
- Submit expense/withdrawal requests
- Track pending, approved, and rejected transactions
- View personal transaction history
- View group passbook
- View member contribution details

### 🛡️ Admin

- Dedicated admin dashboard
- View group wallet statistics
- Review pending transaction requests
- Preview deposit payment proofs
- Approve deposit and expense requests
- Reject requests with a reason
- View reports and transaction history
- View member wallet details
- Enable or disable member accounts
- Monitor member contributions and balances

---

## 💳 Transaction Workflow

### Deposit

```text
Member submits deposit
        ↓
Deposit becomes Pending
        ↓
Admin verifies payment proof
        ↓
Admin approves request
        ↓
Member balance increases
        ↓
Group wallet balance increases
```

### Expense

```text
Member submits expense
        ↓
Expense becomes Pending
        ↓
Admin reviews request
        ↓
Admin approves request
        ↓
Member balance decreases
        ↓
Group wallet balance decreases
```

Rejected requests do not modify wallet balances.

---

## 🛠️ Technologies Used

- ASP.NET Core MVC
- C#
- .NET 9
- Entity Framework Core
- ASP.NET Core Identity
- SQL Server
- LINQ
- Razor Views
- HTML5
- CSS3
- Bootstrap
- Bootstrap Icons
- JavaScript
- Visual Studio 2022

---

## 🏗️ Project Structure

```text
ToxicPeopleWallet
│
├── Controllers
├── Data
├── Migrations
├── Models
│   └── Enums
├── ViewModels
├── Views
├── wwwroot
│   ├── css
│   └── js
│
├── Program.cs
├── appsettings.json
└── ToxicPeopleWallet.csproj
```

---

## 🔐 Authentication & Authorization

The project uses **ASP.NET Core Identity** for authentication and role-based authorization.

Two roles are available:

- **Admin**
- **Member**

Admin-only functionality is protected using role-based authorization.

---

## 🗄️ Database

The application uses **SQL Server** with **Entity Framework Core**.

Main application entities include:

- ApplicationUser
- WalletTransaction
- GroupWallet

Transaction states include:

- Pending
- Approved
- Rejected

Transaction types include:

- Deposit
- Withdrawal

---

## 🚀 Getting Started

### 1. Clone the repository

```bash
git clone https://github.com/Prajithtp/ToxicPeopleWallet.git
```

### 2. Open the project

Open the solution/project using **Visual Studio 2022**.

### 3. Configure SQL Server

The development configuration uses SQL Server Express.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=ToxicPeopleWalletDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

Change the connection string if your SQL Server configuration is different.

### 4. Restore packages

Visual Studio normally restores the required NuGet packages automatically.

Alternatively:

```bash
dotnet restore
```

### 5. Create the database

Using Visual Studio Package Manager Console:

```powershell
Update-Database
```

Or using the .NET CLI:

```bash
dotnet ef database update
```

### 6. Run the application

Using Visual Studio:

```text
Ctrl + F5
```

Or:

```bash
dotnet run
```

---

## 📱 Responsive Design

The application includes a responsive interface designed for:

- Desktop
- Tablet
- Mobile

It includes a responsive sidebar, dashboards, cards, forms, transaction tables, reports, and administrative pages.

---

## 📌 Project Purpose

This project was developed as a portfolio project to demonstrate practical experience with:

- ASP.NET Core MVC architecture
- Entity Framework Core
- SQL Server database operations
- ASP.NET Core Identity
- Role-based authorization
- CRUD operations
- File uploads
- Transaction approval workflows
- LINQ
- Razor Views
- Responsive UI development

---

## ⚠️ Disclaimer

This application is a **portfolio/demo project**.

Wallet transactions are recorded manually and the application is not connected to a real banking or payment gateway system.

---

## 👨‍💻 Developer

**Prajith TP**

.NET Full Stack Developer

Technologies: C#, ASP.NET Core MVC, Entity Framework Core, SQL Server, HTML, CSS, JavaScript and Angular.