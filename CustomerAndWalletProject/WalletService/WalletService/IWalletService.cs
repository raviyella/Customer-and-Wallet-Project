using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using System.ServiceModel.Activation;

namespace WalletService
{
    [ServiceContract]
    interface IWalletService
    {
        [OperationContract]
        [FaultContract(typeof(DataConnectionFault))]
        DataConnectionFault Login(string email, string pwd);

        [OperationContract]
        [FaultContract(typeof(DataConnectionFault))]
        DataConnectionFault NewUser(string email, string pwd, string name, int phone, string bankAccNo);

        [OperationContract]
        [FaultContract(typeof(DataConnectionFault))]
        DataConnectionFault DepositFunds(int amount, string email);

        [OperationContract]
        [FaultContract(typeof(DataConnectionFault))]
        DataConnectionFault WithdrawFunds(int amount, string email);

        [OperationContract]
        [FaultContract(typeof(DataConnectionFault))]
        DataConnectionFault ViewBalance(string email, out int balance);

        [OperationContract]
        [FaultContract(typeof(DataConnectionFault))]
        DataConnectionFault GetUserName(string email, out string username);
        
        [OperationContract]
        [FaultContract(typeof(DataConnectionFault))]
        DataConnectionFault GetUserAccount(string email, out string accountNumber);

        [OperationContract]
        [FaultContract(typeof(DataConnectionFault))]
        DataConnectionFault GetAccountBalance(string account, out int walletBalance, out int bankAccountBalance);

        //[OperationContract]
        //[FaultContract(typeof(DataConnectionFault))]
        //int Logout();
        string EncryptPassword(string password);

        string DecryptPassword(string password);

        [OperationContract]
        string GetName();

        [OperationContract]
        string GetName1(string name);
    }

    [DataContract]
    public class DataConnectionFault
    {
        [DataMember]
        public bool Result { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public string ErrorDetails { get; set; }
    }
}
