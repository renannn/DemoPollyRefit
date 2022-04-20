using Demo.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Demo.Controlers
{
    public interface IModules
    {
        [Get("/users")]
        Task<List<Module>> GetAllAsync();


        [Get("/users/{id}")]
        Task<List<Module>> GetAsync(int id);
    }
}
