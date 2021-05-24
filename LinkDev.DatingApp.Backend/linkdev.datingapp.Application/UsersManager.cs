using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LinkDev.DatingApp.Application.BE;
using LinkDev.DatingApp.Application.Contracts;
using LinkDev.DatingApp.Application.BE.DTOs;
using LinkDev.DatingApp.Core;
using LinkDev.DatingApp.Application.PresistenceContracts;
using LinkDev.DatingApp.Application.InfrastuctureContracts;

namespace LinkDev.DatingApp.Application
{
    public class UsersManager : IUsersManager
    {
        private readonly IAppUserRepository _repository;
        private readonly ITokenService _tokensService;

        public UsersManager(IAppUserRepository repository,
                            ITokenService tokensService)
        {
            this._repository = repository;
            this._tokensService = tokensService;
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

        public async Task<AppUser> UserExist(string username)
        {
           var user = await _repository.GetUserByUsername(username);
           return user;
        }

        public async Task<ApiResponse> Login(LoginDTO loginDTO)
        {
            var messages= new List<string>();
            var user =  await UserExist(loginDTO.username);

            if(user==null)
            {
             messages.Add("username is Not Exist !..");
             return new ApiResponse(System.Net.HttpStatusCode.BadRequest,messages,null);
            }

            var hmac = new HMACSHA512(user.PasswordSalt);

            var ComputedHash=hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.password));
            for(int i =0 ; i < ComputedHash.Length ; i++)
            {
                if(ComputedHash[i] != user.PasswordHash[i])
                {
                 messages.Add("Password is incorrect is Not Exist !..");
                 return new ApiResponse(System.Net.HttpStatusCode.BadRequest,messages,null);
                }
            }

            var userDto= new UserDTO(){username= user.UserName,Token=_tokensService.CreateToken(user)};
            
            return new ApiResponse(System.Net.HttpStatusCode.OK,null,userDto);
        }

    }
}