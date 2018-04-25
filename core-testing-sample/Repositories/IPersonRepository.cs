using CoreTestingSample.Context.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreTestingSample.Repositories
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        IEnumerable<Person> Get(Expression<Func<Person, bool>> filter = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null);
        Task<IEnumerable<Person>> GetAsync(Expression<Func<Person, bool>> filter = null, Func<IQueryable<Person>, IOrderedQueryable<Person>> orderBy = null);
    }
}
