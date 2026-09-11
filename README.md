# Toxic People Wallet

A shared wallet and expense-management web application built with **ASP.NET Core MVC**, **Entity Framework Core**, **SQL Server**, and **ASP.NET Core Identity**.

The application is designed for a small group of friends to record deposits and shared expenses, maintain individual balances, and manage wallet activity through an admin approval workflow.

## Live Demo

**AWS Elastic Beanstalk:**  
http://toxicpeoplewallet.ap-south-1.elasticbeanstalk.com

## Features

### Member Features
- Register and log in securely
- View personal wallet balance
- View total group wallet balance
- Submit deposit requests
- Scan a payment QR code before submitting a deposit request
- Enter payment reference number and payment date
- Upload payment proof/screenshot
- Submit withdrawal / expense requests
- View personal transaction history
- View the shared group passbook
- Track pending, approved, and rejected requests

### Admin Features
- Admin dashboard with wallet statistics
- Review pending deposit and withdrawal requests
- Approve or reject transactions
- Add rejection reasons
- View payment proof submitted by members
- View transaction reports
- Manage members
- Enable or disable member accounts
- Safely delete members with no balance and no transaction history
- View member details and transaction history
- View the complete group passbook

## Transaction Workflow

### Deposit
1. Member scans the payment QR code.
2. Member completes the payment externally.
3. Member enters the amount, reference number, and payment date.
4. Member uploads a payment screenshot.
5. Admin verifies the payment.
6. Admin approves the request.
7. Member and group wallet balances are updated.

### Withdrawal / Expense
1. Member submits an expense or withdrawal request.
2. Admin reviews the request.
3. Admin approves or rejects it.
4. Approved transactions reduce the appropriate wallet balance.

> The application is a manual ledger system. It does not connect directly to a bank or payment gateway.

## Tech Stack

- **ASP.NET Core MVC**
- **.NET 9**
- **C#**
- **Entity Framework Core**
- **SQL Server**
- **ASP.NET Core Identity**
- **Razor Views**
- **Bootstrap**
- **HTML5**
- **CSS3**
- **JavaScript**
- **AWS Elastic Beanstalk**
- **Amazon RDS for SQL Server**
- **Amazon S3**
- **Git & GitHub**

## Project Structure

```text
ToxicPeopleWallet
├── Controllers
├── Data
├── Models
│   └── Enums
├── ViewModels
├── Views
│   ├── Admin
│   ├── Transactions
│   ├── Wallet
│   └── Passbook
├── wwwroot
│   ├── images
│   └── uploads
├── Program.cs
├── appsettings.json
└── ToxicPeopleWallet.csproj
```

## Main Models

### ApplicationUser
Extends ASP.NET Core Identity and stores:
- Full name
- Email
- Phone number
- Current wallet balance
- Account status

### WalletTransaction
Stores wallet activity including:
- Member
- Amount
- Transaction type
- Category
- Purpose
- Payment reference
- Payment date
- Screenshot / payment proof
- Approval status
- Approval information
- Rejection reason

### GroupWallet
Stores the current shared wallet balance.

## Roles

The application uses role-based authorization with two roles:

### Admin
Can manage users, approve or reject requests, view reports, and monitor wallet activity.

### Member
Can submit transactions and view wallet information and transaction history.

## Database

The project uses **Entity Framework Core with SQL Server**.

For local development, update the `DefaultConnection` connection string in `appsettings.json` or use a secure local configuration method.

Then apply migrations:

```bash
dotnet ef database update
```

## Run Locally

### 1. Clone the repository

```bash
git clone https://github.com/Prajithtp/ToxicPeopleWallet.git
```

### 2. Open the project folder

```bash
cd ToxicPeopleWallet
```

### 3. Restore packages

```bash
dotnet restore
```

### 4. Configure the database connection

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=ToxicPeopleWalletDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
}
```

### 5. Apply migrations

```bash
dotnet ef database update
```

### 6. Run the application

```bash
dotnet run --project ToxicPeopleWallet
```

You can also open the solution in **Visual Studio 2022** and run it from there.

## Security Notes

- Passwords are handled using ASP.NET Core Identity.
- Admin-only pages use role-based authorization.
- Transaction approval is restricted to administrators.
- Deposit proof uploads are validated by file type and size.
- Sensitive production credentials are not stored in this repository.
- AWS database credentials should be configured through environment variables or another secure secrets mechanism.

## Deployment

The application is deployed on AWS using:
- **Elastic Beanstalk** for the ASP.NET Core application
- **Amazon RDS SQL Server Express** for the production database
- **Amazon S3** for Elastic Beanstalk deployment packages

## Current Version

### Version 3
Recent improvements include:
- Fixed Admin Dashboard Passbook navigation
- Added payment QR code to the Deposit Request page
- Added safe member deletion
- Improved responsive Admin and Member interfaces
- Enhanced transaction and user-management workflows

## Future Improvements

- HTTPS with a custom domain
- Cloud-based storage for uploaded payment screenshots
- Email notifications
- Better audit logging
- Export reports to PDF or Excel
- Improved dashboard charts
- Automated CI/CD deployment
- Payment gateway integration

## Author

**Prajith TP**  
.NET / Full-Stack Developer

GitHub: https://github.com/Prajithtp

## License

This project was created for learning, portfolio, and small-group wallet-management purposes.
