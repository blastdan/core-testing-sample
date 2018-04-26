using CoreTestingSample.Context;
using CoreTestingSample.Repositories;
using CoreTestingSample.Services;
using CoreTestingSample.Test.Integration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreTestingSample.Test
{
    public class TestingStartup : Startup
    {
        public TestingStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            base.Configure(app, env);

            // Now seed the database
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var seeder = serviceScope.ServiceProvider.GetService<TestDBInitializer>();
                seeder.Initialize();
            }
        }

        public override void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<TestingContext>(options =>
                    options.UseInMemoryDatabase("integration_testing"));

            services.AddTransient<TestDBInitializer>();
        }
    }
}
