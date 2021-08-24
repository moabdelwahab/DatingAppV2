using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkDev.DatingApp.Core;

namespace LinkDev.DatingApp.Application.PresistenceContracts
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetUsers();
        Task<AppUser> GetUserById(int id);
        Task<int> AddUser(AppUser user);
        Task<AppUser> GetUserByUsername(string username);
        Task UpdateUser(AppUser user);
    }
}