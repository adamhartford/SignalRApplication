namespace SignalRApplication
{
    using System;
    using System.IO;
    using Microsoft.AspNet.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Nancy;
    using Nancy.Owin;
    using Nancy.Conventions;
 
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseSignalR().UseOwin(x => x.UseNancy());
        }
        
        public virtual void ConfigureServices(IServiceCollection services) 
        {            
            services.AddSignalR();   
        }

        // Entry point for the application.
        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
    
    public class NancyBootstrapper : DefaultNancyBootstrapper, IRootPathProvider
    {
        public string GetRootPath()
        {
            return Directory.GetCurrentDirectory();
        }

        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {
            nancyConventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("wwwroot"));
            base.ConfigureConventions(nancyConventions);
        }
    }
}
