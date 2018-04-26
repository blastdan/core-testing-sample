using System.Collections.Generic;
using System.Threading.Tasks;
using CoreTestingSample.Models;

namespace CoreTestingSample.Services
{
    public interface IPersonService
    {
        IEnumerable<People> GetAllPeople();
        Task<IEnumerable<People>> GetAllPeopleAsync();
        Task<IEnumerable<People>> SearchPeople(string nameSearch);
    }
}