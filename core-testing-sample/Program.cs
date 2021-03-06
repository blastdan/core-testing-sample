﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreTestingSample.Context;
using CoreTestingSample.Context.DataModels;
using CoreTestingSample.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using static Bogus.Person;

namespace CoreTestingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            Bootstrap.AutoMapper();

            // Seed data
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TestingContext>();
                DBInitializer.Initialize(context);
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
