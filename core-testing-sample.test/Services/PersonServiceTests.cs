using Bogus;
using CoreTestingSample.Context.DataModels;
using CoreTestingSample.Models;
using CoreTestingSample.Repositories;
using CoreTestingSample.Services;
using Moq;
using NUnit.Framework;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreTestingSample.Test.Services
{
    [TestFixture, Description("Business logic testing for persons")]
    public class PersonServiceTests
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

            Bootstrap.AutoMapper();
        }

        [Test, Description("Gets all the users and maps them to the People model")]
        [Category("Business Logic")]
        public void GetAllPeopleSuccessTest()
        {
            var people = GeneratePeople(1);

            var repoMock = new Mock<IPersonRepository>();
            repoMock.Setup(r => r.Get(null, null)).Returns(people);

            var Target = new PersonService(repoMock.Object);
            var Expected = new List<People>()
            {
                new People(){
                    Avatar = people.First().Avatar,
                    DateOfBirth = people.First().DateOfBirth,
                    Email = people.First().Email,
                    FirstName = people.First().FirstName,
                    LastName = people.First().LastName,
                    Phone = people.First().Phone,
                    UserName = people.First().UserName,
                    Website = people.First().Website,
                    Id = people.First().Id
                }
            };
            var Actual = Target.GetAllPeople();

            Actual.Should().BeEquivalentTo(Expected, "the service should have mapped the data properly");
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
    }
}
