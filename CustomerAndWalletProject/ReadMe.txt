
Environment:
Microsoft SQL Server 2008
Microsoft Visual Studio Express 2013 for Web
Internet Information Service 7.5

Synopsis:
A WCF Service has been created that exposes business logic functionalities like ‘View Balance’, ‘Deposit Funds’, and ‘Withdraw Funds’. The WCF Service has been hosted in IIS. A Web application has been created consuming WCF Service that gives Signup, Login, View Balance, Deposit Funds, Withdraw Funds UI. All these customer details are stored in Sql database. Added couple of tables and stored procedures to handle database operations. Added logging mechanism for each operation. Also handled exception in WCF service code base. Added unit test project to test the functionality.

Installation Steps:
1. Open SQL Server Management Studio and Connect to server using Windows Authentication.

2. Create a Database ‘Wallet’.

3. Open ‘CreateTable.sql’ file and press Execute button to create two tables ‘tblWallet’, ‘tblCustomerAccount’ respectively.

4. Open ‘DepositFunds_Stored Procedure.sql’ and ‘WithdrawFunds_Stored Procedure.sql’ files and press Execute button to create two stored procedures ‘spDepositFunds’ and ‘spWithdrawFunds’.

5. Copy ‘WalletService’ and ‘WalletWebSite’ folders to any location say ‘C:\Betsson Project’.

6.Open IIS Manager, right click on ‘Default Web site’ and select ‘Add Application’. In ‘Add Application’ dialog box, select ‘ApplicationPool’ to ‘ASP.NET v4.0’ and enter ‘Alias’ and ‘Physical path’ of ‘C:\Betsson Project\WalletService\WalletServiceIISHost’ project and click OK.

7. Add Virtual directory in IIS, enter ‘Alias’ and ‘Physical path’ of ‘C:\Betsson  Project\WalletWebSite\WalletWebSite’

8. Provide necessary permissions to ‘C:\Betsson Project’.

9. Go to Web browser and enter the address ‘http://localhost:2256/MainForm.aspx’ and perform ‘Signup’/’Login’ operations.

10. All these operations will be logged in a text file at “C:\ OperationsLog.txt”.

//End
//THE END
