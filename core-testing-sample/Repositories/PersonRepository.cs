using CoreTestingSample.Context;
using CoreTestingSample.Context.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreTestingSample.Repositories
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        private Expression<Func<Person, object>>[] includes = new Expression<Func<Person, object>>[]
        {
            x => x.Address,
            x => x.Company
        };

        private Func<Person, object>[] includeds = new Func<Person, object>[]
        {
            new Func<Person, object>(p => p.Address)
        };


        public PersonRepository(TestingContext context) : base(context)
        {   
        }

        public IEnumerable<Person> Get(Expression<Func<Person, bool>> filter = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null)
        {
            return base.Get(filter, orderBy, this.includes);
        }

        public async Task<IEnumerable<Person>> GetAsync(Expression<Func<Person, bool>> filter = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null)
        {
            return await base.GetAsync(filter, orderBy, this.includes);
        }

        public Person GetFullPersonById(Guid personId)
        {
            return this.Get(x => x.Id == personId, null, this.includes).SingleOrDefault();
        }
    }
}
