using AutoMapper;
using CoreTestingSample.Context.DataModels;
using CoreTestingSample.Models;
using CoreTestingSample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreTestingSample.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        
        public PersonService(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public IEnumerable<People> GetAllPeople()
        {
            var persons = this.personRepository.Get().ToList();
            return persons.Select(p => Mapper.Map<People>(p));
        }
        public async Task<IEnumerable<People>> GetAllPeopleAsync()
        {
            var persons = await this.personRepository.GetAsync();
            return persons.Select(p => Mapper.Map<People>(p));
        }

        public async Task<IEnumerable<People>> SearchPeople(string nameSearch)
        {
            var persons =  await this.personRepository.GetAsync(x => x.FirstName.StartsWith(nameSearch) ||
                                                        x.LastName.StartsWith(nameSearch));
            return persons.Select(p => Mapper.Map<People>(p));
        }
    }
}
