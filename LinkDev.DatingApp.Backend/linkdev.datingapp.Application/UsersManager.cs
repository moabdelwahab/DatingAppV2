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
using AutoMapper;
using LinkDev.DatingApp.Application.Errors;

namespace LinkDev.DatingApp.Application
{
    public class UsersManager : IUsersManager
    {
        private readonly IAppUserRepository _repository;
        private readonly ITokenService _tokensService;
        private readonly IMapper _mapper;

        public UsersManager(IAppUserRepository repository,
                            ITokenService tokensService,
                            IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
            this._tokensService = tokensService;
        }

        public async Task<AppUser> GetUserById(int id)
        {
            return await _repository.GetUserById(id);
        }

        public async Task<List<MemberDto>> GetUsers()
        {
            var users = await _repository.GetUsers();

            return _mapper.Map<List<MemberDto>>(users);
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

        public async Task<UserDTO> Login(LoginDTO loginDTO)
        {
            var messages = new List<string>();
            var user = await UserExist(loginDTO.username);

            if (user == null)
            {
               throw new BusinessException("username is Not Exist !..");
            }

            var hmac = new HMACSHA512(user.PasswordSalt);

            var ComputedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.password));
            for (int i = 0; i < ComputedHash.Length; i++)
            {
                if (ComputedHash[i] != user.PasswordHash[i])
                {
                    throw new BusinessException("Password is incorrect is Not Exist !..");
                }
            }

            var userDto = new UserDTO() { username = user.UserName, Token = _tokensService.CreateToken(user) };
            return userDto;
        }


        public async Task<MemberDto> GetUserByUsername(string username)
        {  
            var user = await _repository.GetUserByUsername(username);
            return _mapper.Map<MemberDto>(user);
        }

        public async Task UpdateUser(string username, UpdateMemberDto UpdateMember)
        {
            var user = await _repository.GetUserByUsername(username);
           _mapper.Map(UpdateMember,user);
            await _repository.UpdateUser(user);
        }
    }
}