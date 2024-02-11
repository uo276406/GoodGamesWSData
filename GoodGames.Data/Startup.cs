using Microsoft.Extensions.DependencyInjection.Extensions;
using SoapCore;
using System.ServiceModel;
using GoodGames.Data;
using Microsoft.EntityFrameworkCore;

namespace GoodGames.Data
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.TryAddSingleton<IDataServices, DataServices>();
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddSoapCore();
            services.AddDbContext<DataContext>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using(var servicesScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = new DataContext();
                // context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
             }

            app.UseSoapEndpoint<IDataServices>("/GoodGamesData.svc", new BasicHttpBinding(), SoapSerializer.DataContractSerializer, false, null, null, true, true);
            app.UseMvc();
        }
    }
}
