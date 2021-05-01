using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using LinkDev.DatingApp.Core;

namespace LinkDev.DatingApp.Application.IRepositories
{
    public interface IAppUserRepository
    {
        Task<List<AppUser>> GetUsers();
        Task<AppUser> GetUserById(int id);
    }
}