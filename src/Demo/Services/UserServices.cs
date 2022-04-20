using Demo.Configurations;
using Demo.Controlers;
using Demo.Models;
using Microsoft.Extensions.Options;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Services
{
    public class UserServices : BaseService
    {
        private readonly IUsers _usersController;
        private readonly AppSettings _options;

        public UserServices(IUsers usersController, IOptionsSnapshot<AppSettings> options)
            : base(options)
        {
            _usersController = usersController;
            _options = options.Value;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var policy = GetTimeoutPolicy();

            return await policy
            .ExecuteAsync(async () => await _usersController.GetAllAsync())
            .ConfigureAwait(false);
        }
    }
}
