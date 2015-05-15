﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WalletWebSite.WalletService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="DataConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/WalletService")]
    [System.SerializableAttribute()]
    public partial class DataConnectionFault : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorDetailsField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool ResultField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorDetails {
            get {
                return this.ErrorDetailsField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorDetailsField, value) != true)) {
                    this.ErrorDetailsField = value;
                    this.RaisePropertyChanged("ErrorDetails");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Result {
            get {
                return this.ResultField;
            }
            set {
                if ((this.ResultField.Equals(value) != true)) {
                    this.ResultField = value;
                    this.RaisePropertyChanged("Result");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="WalletService.IWalletService")]
    public interface IWalletService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/Login", ReplyAction="http://tempuri.org/IWalletService/LoginResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WalletWebSite.WalletService.DataConnectionFault), Action="http://tempuri.org/IWalletService/LoginDataConnectionFaultFault", Name="DataConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/WalletService")]
        WalletWebSite.WalletService.DataConnectionFault Login(string email, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/Login", ReplyAction="http://tempuri.org/IWalletService/LoginResponse")]
        System.Threading.Tasks.Task<WalletWebSite.WalletService.DataConnectionFault> LoginAsync(string email, string pwd);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/NewUser", ReplyAction="http://tempuri.org/IWalletService/NewUserResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WalletWebSite.WalletService.DataConnectionFault), Action="http://tempuri.org/IWalletService/NewUserDataConnectionFaultFault", Name="DataConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/WalletService")]
        WalletWebSite.WalletService.DataConnectionFault NewUser(string email, string pwd, string name, int phone, string bankAccNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/NewUser", ReplyAction="http://tempuri.org/IWalletService/NewUserResponse")]
        System.Threading.Tasks.Task<WalletWebSite.WalletService.DataConnectionFault> NewUserAsync(string email, string pwd, string name, int phone, string bankAccNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/DepositFunds", ReplyAction="http://tempuri.org/IWalletService/DepositFundsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WalletWebSite.WalletService.DataConnectionFault), Action="http://tempuri.org/IWalletService/DepositFundsDataConnectionFaultFault", Name="DataConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/WalletService")]
        WalletWebSite.WalletService.DataConnectionFault DepositFunds(int amount, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/DepositFunds", ReplyAction="http://tempuri.org/IWalletService/DepositFundsResponse")]
        System.Threading.Tasks.Task<WalletWebSite.WalletService.DataConnectionFault> DepositFundsAsync(int amount, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/WithdrawFunds", ReplyAction="http://tempuri.org/IWalletService/WithdrawFundsResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WalletWebSite.WalletService.DataConnectionFault), Action="http://tempuri.org/IWalletService/WithdrawFundsDataConnectionFaultFault", Name="DataConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/WalletService")]
        WalletWebSite.WalletService.DataConnectionFault WithdrawFunds(int amount, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/WithdrawFunds", ReplyAction="http://tempuri.org/IWalletService/WithdrawFundsResponse")]
        System.Threading.Tasks.Task<WalletWebSite.WalletService.DataConnectionFault> WithdrawFundsAsync(int amount, string email);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/ViewBalance", ReplyAction="http://tempuri.org/IWalletService/ViewBalanceResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WalletWebSite.WalletService.DataConnectionFault), Action="http://tempuri.org/IWalletService/ViewBalanceDataConnectionFaultFault", Name="DataConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/WalletService")]
        WalletWebSite.WalletService.ViewBalanceResponse ViewBalance(WalletWebSite.WalletService.ViewBalanceRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/ViewBalance", ReplyAction="http://tempuri.org/IWalletService/ViewBalanceResponse")]
        System.Threading.Tasks.Task<WalletWebSite.WalletService.ViewBalanceResponse> ViewBalanceAsync(WalletWebSite.WalletService.ViewBalanceRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/GetUserName", ReplyAction="http://tempuri.org/IWalletService/GetUserNameResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WalletWebSite.WalletService.DataConnectionFault), Action="http://tempuri.org/IWalletService/GetUserNameDataConnectionFaultFault", Name="DataConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/WalletService")]
        WalletWebSite.WalletService.GetUserNameResponse GetUserName(WalletWebSite.WalletService.GetUserNameRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/GetUserName", ReplyAction="http://tempuri.org/IWalletService/GetUserNameResponse")]
        System.Threading.Tasks.Task<WalletWebSite.WalletService.GetUserNameResponse> GetUserNameAsync(WalletWebSite.WalletService.GetUserNameRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/GetUserAccount", ReplyAction="http://tempuri.org/IWalletService/GetUserAccountResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WalletWebSite.WalletService.DataConnectionFault), Action="http://tempuri.org/IWalletService/GetUserAccountDataConnectionFaultFault", Name="DataConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/WalletService")]
        WalletWebSite.WalletService.GetUserAccountResponse GetUserAccount(WalletWebSite.WalletService.GetUserAccountRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/GetUserAccount", ReplyAction="http://tempuri.org/IWalletService/GetUserAccountResponse")]
        System.Threading.Tasks.Task<WalletWebSite.WalletService.GetUserAccountResponse> GetUserAccountAsync(WalletWebSite.WalletService.GetUserAccountRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/GetAccountBalance", ReplyAction="http://tempuri.org/IWalletService/GetAccountBalanceResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(WalletWebSite.WalletService.DataConnectionFault), Action="http://tempuri.org/IWalletService/GetAccountBalanceDataConnectionFaultFault", Name="DataConnectionFault", Namespace="http://schemas.datacontract.org/2004/07/WalletService")]
        WalletWebSite.WalletService.GetAccountBalanceResponse GetAccountBalance(WalletWebSite.WalletService.GetAccountBalanceRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IWalletService/GetAccountBalance", ReplyAction="http://tempuri.org/IWalletService/GetAccountBalanceResponse")]
        System.Threading.Tasks.Task<WalletWebSite.WalletService.GetAccountBalanceResponse> GetAccountBalanceAsync(WalletWebSite.WalletService.GetAccountBalanceRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ViewBalance", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ViewBalanceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string email;
        
        public ViewBalanceRequest() {
        }
        
        public ViewBalanceRequest(string email) {
            this.email = email;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ViewBalanceResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class ViewBalanceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public WalletWebSite.WalletService.DataConnectionFault ViewBalanceResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int balance;
        
        public ViewBalanceResponse() {
        }
        
        public ViewBalanceResponse(WalletWebSite.WalletService.DataConnectionFault ViewBalanceResult, int balance) {
            this.ViewBalanceResult = ViewBalanceResult;
            this.balance = balance;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUserName", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetUserNameRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string email;
        
        public GetUserNameRequest() {
        }
        
        public GetUserNameRequest(string email) {
            this.email = email;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUserNameResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetUserNameResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public WalletWebSite.WalletService.DataConnectionFault GetUserNameResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string username;
        
        public GetUserNameResponse() {
        }
        
        public GetUserNameResponse(WalletWebSite.WalletService.DataConnectionFault GetUserNameResult, string username) {
            this.GetUserNameResult = GetUserNameResult;
            this.username = username;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUserAccount", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetUserAccountRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string email;
        
        public GetUserAccountRequest() {
        }
        
        public GetUserAccountRequest(string email) {
            this.email = email;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetUserAccountResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetUserAccountResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public WalletWebSite.WalletService.DataConnectionFault GetUserAccountResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string accountNumber;
        
        public GetUserAccountResponse() {
        }
        
        public GetUserAccountResponse(WalletWebSite.WalletService.DataConnectionFault GetUserAccountResult, string accountNumber) {
            this.GetUserAccountResult = GetUserAccountResult;
            this.accountNumber = accountNumber;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAccountBalance", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetAccountBalanceRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string account;
        
        public GetAccountBalanceRequest() {
        }
        
        public GetAccountBalanceRequest(string account) {
            this.account = account;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetAccountBalanceResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class GetAccountBalanceResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public WalletWebSite.WalletService.DataConnectionFault GetAccountBalanceResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public int walletBalance;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public int bankAccountBalance;
        
        public GetAccountBalanceResponse() {
        }
        
        public GetAccountBalanceResponse(WalletWebSite.WalletService.DataConnectionFault GetAccountBalanceResult, int walletBalance, int bankAccountBalance) {
            this.GetAccountBalanceResult = GetAccountBalanceResult;
            this.walletBalance = walletBalance;
            this.bankAccountBalance = bankAccountBalance;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IWalletServiceChannel : WalletWebSite.WalletService.IWalletService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WalletServiceClient : System.ServiceModel.ClientBase<WalletWebSite.WalletService.IWalletService>, WalletWebSite.WalletService.IWalletService {
        
        public WalletServiceClient() {
        }
        
        public WalletServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WalletServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WalletServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WalletServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WalletWebSite.WalletService.DataConnectionFault Login(string email, string pwd) {
            return base.Channel.Login(email, pwd);
        }
        
        public System.Threading.Tasks.Task<WalletWebSite.WalletService.DataConnectionFault> LoginAsync(string email, string pwd) {
            return base.Channel.LoginAsync(email, pwd);
        }
        
        public WalletWebSite.WalletService.DataConnectionFault NewUser(string email, string pwd, string name, int phone, string bankAccNo) {
            return base.Channel.NewUser(email, pwd, name, phone, bankAccNo);
        }
        
        public System.Threading.Tasks.Task<WalletWebSite.WalletService.DataConnectionFault> NewUserAsync(string email, string pwd, string name, int phone, string bankAccNo) {
            return base.Channel.NewUserAsync(email, pwd, name, phone, bankAccNo);
        }
        
        public WalletWebSite.WalletService.DataConnectionFault DepositFunds(int amount, string email) {
            return base.Channel.DepositFunds(amount, email);
        }
        
        public System.Threading.Tasks.Task<WalletWebSite.WalletService.DataConnectionFault> DepositFundsAsync(int amount, string email) {
            return base.Channel.DepositFundsAsync(amount, email);
        }
        
        public WalletWebSite.WalletService.DataConnectionFault WithdrawFunds(int amount, string email) {
            return base.Channel.WithdrawFunds(amount, email);
        }
        
        public System.Threading.Tasks.Task<WalletWebSite.WalletService.DataConnectionFault> WithdrawFundsAsync(int amount, string email) {
            return base.Channel.WithdrawFundsAsync(amount, email);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WalletWebSite.WalletService.ViewBalanceResponse WalletWebSite.WalletService.IWalletService.ViewBalance(WalletWebSite.WalletService.ViewBalanceRequest request) {
            return base.Channel.ViewBalance(request);
        }
        
        public WalletWebSite.WalletService.DataConnectionFault ViewBalance(string email, out int balance) {
            WalletWebSite.WalletService.ViewBalanceRequest inValue = new WalletWebSite.WalletService.ViewBalanceRequest();
            inValue.email = email;
            WalletWebSite.WalletService.ViewBalanceResponse retVal = ((WalletWebSite.WalletService.IWalletService)(this)).ViewBalance(inValue);
            balance = retVal.balance;
            return retVal.ViewBalanceResult;
        }
        
        public System.Threading.Tasks.Task<WalletWebSite.WalletService.ViewBalanceResponse> ViewBalanceAsync(WalletWebSite.WalletService.ViewBalanceRequest request) {
            return base.Channel.ViewBalanceAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WalletWebSite.WalletService.GetUserNameResponse WalletWebSite.WalletService.IWalletService.GetUserName(WalletWebSite.WalletService.GetUserNameRequest request) {
            return base.Channel.GetUserName(request);
        }
        
        public WalletWebSite.WalletService.DataConnectionFault GetUserName(string email, out string username) {
            WalletWebSite.WalletService.GetUserNameRequest inValue = new WalletWebSite.WalletService.GetUserNameRequest();
            inValue.email = email;
            WalletWebSite.WalletService.GetUserNameResponse retVal = ((WalletWebSite.WalletService.IWalletService)(this)).GetUserName(inValue);
            username = retVal.username;
            return retVal.GetUserNameResult;
        }
        
        public System.Threading.Tasks.Task<WalletWebSite.WalletService.GetUserNameResponse> GetUserNameAsync(WalletWebSite.WalletService.GetUserNameRequest request) {
            return base.Channel.GetUserNameAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WalletWebSite.WalletService.GetUserAccountResponse WalletWebSite.WalletService.IWalletService.GetUserAccount(WalletWebSite.WalletService.GetUserAccountRequest request) {
            return base.Channel.GetUserAccount(request);
        }
        
        public WalletWebSite.WalletService.DataConnectionFault GetUserAccount(string email, out string accountNumber) {
            WalletWebSite.WalletService.GetUserAccountRequest inValue = new WalletWebSite.WalletService.GetUserAccountRequest();
            inValue.email = email;
            WalletWebSite.WalletService.GetUserAccountResponse retVal = ((WalletWebSite.WalletService.IWalletService)(this)).GetUserAccount(inValue);
            accountNumber = retVal.accountNumber;
            return retVal.GetUserAccountResult;
        }
        
        public System.Threading.Tasks.Task<WalletWebSite.WalletService.GetUserAccountResponse> GetUserAccountAsync(WalletWebSite.WalletService.GetUserAccountRequest request) {
            return base.Channel.GetUserAccountAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        WalletWebSite.WalletService.GetAccountBalanceResponse WalletWebSite.WalletService.IWalletService.GetAccountBalance(WalletWebSite.WalletService.GetAccountBalanceRequest request) {
            return base.Channel.GetAccountBalance(request);
        }
        
        public WalletWebSite.WalletService.DataConnectionFault GetAccountBalance(string account, out int walletBalance, out int bankAccountBalance) {
            WalletWebSite.WalletService.GetAccountBalanceRequest inValue = new WalletWebSite.WalletService.GetAccountBalanceRequest();
            inValue.account = account;
            WalletWebSite.WalletService.GetAccountBalanceResponse retVal = ((WalletWebSite.WalletService.IWalletService)(this)).GetAccountBalance(inValue);
            walletBalance = retVal.walletBalance;
            bankAccountBalance = retVal.bankAccountBalance;
            return retVal.GetAccountBalanceResult;
        }
        
        public System.Threading.Tasks.Task<WalletWebSite.WalletService.GetAccountBalanceResponse> GetAccountBalanceAsync(WalletWebSite.WalletService.GetAccountBalanceRequest request) {
            return base.Channel.GetAccountBalanceAsync(request);
        }
    }
}
