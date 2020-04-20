using Abstractions;
using Database;
using Domain.Services.Users.Abstractions;
using Domain.Services.Users.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services.Users
{
    public class UsersService : IUsersService
    {
        public int Count { get; set; } = 25;

        private readonly DatabaseContext _context;
        private readonly IHashingService _hashing;

        public UsersService(DatabaseContext context, IHashingService hashing)
        {
            _context = context;
            _hashing = hashing;
        }

        public int GetCountPages()
        {
            int elms = _context.Users.Count();
            double elemOfPages = (double)elms / Count;
            return (int)Math.Ceiling(elemOfPages);
        }
        public Task<List<IdentityUser>> GetListAsync(int offset = 1)
        {
            return _context.Users.Skip(offset * Count).Take(Count).Include(i => ((Entities.Users)i).IdGroupNavigation).ToListAsync();
        }
        public Task<IdentityUser> GetUserAsync(string id)
        {
            return _context.Users.Where(w => w.Id == id).Include(i => ((Entities.Users)i).IdGroupNavigation).FirstOrDefaultAsync();
        }
        /*public Task<IdentityUser> GetUserAsync(string email)
        {
            return _context.Users.Where(w => w.Email == email).FirstOrDefaultAsync();
        }*/


        public async Task AddAsync(UserInfo info)
        {
            _context.Users.Add(new Entities.Users()
            {
                IdGroup = info.IdGroup,
                TypeUser = info.TypeUser,
                Email = info.Email.Trim(),
                PasswordHash = _hashing.CaclulateHash(info.Password),
                FirstName = info.FirstName.Trim(),
                LastName = info.LastName.Trim()
            });
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(UserInfo info)
        {
            Entities.Users user = (Entities.Users)await _context.Users.FindAsync(info.IdUser);
            if (user != null)
            {
                user.IdGroup = info.IdGroup;
                user.TypeUser = info.TypeUser;
                user.Email = info.Email.Trim();
                user.PasswordHash = _hashing.CaclulateHash(info.Password);
                user.FirstName = info.FirstName.Trim();
                user.LastName = info.LastName.Trim();
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string id)
        {
            IdentityUser user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
