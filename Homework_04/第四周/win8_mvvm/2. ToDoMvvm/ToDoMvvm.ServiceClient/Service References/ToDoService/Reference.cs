﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 11.0.50727.1
// 
namespace ToDoMvvm.ServiceClient.ToDoService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ToDoItem", Namespace="http://schemas.datacontract.org/2004/07/ToDoMVVM.Web.Services")]
    public partial class ToDoItem : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string CategoryField;
        
        private string DescriptionField;
        
        private System.DateTime DueDateField;
        
        private int PriorityField;
        
        private string TitleField;
        
        private int ToDoIdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Category {
            get {
                return this.CategoryField;
            }
            set {
                if ((object.ReferenceEquals(this.CategoryField, value) != true)) {
                    this.CategoryField = value;
                    this.RaisePropertyChanged("Category");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description {
            get {
                return this.DescriptionField;
            }
            set {
                if ((object.ReferenceEquals(this.DescriptionField, value) != true)) {
                    this.DescriptionField = value;
                    this.RaisePropertyChanged("Description");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime DueDate {
            get {
                return this.DueDateField;
            }
            set {
                if ((this.DueDateField.Equals(value) != true)) {
                    this.DueDateField = value;
                    this.RaisePropertyChanged("DueDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((this.PriorityField.Equals(value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Title {
            get {
                return this.TitleField;
            }
            set {
                if ((object.ReferenceEquals(this.TitleField, value) != true)) {
                    this.TitleField = value;
                    this.RaisePropertyChanged("Title");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ToDoId {
            get {
                return this.ToDoIdField;
            }
            set {
                if ((this.ToDoIdField.Equals(value) != true)) {
                    this.ToDoIdField = value;
                    this.RaisePropertyChanged("ToDoId");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ToDoService.IToDoService")]
    public interface IToDoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoService/GetAllToDos", ReplyAction="http://tempuri.org/IToDoService/GetAllToDosResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ToDoMvvm.ServiceClient.ToDoService.ToDoItem>> GetAllToDosAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoService/GetToDoItemById", ReplyAction="http://tempuri.org/IToDoService/GetToDoItemByIdResponse")]
        System.Threading.Tasks.Task<ToDoMvvm.ServiceClient.ToDoService.ToDoItem> GetToDoItemByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IToDoService/DeleteToDoItemById", ReplyAction="http://tempuri.org/IToDoService/DeleteToDoItemByIdResponse")]
        System.Threading.Tasks.Task DeleteToDoItemByIdAsync(int id);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IToDoServiceChannel : ToDoMvvm.ServiceClient.ToDoService.IToDoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ToDoServiceClient : System.ServiceModel.ClientBase<ToDoMvvm.ServiceClient.ToDoService.IToDoService>, ToDoMvvm.ServiceClient.ToDoService.IToDoService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public ToDoServiceClient() : 
                base(ToDoServiceClient.GetDefaultBinding(), ToDoServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IToDoService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ToDoServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(ToDoServiceClient.GetBindingForEndpoint(endpointConfiguration), ToDoServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ToDoServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(ToDoServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ToDoServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(ToDoServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public ToDoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<ToDoMvvm.ServiceClient.ToDoService.ToDoItem>> GetAllToDosAsync() {
            return base.Channel.GetAllToDosAsync();
        }
        
        public System.Threading.Tasks.Task<ToDoMvvm.ServiceClient.ToDoService.ToDoItem> GetToDoItemByIdAsync(int id) {
            return base.Channel.GetToDoItemByIdAsync(id);
        }
        
        public System.Threading.Tasks.Task DeleteToDoItemByIdAsync(int id) {
            return base.Channel.DeleteToDoItemByIdAsync(id);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IToDoService)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IToDoService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:8513/ToDoService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return ToDoServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IToDoService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return ToDoServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IToDoService);
        }
        
        public enum EndpointConfiguration {
            
            BasicHttpBinding_IToDoService,
        }
    }
}
