using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services.Users.Models;
using Microsoft.AspNetCore.Identity;

namespace Domain.Services.Users.Abstractions
{
    public interface IUsersService
    {
        int GetCountPages();
        Task<List<IdentityUser>> GetListAsync(int offset = 1);
        Task<IdentityUser> GetUserAsync(string id);
        Task AddAsync(UserInfo info);
        Task EditAsync(UserInfo info);
        Task DeleteAsync(string id);
    }
}
