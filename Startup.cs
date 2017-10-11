using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;


namespace API.EPOCH.BACKEND
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IRepository<BaseClass>, Repository<BaseClass>>();
            services.AddTransient<IRepositoryAccount<Account>, RepositoryAccount<Account>>();


            services.AddMvc();
            services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Epoch Backend API", Version = "v1" }));

            var data = Configuration.GetConnectionString("Backend");

            DataConnection.AddConfiguration(


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Epoch Backend API V0.1"); });

            app.UseMvc();
        }
    }
}
