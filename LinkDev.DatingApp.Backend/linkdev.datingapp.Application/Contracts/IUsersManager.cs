using System.Collections.Generic;
using System.Threading.Tasks;
using LinkDev.DatingApp.Core;

namespace LinkDev.DatingApp.Application.Contracts
{
    public interface IUsersManager
    {
        Task<List<AppUser>> GetUsers();

        Task<AppUser> GetUserById(int id);
    }
}