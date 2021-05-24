using LinkDev.DatingApp.Application.InfrastuctureContracts;
using LinkDev.DatingApp.Core;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LinkDev.DatingApp.Infrastructure
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key; 
        public TokenService(string Key)
        {
          _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }
        public string CreateToken(AppUser user)
        {
             var cred = new SigningCredentials(_key , SecurityAlgorithms.HmacSha512Signature);
            
             var claims = new List<Claim>()
             {
                new Claim(JwtRegisteredClaimNames.NameId,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,"DevTeam@Linkdev.com")
             };


            var tokenDescriptor= new SecurityTokenDescriptor(){
             Subject= new ClaimsIdentity(claims),
             SigningCredentials =cred,
             Expires=DateTime.Now.Date.AddDays(7),
             Issuer= "Linkdev.DatingApp",
            };

          var tokenHandler = new JwtSecurityTokenHandler();
          var token = tokenHandler.CreateToken(tokenDescriptor);
          return tokenHandler.WriteToken(token);
        }
    }
}