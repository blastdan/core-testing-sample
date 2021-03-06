﻿using AutoMapper;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreTestingSample.Context.DataModels;

namespace CoreTestingSample.Context
{
    public static class DBInitializer
    {
        public static void Initialize(TestingContext context)
        {
            // Look for data
            if (context.Persons.Any())
            {
                return; // Db has been initialized
            }

            var persons = new DataModels.Person[]
            {
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person()),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DataModels.Person>(new Bogus.Person("fr_CA")),
            };

            context.Persons.AddRange(persons);
            context.SaveChanges();
        }
    }
}
