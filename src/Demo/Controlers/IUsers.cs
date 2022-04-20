using Demo.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Controlers
{
    public interface IUsers
    {

        [Get("/users")]
        Task<List<User>> GetAllAsync();


        [Get("/users/{id}")]
        Task<List<User>> GetAsync(int id);
    }
}
