using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ServiceModel;
using System.IO;

namespace WalletWebSite
{
    public partial class TransactionForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((Label)transactionform.FindControl("lblStatus")).Visible = false;
            EnableAndDisableControls(false);
            try
            {
                using (WalletService.WalletServiceClient walletServiceClient = new WalletService.WalletServiceClient())
                {
                    //To Get Username
                    string username = string.Empty;
                    string email = Convert.ToString(Session["Email"]);
                    if (!string.IsNullOrEmpty(email))
                    {
                        walletServiceClient.GetUserName(email, out username);
                        ((Label)transactionform.FindControl("lblUserName")).Text = username;
                    }

                    int balance = 0;
                    string strBalance = Convert.ToString(Session["Balance"]);
                    if (string.IsNullOrEmpty(strBalance))
                    {
                        walletServiceClient.ViewBalance(email, out balance);
                        Session["Balance"] = Convert.ToString(balance);
                        ((Label)transactionform.FindControl("lblBalance")).Text = Convert.ToString(balance);
                    }

                }
            }
            catch (FaultException<WalletService.DataConnectionFault> FaultEx)
            {
                Response.Write(FaultEx.Detail.ErrorMessage + FaultEx.Detail.ErrorDetails);
            }
        }

        protected void EnableAndDisableControls(bool value)
        {
            ((Label)transactionform.FindControl("lblFromAccount")).Visible = value;
            ((TextBox)transactionform.FindControl("txtFromAccountNo")).Visible = value;
            ((Label)transactionform.FindControl("lblAmount")).Visible = value;
            ((TextBox)transactionform.FindControl("txtAmount")).Visible = value;
            ((Button)transactionform.FindControl("btnOk")).Visible = value;
            ((Button)transactionform.FindControl("btnCancel")).Visible = value;
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            ((Label)transactionform.FindControl("lblStatus")).Visible = false;
            string email = Session["Email"].ToString();

            string amount = ((TextBox)transactionform.FindControl("txtAmount")).Text;
            string beneficiary = ((Label)transactionform.FindControl("lblFromAccount")).Text;
            try
            {
                if (beneficiary == "To Account")
                {
                    using (WalletService.WalletServiceClient walletServiceClient = new WalletService.WalletServiceClient())
                    {
                        WalletService.DataConnectionFault dataConnectionObj = walletServiceClient.WithdrawFunds(Convert.ToInt32(amount), email);

                        EnableAndDisableControls(false);
                        ((Label)transactionform.FindControl("lblStatus")).Visible = true;
                        ((Label)transactionform.FindControl("lblStatus")).Text = dataConnectionObj.ErrorMessage;

                        int walletBalance = 0;
                        walletServiceClient.ViewBalance(email, out walletBalance);
                        ((Label)transactionform.FindControl("lblBalance")).Text = Convert.ToString(walletBalance);

                        Log(email, "Withdraw");
                    }
                }
                else
                {
                    using (WalletService.WalletServiceClient walletServiceClient = new WalletService.WalletServiceClient())
                    {
                        WalletService.DataConnectionFault dataConnectionObj = walletServiceClient.DepositFunds(Convert.ToInt32(amount), email);

                        EnableAndDisableControls(false);
                        ((Label)transactionform.FindControl("lblStatus")).Visible = true;
                        ((Label)transactionform.FindControl("lblStatus")).Text = dataConnectionObj.ErrorMessage;

                        int walletBalance = 0;
                        walletServiceClient.ViewBalance(email, out walletBalance);
                        ((Label)transactionform.FindControl("lblBalance")).Text = Convert.ToString(walletBalance);
                        Log(email, "Deposit");
                    }
                }
            }
            catch (FaultException<WalletService.DataConnectionFault> FaultEx)
            {
                Response.Write(FaultEx.Detail.ErrorMessage + FaultEx.Detail.ErrorDetails);
            }

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            EnableAndDisableControls(false);
        }

        //View Balance
        protected void Button1_Click(object sender, EventArgs e)
        {
            ((Label)transactionform.FindControl("lblStatus")).Visible = false;
            string email = Convert.ToString(Session["Email"]);
            int balance = 0;
            try
            {
                string strBalance = Convert.ToString(Session["Balance"]);
                if (string.IsNullOrEmpty(strBalance))
                {
                    using (WalletService.WalletServiceClient walletServiceClient = new WalletService.WalletServiceClient())
                    {
                        Log(email, "ViewBalance");
                        walletServiceClient.ViewBalance(email, out balance);
                        Session["Balance"] = Convert.ToString(balance);
                    }
                }
                ((Label)transactionform.FindControl("lblBalance")).Text = Convert.ToString(balance);
            }
            catch (FaultException<WalletService.DataConnectionFault> FaultEx)
            {
                Response.Write(FaultEx.Detail.ErrorMessage + FaultEx.Detail.ErrorDetails);
            }
        }

        //deposit funds
        protected void Button2_Click(object sender, EventArgs e)
        {
            ((Label)transactionform.FindControl("lblStatus")).Visible = false;
            EnableAndDisableControls(true);
            string email = Convert.ToString(Session["Email"]);
            string accountNumber = string.Empty;
            try
            {
                accountNumber = Convert.ToString(Session["AccountNo"]);
                if (string.IsNullOrEmpty(accountNumber))
                {
                    using (WalletService.WalletServiceClient walletServiceClient = new WalletService.WalletServiceClient())
                    {
                        walletServiceClient.GetUserAccount(email, out accountNumber);
                    }
                }
                ((TextBox)transactionform.FindControl("txtFromAccountNo")).Text = accountNumber;
            }
            catch (FaultException<WalletService.DataConnectionFault> FaultEx)
            {
                Response.Write(FaultEx.Detail.ErrorMessage + FaultEx.Detail.ErrorDetails);
            }
        }

        //Withdraw funds
        protected void Button3_Click(object sender, EventArgs e)
        {
            ((Label)transactionform.FindControl("lblStatus")).Visible = false;
            EnableAndDisableControls(true);
            ((Label)transactionform.FindControl("lblFromAccount")).Text = "To Account";
            string email = Session["Email"].ToString();
            //string email = "suzu@gmail.com";
            string accountNumber = string.Empty;
            try
            {
                accountNumber = Convert.ToString(Session["AccountNo"]);
                if (string.IsNullOrEmpty(accountNumber))
                {
                    using (WalletService.WalletServiceClient walletServiceClient = new WalletService.WalletServiceClient())
                    {
                        walletServiceClient.GetUserAccount(email, out accountNumber);
                        Session["AccountNo"] = accountNumber;
                    }
                }
                ((TextBox)transactionform.FindControl("txtFromAccountNo")).Text = accountNumber;
            }
            catch (FaultException<WalletService.DataConnectionFault> FaultEx)
            {
                Response.Write(FaultEx.Detail.ErrorMessage + FaultEx.Detail.ErrorDetails);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            String mail = Convert.ToString(Session["Email"]);
            Log(mail, "LogOut");
            Session.Abandon();
            Session.Clear();
            Response.Redirect("~/MainForm.aspx");
        }

        protected void Log(string email, string operation)
        {
            using (StreamWriter sw = new StreamWriter("C:\\OperationsLog.txt", true))
            {
                sw.WriteLine("{0} :: {1} :: {2}", DateTime.Now, email, operation);
            }
        }
    }
}