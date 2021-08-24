using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LinkDev.DatingApp.Core;
using Microsoft.Extensions.Logging;

namespace LinkDev.DatingApp.Presistence
{
 
    public class Seed
    {
        private readonly ILogger<Seed> _logger;
        public Seed(ILogger<Seed> logger)
        {
            this._logger = logger;
        }
        public  async Task SeedUsers(DatingAppContext context)
        {
            try{
                var UsersData = await System.IO.File.ReadAllTextAsync(@".\SeedData\UserSeedData.json");
                var users = JsonSerializer.Deserialize<List<AppUser>>(UsersData);
                _logger.LogInformation("Users count is : {count}" , users.Count() );
                foreach (var user in users)
                {
                    _logger.LogInformation("{username}-{date},{url}"
                    ,user.UserName,user.DateOfBirth,user.Photos.First().Url);
                    using var hmac = new HMACSHA512();
                    user.UserName = user.UserName.ToLower();
                    user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("P@ssw0rd"));
                    user.PasswordSalt = hmac.Key;
                    context.Users.Add(user);
                }
                context.SaveChanges();

            }catch(Exception ex)
                {
                    _logger.LogError(ex,ex.Message);
                }
          
        }
    }
}