namespace SignalRApplication
{
    using System;
    using Microsoft.AspNet.Http;
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;
    
    [CustomAuthorize]
    public class SimpleHub : Hub
    {
        public void SendSimple(string message, string detail)
        {
            var clients = Clients.All;
            Clients.All.notifySimple(message, detail);
        }

        public string SendSimple2(string message, string detail)
        {
            var clients = Clients.All;
            Clients.All.notifySimple(message, detail);
            return "SomeValue";
        }

        public object SendSimple3(string message, string detail)
        {
            var clients = Clients.All;
            Clients.All.notifySimple(message, detail);
            return new { Foo = "foo", Bar = "bar" };
        }
    }
    
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool UserAuthorized(System.Security.Principal.IPrincipal user)
        {
            return true;
        }

        public override bool AuthorizeHubConnection(HubDescriptor hubDescriptor, HttpRequest request)
        {
             return true;
        }

        public override bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            return true;
        }
    }
}