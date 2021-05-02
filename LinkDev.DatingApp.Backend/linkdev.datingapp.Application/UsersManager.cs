using System.Collections.Generic;
using System.Threading.Tasks;
using LinkDev.DatingApp.Application.Contracts;
using LinkDev.DatingApp.Core;

namespace LinkDev.DatingApp.Application
{
    public class UsersManager : IUsersManager
    {
        private readonly IRepositories.IAppUserRepository _repository;
        public UsersManager(IRepositories.IAppUserRepository repository)
        {
            this._repository = repository;
        }

        public async Task<AppUser> GetUserById(int id )
        {
            return await _repository.GetUserById(id);
        }

        public async Task<List<AppUser>> GetUsers()
        {
            return await _repository.GetUsers();
        }

        public async Task<int> AddUser(AppUser user)
        {
            return await _repository.AddUser(user);
        }
     }
}