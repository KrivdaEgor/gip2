using Domain.Services.Groups.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.Groups.Abstractions
{
    public interface IGroupsService
    {
        int GetCountPages();
        Task<List<Entities.Groups>> GetListAsync(int offset = 0);
        Task AddAsync(GroupInfo info);
        Task EditAsync(GroupInfo info);
        Task DeleteAsync(int id);
    }
}
