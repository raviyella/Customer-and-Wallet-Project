using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.ServiceModel;
using System.IO;

namespace WalletWebSite
{
    public partial class MainForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (WalletService.WalletServiceClient walletServiceClient = new WalletService.WalletServiceClient())
            {
                string email = ((TextBox)form1.FindControl("txtEmailId")).Text;
                string password = ((TextBox)form1.FindControl("txtPassword")).Text;

                try
                {
                    if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
                    {
                        Log(email, "Login");

                        Session["Email"] = email;
                        WalletService.DataConnectionFault dataConnectionObj = walletServiceClient.Login(email, password);

                        Response.Redirect("TransactionForm.aspx");
                    }
                    else
                    {
                        ((Label)form1.FindControl("lblStatus")).Text = "Email or Password is blank. Please Re-Enter";
                    }
                }
                catch (FaultException<WalletService.DataConnectionFault> FaultEx)
                {
                    ((Label)form1.FindControl("lblStatus")).Text = FaultEx.Detail.ErrorMessage + FaultEx.Detail.ErrorDetails;
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("LoginForm.aspx");
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