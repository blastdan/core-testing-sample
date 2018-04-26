using AutoMapper;
using CoreTestingSample.Context.DataModels;
using CoreTestingSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Bogus.Person;

namespace CoreTestingSample
{
    public static class Bootstrap
    {
        public static void AutoMapper()
        {
            // auto mapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Bogus.Person, Person>();
                cfg.CreateMap<CardAddress, Address>();
                cfg.CreateMap<CardCompany, Company>();
                cfg.CreateMap<Person, People>();
            });
        }
    }
}
