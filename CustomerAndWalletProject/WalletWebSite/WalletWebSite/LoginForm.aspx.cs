using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ServiceModel;
using System.IO;

namespace WalletWebSite
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            using (WalletService.WalletServiceClient walletServiceClient = new WalletService.WalletServiceClient())
            {
                string email = ((TextBox)NewUserForm.FindControl("txtEmail")).Text;
                string password = ((TextBox)NewUserForm.FindControl("txtPwd")).Text;
                string username = ((TextBox)NewUserForm.FindControl("txtUserName")).Text;
                string phone = ((TextBox)NewUserForm.FindControl("txtPhone")).Text;
                string bankAccountNumber = ((TextBox)NewUserForm.FindControl("txtBankAccNo")).Text;

                if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password) ||
                    !string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(phone) ||
                    !string.IsNullOrEmpty(bankAccountNumber))
                {
                    try
                    {
                        WalletService.DataConnectionFault dataConnectionObj =
                        walletServiceClient.NewUser(email, password, username, Convert.ToInt32(phone), bankAccountNumber);

                        if (dataConnectionObj.Result == true)
                        {
                            Log(email, "New User");
                            Session["Email"] = email;
                            HtmlMeta meta = new HtmlMeta();
                            meta.HttpEquiv = "Refresh";
                            meta.Content = "5;url=MainForm.aspx";
                            this.Page.Controls.Add(meta);
                            ((Label)NewUserForm.FindControl("lblStatus")).Text = dataConnectionObj.ErrorMessage + " You will now be redirected to Login Screen in 5 seconds";
                        }
                        else
                        {
                            ((Label)NewUserForm.FindControl("lblStatus")).Text = dataConnectionObj.ErrorMessage;
                        }
                    }
                    catch (FaultException<WalletService.DataConnectionFault> FaultEx)
                    {
                        ((Label)NewUserForm.FindControl("lblStatus")).Text = FaultEx.Detail.ErrorMessage + FaultEx.Detail.ErrorDetails;
                    }
                }
                else
                {
                    ((Label)NewUserForm.FindControl("lblStatus")).Text = "Details cannot be Empty";
                }
            }

        }

        //Reset the controls
        protected void Button2_Click(object sender, EventArgs e)
        {
            ((TextBox)NewUserForm.FindControl("txtEmail")).Text = "";
            ((TextBox)NewUserForm.FindControl("txtPwd")).Text = "";
            ((TextBox)NewUserForm.FindControl("txtUserName")).Text = "";
            ((TextBox)NewUserForm.FindControl("txtPhone")).Text = "";
            ((TextBox)NewUserForm.FindControl("txtBankAccNo")).Text = "";

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