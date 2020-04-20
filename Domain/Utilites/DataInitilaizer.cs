using Database;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Utilites
{
    public class DataInitilaizer
    {
        private readonly DatabaseContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Users> _userManager;

        public DataInitilaizer(DatabaseContext context, RoleManager<IdentityRole> roleManager, UserManager<Users> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task Initialize()
        {
            if (!await _context.Groups.AnyAsync(a => a.IdGroup == 1))
            {
                _context.Groups.Add(new Groups()
                {
                    IdGroup = 1,
                    Name = "Administator"
                });
                await _context.SaveChangesAsync();
            }
            if (!await _context.Groups.AnyAsync(a => a.IdGroup == 2))
            {
                _context.Groups.Add(new Groups()
                {
                    IdGroup = 2,
                    Name = "NewUser"
                });
                await _context.SaveChangesAsync();
            }
            if (!await _context.Roles.AnyAsync(a => a.Id == "Administrator"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Administrator"));
                await _roleManager.CreateAsync(new IdentityRole("Teacher"));
            }
            if (await _context.Users.CountAsync() == 0)
            {
                Users user = new Users()
                {
                    UserName = "test@test.ru",
                    Email = "test@test.ru",
                    FirstName = "Her",
                    LastName = "Herov",
                    TypeUser = 2,
                    IdGroup = 1
                };

                var result = await _userManager.CreateAsync(user, "123456");
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Administrator");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    await _userManager.ConfirmEmailAsync(user, code);
                }
            }


        }
    }
}
