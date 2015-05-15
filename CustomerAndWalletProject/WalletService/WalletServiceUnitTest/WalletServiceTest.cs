using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WalletService;

namespace WalletServiceUnitTest
{
    [TestClass]
    public class WalletServiceTest
    {
        [TestMethod]
        public void Login_EmptyCredentialsTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = false;
            expectedFaultDetails.ErrorMessage = "Invalid User or Password";
            string email = string.Empty;
            string password = string.Empty;

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.Login(email, password);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
        }

        [TestMethod]
        public void Login_ValidCredentialsTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = true;
            expectedFaultDetails.ErrorMessage = "Valid User";
            string email = "dolly.suzi@gmail.com";
            string password = "MOTHER";

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.Login(email, password);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
        }

        [TestMethod]
        public void Login_ValidEmailandInvalidPasswordTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = false;
            expectedFaultDetails.ErrorMessage = "Invalid User or Password";
            string email = "dolly.suzi@gmail.com";
            string password = "invalid";

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.Login(email, password);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
        }

        [TestMethod]
        public void NewUser_ValidCredentialsTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = true;
            expectedFaultDetails.ErrorMessage = "User Added Successfully";
            string email = "dolly.suzi@gmail.com";
            string password = "MOTHER";
            string name = "suzi";
            int phone = 99;
            string bankAccNo = "700-08921";

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.NewUser(email, password, name, phone, bankAccNo);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
        }

        [TestMethod]
        public void DepositFunds_SuccessfulTransferredTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = true;
            expectedFaultDetails.ErrorMessage = "Fund has been transferred successfully";
            string email = "dolly.suzi@gmail.com";
            int amount = 100;

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.DepositFunds(amount, email);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
        }

        [TestMethod]
        public void DepositFunds_InSufficientFundsTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = false;
            expectedFaultDetails.ErrorMessage = "Insufficient funds.";
            string email = "dolly.suzi@gmail.com";
            int amount = 1000;

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.DepositFunds(amount, email);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
        }

        [TestMethod]
        public void WithdrawFunds_SuccessfulWithdrawTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = true;
            expectedFaultDetails.ErrorMessage = "Successful Withdrawal of funds";
            string email = "dolly.suzi@gmail.com";
            int amount = 100;

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.WithdrawFunds(amount, email);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
        }

        [TestMethod]
        public void WithdrawFunds_InSufficientFundsTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = false;
            expectedFaultDetails.ErrorMessage = "Insufficient funds.";
            string email = "dolly.suzi@gmail.com";
            int amount = 1000;

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.WithdrawFunds(amount, email);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
        }

        [TestMethod]
        public void ViewBalance_ValidCredentialsTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = true;
            expectedFaultDetails.ErrorMessage = "Balance Retrieved Successfully";
            string email = "dolly.suzi@gmail.com";
            int actualBalance = 0;
            int expectedBalance = 100;

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.ViewBalance(email, out actualBalance);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
            Assert.AreEqual(expectedBalance, actualBalance);
        }

        [TestMethod]
        public void ViewBalance_InValidCredentialsTest()
        {
            var target = new WalletService.WalletService();
            DataConnectionFault expectedFaultDetails = new DataConnectionFault();
            expectedFaultDetails.Result = false;
            expectedFaultDetails.ErrorMessage = "Invalid Email";
            string email = "dolly.suzi@gmail.co";
            int actualBalance = 0;
            int expectedBalance = 0;

            DataConnectionFault actualFaultDetails = new DataConnectionFault();
            actualFaultDetails = target.ViewBalance(email, out actualBalance);

            Assert.AreEqual(expectedFaultDetails.Result, actualFaultDetails.Result);
            Assert.AreEqual(expectedFaultDetails.ErrorMessage, actualFaultDetails.ErrorMessage);
            Assert.AreEqual(expectedBalance, actualBalance);
        }
    }
}
