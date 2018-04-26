using Bogus;
using CoreTestingSample.Context;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using CoreTestingSample.Context.DataModels;
using CoreTestingSample.Repositories;
using FluentAssertions;
using System.Linq;

namespace CoreTestingSample.Test.Repositories
{
    [TestFixture, Description("Tests for the Person Repository Class. Runs against in memory database")]
    public class PersonRepositoryTests
    {
        Faker<Context.DataModels.Person> personFake;
        Faker<Context.DataModels.Address> addressFake;
        Faker<Context.DataModels.Company> companyFake;

        [SetUp]
        public void Setup()
        {
            this.personFake = new Faker<Context.DataModels.Person>()
                            .RuleFor(p => p.Avatar, f => f.Image.DataUri(300, 300))
                            .RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth)
                            .RuleFor(p => p.Email, f => f.Person.Email)
                            .RuleFor(p => p.FirstName, f => f.Person.FirstName)
                            .RuleFor(p => p.LastName, f => f.Person.LastName)
                            .RuleFor(p => p.Phone, f => f.Person.Phone)
                            .RuleFor(p => p.UserName, f => f.Person.UserName)
                            .RuleFor(p => p.Website, f => f.Internet.Url());

            this.addressFake = new Faker<Address>()
                .RuleFor(a => a.City, f => f.Address.City())
                .RuleFor(a => a.Street, f => f.Address.State())
                .RuleFor(a => a.Suite, f => f.Address.SecondaryAddress())
                .RuleFor(a => a.ZipCode, f => f.Address.ZipCode());

            this.companyFake = new Faker<Company>()
                .RuleFor(c => c.Bs, f => f.Company.Bs())
                .RuleFor(c => c.CatchPhrase, f => f.Company.CatchPhrase())
                .RuleFor(c => c.Name, f => f.Company.CompanyName());
               
        }

        [Test, Description("Inserts a person into the database and retreives it by Id")]
        [Category("Database Access")]
        public void AddPersonSuccessTest()
        {
            var Input = new
            {
                person = GeneratePeople(1).First(),
                options = this.GenerateOptions("AddPersonSuccessTest")
            };

            using(var context = new TestingContext(Input.options))
            {
                var repo = new PersonRepository(context);
                repo.Insert(Input.person);
                context.SaveChanges();
            }

            Context.DataModels.Person Actual;
            using (var context = new TestingContext(Input.options))
            {
                var Target = new PersonRepository(context);
                Actual = Target.GetFullPersonById(Input.person.Id);
            }
            Actual.Should().BeEquivalentTo(Input.person, 
                                           op => op.Excluding(p => p.Address.Person)
                                                   .Excluding(p => p.Company.Person), 
                                           "the data should have been saved and received from the database");
        }

        [Test, Description("Inserts a list persons into the database and retreives them all")]
        [Category("Database Access")]
        public void AddPersonsSuccessTest()
        {
            var Input = new
            {
                persons = GeneratePeople(30).OrderBy(p => p.Id).ToList(),
                options = this.GenerateOptions("AddPersonsSuccessTest")
            };

            using (var context = new TestingContext(Input.options))
            {
                var repo = new PersonRepository(context);

                foreach (var person in Input.persons)
                {
                    repo.Insert(person);
                }

                context.SaveChanges();
            }

            List<Context.DataModels.Person> Actual;
            using (var context = new TestingContext(Input.options))
            {
                var Target = new PersonRepository(context);
                Actual = Target.Get(null, null).OrderBy(p => p.Id).ToList();
            }
            Actual.Should().BeEquivalentTo(Input.persons,
                                           op => op.Excluding(p => p.Address.Person)
                                                   .Excluding(p => p.Company.Person),
                                           "the data had been saved and received from the database");
        }

        private IEnumerable<Context.DataModels.Person> GeneratePeople(int number)
        {
            return this.personFake.Generate(number).Select(p =>
            {
                p.Company = this.companyFake.Generate();
                p.Address = this.addressFake.Generate();
                return p;
            });
        }

        private DbContextOptions<TestingContext> GenerateOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<TestingContext>()
                .UseInMemoryDatabase(databaseName: databaseName)
                .Options;
        }
    }
}
