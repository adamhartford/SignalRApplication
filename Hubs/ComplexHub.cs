namespace SignalRApplication
{
    using System;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.AspNet.SignalR;
    
	public class ComplexMessage
	{
		public int MessageId { get ;set ;}
		public string Message { get; set; }
		public string Detail { get; set; }
		public IEnumerable<String> Items { get; set; }
	}

	public class ComplexHub : Hub
    {
        public override Task OnConnected ()
        {
            // foo = bar, if testing query string
            string foo = Context.QueryString["foo"];
            return base.OnConnected();
        }
        
		public void SendComplex(ComplexMessage message) 
		{
			Clients.All.notifyComplex(message);
		}
	}
}