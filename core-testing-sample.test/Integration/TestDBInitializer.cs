using AutoMapper;
using CoreTestingSample.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL = CoreTestingSample.Context.DataModels;

namespace CoreTestingSample.Test.Integration
{
    public class TestDBInitializer
    {
        private readonly TestingContext context;
        private static IEnumerable<DAL.Person> loadedPeople = new List<DAL.Person>();

        public TestDBInitializer(TestingContext context)
        {
            this.context = context;
        }

        public static IEnumerable<Guid> GetLoadedPeopleIds()
        {
            return loadedPeople.Select(l => l.Id);
        }

        public IEnumerable<DAL.Person> Initialize()
        {
            // Look for data
            if (context.Persons.Any())
            {
                return new List<DAL.Person>(); // Db has been initialized
            }

            var persons = new DAL.Person[]
            {
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person()),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
                Mapper.Map<DAL.Person>(new Bogus.Person("fr_CA")),
            };

            context.Persons.AddRange(persons);
            context.SaveChanges();


            loadedPeople = persons;
            return persons;
        }
    }
}
