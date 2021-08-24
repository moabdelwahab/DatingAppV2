using System.Collections.Generic;
using System.Threading.Tasks;
using LinkDev.DatingApp.Application.BE;
using LinkDev.DatingApp.Application.BE.DTOs;
using LinkDev.DatingApp.Core;

namespace LinkDev.DatingApp.Application.Contracts
{
    public interface IUsersManager
    {
        Task<List<MemberDto>> GetUsers();
        Task<AppUser> GetUserById(int id);
        Task<int> AddUser(AppUser user);
        Task<AppUser> UserExist(string username);
        Task<UserDTO> Login(LoginDTO loginDTO );
        Task <MemberDto> GetUserByUsername(string username);
        Task UpdateUser(string username , UpdateMemberDto member);
    }
}