using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Data;
using System.Data.SqlClient;
using System.ServiceModel.Activation;

namespace WalletService
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WalletService:IWalletService
    {
        /// <summary>
        /// Existing Customer Login 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>        
        /// <returns>DataConnectionFault Details</returns>
        public DataConnectionFault Login(string email, string pwd)
        {
            string connectionString = string.Empty;
            string query = string.Empty;
            //Connection string
            connectionString = "Data source =.;Integrated Security=SSPI;database=Wallet";
            
            //Query to insert new customer details
            query = "select pwd from dbo.TBLWALLET where emailid=@EMAILID";
            
            DataConnectionFault dataConnectionFault = new DataConnectionFault();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@EMAILID", email);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {                        
                        if( reader.HasRows )
                        {
                            while (reader.Read())
                            {
                                string password = DecryptPassword(Convert.ToString(reader["PWD"]));
                                int passwordMatch = string.Compare(pwd, password);
                                if (0 == passwordMatch)
                                {
                                    dataConnectionFault.Result = true;
                                    dataConnectionFault.ErrorMessage = "Valid User";
                                }
                                else
                                {
                                    dataConnectionFault.Result = false;
                                    dataConnectionFault.ErrorMessage = "Invalid User or Password";
                                }
                            }
                        }
                        else
                        {
                            dataConnectionFault.Result = false;
                            dataConnectionFault.ErrorMessage = "Invalid User or Password";
                            return dataConnectionFault;
                        }                        
                    }
                    
                    return dataConnectionFault;
                }
            }
            catch (SqlException sqlEx)
            {
                dataConnectionFault.Result = false;
                dataConnectionFault.ErrorMessage = "Login Failed:: ";
                dataConnectionFault.ErrorDetails = sqlEx.ToString();
                throw new FaultException<DataConnectionFault>(dataConnectionFault, sqlEx.ToString());
            }                        
        }

        /// <summary>
        /// Register New Customer
        /// </summary>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <param name="name"></param>
        /// <param name="phone"></param>
        /// <param name="bankAccNo"></param>
        /// <returns>DataConnectionFault Details</returns>
        public DataConnectionFault NewUser(string email, string pwd, string name, int phone, string bankAccNo )
        {            
            string connectionString = string.Empty;
            string query = string.Empty;

            //Connection string
            connectionString = "Data source =.;Integrated Security=SSPI;database=Wallet";

            string password = EncryptPassword(pwd);

            //Query to insert new customer details
            query = "INSERT INTO dbo.TBLWALLET(EMAILID, PWD, NAME, PHONE, BANKACCNO, WALLETBAL) VALUES(@email, @pwd, @name, @phone, @bankaccno, @walletbal)";

            DataConnectionFault dataConnectionFault = new DataConnectionFault();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@pwd", password);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@bankaccno", bankAccNo);
                    cmd.Parameters.AddWithValue("@walletbal", 100);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    dataConnectionFault.Result = true;
                    dataConnectionFault.ErrorMessage = "User Added Successfully";

                    DepositAmountToBank(connectionString, email, bankAccNo);
                    return dataConnectionFault;
                }
            }
            catch (SqlException sqlEx)
            {
                dataConnectionFault.Result = false;
                dataConnectionFault.ErrorMessage = "Connection to Database Failed:: ";
                dataConnectionFault.ErrorDetails = sqlEx.ToString();
                throw new FaultException<DataConnectionFault>(dataConnectionFault, sqlEx.ToString());
            }            
        }

        /// <summary>
        /// Deposit funds to Customer's Bank Account
        /// </summary>
        /// <param name="connectionString"></param>
        /// <param name="email"></param>
        /// <param name="bankAccNo"></param>
        /// <returns>DataConnectionFault Details</returns>
        public DataConnectionFault DepositAmountToBank(string connectionString, string email, string bankAccNo)
        {
            //Query to deposit balance into Customer Account
            string query = "INSERT INTO dbo.tblCustomerAccount(ACCOUNTNO, BALANCE, EMAILID) VALUES(@acno, @bal, @email)";

            DataConnectionFault dataConnectionFault = new DataConnectionFault();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@acno", bankAccNo);
                    cmd.Parameters.AddWithValue("@bal", 1000);
                    cmd.Parameters.AddWithValue("@email", email);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    dataConnectionFault.Result = true;
                    dataConnectionFault.ErrorMessage = "Funds deposited";
                    return dataConnectionFault;
                }
            }
            catch (SqlException sqlEx)
            {
                dataConnectionFault.Result = false;
                dataConnectionFault.ErrorMessage = "Connection to Database Failed:: ";
                dataConnectionFault.ErrorDetails = sqlEx.ToString();
                throw new FaultException<DataConnectionFault>(dataConnectionFault, sqlEx.ToString());
            }            
        }

        /// <summary>
        /// Deposit funds to Customer's Wallet
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="email"></param>
        /// <returns>DataConnectionFault Details</returns>
        public DataConnectionFault DepositFunds(int amount, string email)
        {
            string connectionString = string.Empty;

            //Connection string
            connectionString = "Data source =.;Integrated Security=SSPI;database=Wallet";

            DataConnectionFault dataConnectionFault = new DataConnectionFault();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spDepositFunds", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    cmd.Parameters.AddWithValue("@AMOUNT", amount);
                    cmd.Parameters.AddWithValue("@EMAILID", email);
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    Console.WriteLine("Ret = {0}", result.ToString());
                    int depositStatus = Convert.ToInt32(result);
                    if (1 == depositStatus) //Deposit Success
                    {
                        dataConnectionFault.Result = true;
                        dataConnectionFault.ErrorMessage = "Fund has been transferred successfully";
                    }
                    else 
                    {
                        dataConnectionFault.Result = false;
                        dataConnectionFault.ErrorMessage = "Insufficient funds.";
                    }
                    
                    return dataConnectionFault;
                }
            }
            catch (SqlException sqlEx)
            {
                dataConnectionFault.Result = false;
                dataConnectionFault.ErrorMessage = "Fund Transfer has been Failed:: ";
                dataConnectionFault.ErrorDetails = sqlEx.ToString();
                throw new FaultException<DataConnectionFault>(dataConnectionFault, sqlEx.ToString());
            }            
        }

        /// <summary>
        /// Withdraw funds from Customer's Wallet
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="email"></param>
        /// <returns>DataConnectionFault Details</returns>
        public DataConnectionFault WithdrawFunds(int amount, string email)
        {
            string connectionString = string.Empty;

            //Connection string
            connectionString = "Data source =.;Integrated Security=SSPI;database=Wallet";

            DataConnectionFault dataConnectionFault = new DataConnectionFault();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spWithdrawFunds", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter();
                    cmd.Parameters.AddWithValue("@AMOUNT", amount);
                    cmd.Parameters.AddWithValue("@EMAILID", email);
                    var returnParameter = cmd.Parameters.Add("@ReturnVal", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    var result = returnParameter.Value;
                    Console.WriteLine("Ret = {0}", result.ToString());
                    int depositStatus = Convert.ToInt32(result);
                    if (1 == depositStatus) //Withdraw Success
                    {
                        dataConnectionFault.Result = true;
                        dataConnectionFault.ErrorMessage = "Successful Withdrawal of funds";
                    }
                    else
                    {
                        dataConnectionFault.Result = false;
                        dataConnectionFault.ErrorMessage = "Insufficient funds.";
                    }

                    return dataConnectionFault;
                }
            }
            catch (SqlException sqlEx)
            {
                dataConnectionFault.Result = false;
                dataConnectionFault.ErrorMessage = "Fund Withdrawal has been Failed:: ";
                dataConnectionFault.ErrorDetails = sqlEx.ToString();
                throw new FaultException<DataConnectionFault>(dataConnectionFault, sqlEx.ToString());
            }            
            
        }

        /// <summary>
        /// View Customer's Wallet Balance
        /// </summary>
        /// <param name="email"></param>
        /// <param name="balance"></param>
        /// <returns></returns>
        public DataConnectionFault ViewBalance(string email, out int balance)
        {
            balance = 0;
         
            string connectionString = string.Empty;
            string query = string.Empty;

            //Connection string
            connectionString = "Data source =.;Integrated Security=SSPI;database=Wallet";

            //Query to insert new customer details
            query = "select walletbal from dbo.TBLWALLET where emailid=@EMAILID";

            DataConnectionFault dataConnectionFault = new DataConnectionFault();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@EMAILID", email);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                balance = Convert.ToInt32(reader["walletbal"]);
                                dataConnectionFault.Result = true;
                                dataConnectionFault.ErrorMessage = "Balance Retrieved Successfully";
                            }
                        }
                        else
                        {
                            dataConnectionFault.Result = false;
                            dataConnectionFault.ErrorMessage = "Invalid Email";
                            return dataConnectionFault;
                        }    
                    }

                    return dataConnectionFault;
                }
            }
            catch (SqlException sqlEx)
            {
                dataConnectionFault.Result = false;
                dataConnectionFault.ErrorMessage = "Unable to Retrieve Balance:: ";
                dataConnectionFault.ErrorDetails = sqlEx.ToString();
                throw new FaultException<DataConnectionFault>(dataConnectionFault, sqlEx.ToString());
            }                  
        }

        /// <summary>
        /// GetUserName
        /// </summary>
        /// <param name="email"></param>
        /// <param name="username"></param>
        /// <returns>DataConnectionFault Details</returns>
        public DataConnectionFault GetUserName(string email, out string username)
        {
            username = string.Empty;

            string connectionString = string.Empty;
            string query = string.Empty;

            //Connection string
            connectionString = "Data source =.;Integrated Security=SSPI;database=Wallet";

            //Query to insert new customer details
            query = "select name from dbo.TBLWALLET where emailid=@EMAILID";

            DataConnectionFault dataConnectionFault = new DataConnectionFault();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@EMAILID", email);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            username= Convert.ToString(reader["name"]);
                        }
                    }

                    dataConnectionFault.Result = true;
                    return dataConnectionFault;
                }
            }
            catch (SqlException sqlEx)
            {
                dataConnectionFault.Result = false;
                dataConnectionFault.ErrorMessage = "Unable to Retrieve username:: ";
                dataConnectionFault.ErrorDetails = sqlEx.ToString();
                throw new FaultException<DataConnectionFault>(dataConnectionFault, sqlEx.ToString());
            }
        }

        /// <summary>
        /// Get User Account Number
        /// </summary>
        /// <param name="email"></param>
        /// <param name="accountNumber"></param>
        /// <returns>DataConnectionFault Details</returns>
        public DataConnectionFault GetUserAccount(string email, out string accountNumber)
        {
            accountNumber = string.Empty;

            string connectionString = string.Empty;
            string query = string.Empty;

            //Connection string
            connectionString = "Data source =.;Integrated Security=SSPI;database=Wallet";

            //Query to insert new customer details
            query = "select bankaccno from dbo.TBLWALLET where emailid=@EMAILID";

            DataConnectionFault dataConnectionFault = new DataConnectionFault();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@EMAILID", email);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            accountNumber = Convert.ToString(reader["bankaccno"]);
                        }
                    }

                    dataConnectionFault.Result = true;
                    return dataConnectionFault;
                }
            }
            catch (SqlException sqlEx)
            {
                dataConnectionFault.Result = false;
                dataConnectionFault.ErrorMessage = "Unable to Retrieve Bank Account:: ";
                dataConnectionFault.ErrorDetails = sqlEx.ToString();
                throw new FaultException<DataConnectionFault>(dataConnectionFault, sqlEx.ToString());
            }
        }

        /// <summary>
        /// Get User Account Balance
        /// </summary>
        /// <param name="account"></param>
        /// <param name="walletBalance"></param>
        /// <param name="bankAccountBalance"></param>
        /// <returns>DataConnectionFault Details</returns>
        public DataConnectionFault GetAccountBalance(string account, out int walletBalance, out int bankAccountBalance)
        {
            walletBalance = 0;
            bankAccountBalance = 0;
            
            string connectionString = string.Empty;
            string query = string.Empty;

            //Connection string
            connectionString = "Data source =.;Integrated Security=SSPI;database=Wallet";

            query = "SELECT tblCustomerAccount.BALANCE, tblWallet.WALLETBAL FROM tblCustomerAccount, TBLWALLET WHERE tblCustomerAccount.EMAILID = TBLWALLET.EMAILID AND tblWallet.BANKACCNO = @bankaccno";


            DataConnectionFault dataConnectionFault = new DataConnectionFault();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@bankaccno", account);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            bankAccountBalance = Convert.ToInt32(reader["balance"]);
                            walletBalance = Convert.ToInt32(reader["walletbal"]);
                        }
                    }

                    dataConnectionFault.Result = true;
                    return dataConnectionFault;
                }
            }
            catch (SqlException sqlEx)
            {
                dataConnectionFault.Result = false;
                dataConnectionFault.ErrorMessage = "Unable to Retrieve Wallet and Bank Accounts Balance:: ";
                dataConnectionFault.ErrorDetails = sqlEx.ToString();
                throw new FaultException<DataConnectionFault>(dataConnectionFault, sqlEx.ToString());
            }
        }

        /// <summary>
        /// Encrypt the password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Encrypted password</returns>
        public string EncryptPassword(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }

        /// <summary>
        /// Decrypt the password
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Decrypted password</returns>
        public string DecryptPassword(string password)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(password);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }


        public string GetName()
        {
            return "Ravi Yella";
        }

        public string GetName1(string name)
        {
            return "Hello " + name;
        }

    }
}
