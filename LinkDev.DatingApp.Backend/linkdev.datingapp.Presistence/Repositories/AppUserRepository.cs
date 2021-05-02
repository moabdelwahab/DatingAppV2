using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LinkDev.DatingApp.Application.IRepositories;
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
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserById(int id)
        {
             return await _context.Users.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<int> AddUser(AppUser user)
        {
            _context.Users.Add(user);
            var id =  await _context.SaveChangesAsync();
            return id;
        }
    }
}