using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkDev.DatingApp.Application.PresistenceContracts;
using LinkDev.DatingApp.Core;
using Microsoft.EntityFrameworkCore;

namespace LinkDev.DatingApp.Presistence.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private readonly DatingAppContext _context;
        public AppUserRepository(DatingAppContext context)
        {
            this._context = context;

        }
        public async Task<List<AppUser>> GetUsers()
        {
            return await _context.Users.Include(x=>x.Photos).ToListAsync();
        }

        public async Task<AppUser> GetUserById(int id)
        {
             return await _context.Users.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<int> AddUser(AppUser user)
        {
            _context.Users.Add(user);
             await _context.SaveChangesAsync();
             return user.Id;
        }

        public async Task<AppUser> GetUserByUsername(string username)
        {
             return await _context.Users.Include(x=>x.Photos).FirstOrDefaultAsync(x=>x.UserName.ToLower() ==username.ToLower());
        }

        public async Task UpdateUser(AppUser user)
        {
            _context.Attach(user);
            _context.Entry(user).State = EntityState.Modified;
             await _context.SaveChangesAsync();
        }
    }
}