﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ASPWebsite.SEService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://border/", ConfigurationName="SEService.Service")]
    public interface Service {
        
        // CODEGEN: Generating message contract since element name return from namespace  is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://border/Service/hellothereRequest", ReplyAction="http://border/Service/hellothereResponse")]
        ASPWebsite.SEService.hellothereResponse hellothere(ASPWebsite.SEService.hellothereRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://border/Service/hellothereRequest", ReplyAction="http://border/Service/hellothereResponse")]
        System.Threading.Tasks.Task<ASPWebsite.SEService.hellothereResponse> hellothereAsync(ASPWebsite.SEService.hellothereRequest request);
        
        // CODEGEN: Generating message contract since element name arg0 from namespace  is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://border/Service/checkUserRequest", ReplyAction="http://border/Service/checkUserResponse")]
        ASPWebsite.SEService.checkUserResponse checkUser(ASPWebsite.SEService.checkUserRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://border/Service/checkUserRequest", ReplyAction="http://border/Service/checkUserResponse")]
        System.Threading.Tasks.Task<ASPWebsite.SEService.checkUserResponse> checkUserAsync(ASPWebsite.SEService.checkUserRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class hellothereRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="hellothere", Namespace="http://border/", Order=0)]
        public ASPWebsite.SEService.hellothereRequestBody Body;
        
        public hellothereRequest() {
        }
        
        public hellothereRequest(ASPWebsite.SEService.hellothereRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class hellothereRequestBody {
        
        public hellothereRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class hellothereResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="hellothereResponse", Namespace="http://border/", Order=0)]
        public ASPWebsite.SEService.hellothereResponseBody Body;
        
        public hellothereResponse() {
        }
        
        public hellothereResponse(ASPWebsite.SEService.hellothereResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class hellothereResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string @return;
        
        public hellothereResponseBody() {
        }
        
        public hellothereResponseBody(string @return) {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class checkUserRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="checkUser", Namespace="http://border/", Order=0)]
        public ASPWebsite.SEService.checkUserRequestBody Body;
        
        public checkUserRequest() {
        }
        
        public checkUserRequest(ASPWebsite.SEService.checkUserRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class checkUserRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string arg0;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string arg1;
        
        public checkUserRequestBody() {
        }
        
        public checkUserRequestBody(string arg0, string arg1) {
            this.arg0 = arg0;
            this.arg1 = arg1;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class checkUserResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="checkUserResponse", Namespace="http://border/", Order=0)]
        public ASPWebsite.SEService.checkUserResponseBody Body;
        
        public checkUserResponse() {
        }
        
        public checkUserResponse(ASPWebsite.SEService.checkUserResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="")]
    public partial class checkUserResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public bool @return;
        
        public checkUserResponseBody() {
        }
        
        public checkUserResponseBody(bool @return) {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceChannel : ASPWebsite.SEService.Service, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ASPWebsite.SEService.Service>, ASPWebsite.SEService.Service {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ASPWebsite.SEService.hellothereResponse ASPWebsite.SEService.Service.hellothere(ASPWebsite.SEService.hellothereRequest request) {
            return base.Channel.hellothere(request);
        }
        
        public string hellothere() {
            ASPWebsite.SEService.hellothereRequest inValue = new ASPWebsite.SEService.hellothereRequest();
            inValue.Body = new ASPWebsite.SEService.hellothereRequestBody();
            ASPWebsite.SEService.hellothereResponse retVal = ((ASPWebsite.SEService.Service)(this)).hellothere(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ASPWebsite.SEService.hellothereResponse> ASPWebsite.SEService.Service.hellothereAsync(ASPWebsite.SEService.hellothereRequest request) {
            return base.Channel.hellothereAsync(request);
        }
        
        public System.Threading.Tasks.Task<ASPWebsite.SEService.hellothereResponse> hellothereAsync() {
            ASPWebsite.SEService.hellothereRequest inValue = new ASPWebsite.SEService.hellothereRequest();
            inValue.Body = new ASPWebsite.SEService.hellothereRequestBody();
            return ((ASPWebsite.SEService.Service)(this)).hellothereAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        ASPWebsite.SEService.checkUserResponse ASPWebsite.SEService.Service.checkUser(ASPWebsite.SEService.checkUserRequest request) {
            return base.Channel.checkUser(request);
        }
        
        public bool checkUser(string arg0, string arg1) {
            ASPWebsite.SEService.checkUserRequest inValue = new ASPWebsite.SEService.checkUserRequest();
            inValue.Body = new ASPWebsite.SEService.checkUserRequestBody();
            inValue.Body.arg0 = arg0;
            inValue.Body.arg1 = arg1;
            ASPWebsite.SEService.checkUserResponse retVal = ((ASPWebsite.SEService.Service)(this)).checkUser(inValue);
            return retVal.Body.@return;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ASPWebsite.SEService.checkUserResponse> ASPWebsite.SEService.Service.checkUserAsync(ASPWebsite.SEService.checkUserRequest request) {
            return base.Channel.checkUserAsync(request);
        }
        
        public System.Threading.Tasks.Task<ASPWebsite.SEService.checkUserResponse> checkUserAsync(string arg0, string arg1) {
            ASPWebsite.SEService.checkUserRequest inValue = new ASPWebsite.SEService.checkUserRequest();
            inValue.Body = new ASPWebsite.SEService.checkUserRequestBody();
            inValue.Body.arg0 = arg0;
            inValue.Body.arg1 = arg1;
            return ((ASPWebsite.SEService.Service)(this)).checkUserAsync(inValue);
        }
    }
}