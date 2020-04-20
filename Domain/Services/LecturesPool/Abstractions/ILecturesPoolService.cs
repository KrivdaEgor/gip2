using Domain.Services.LecturesPool.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.LecturesPool.Abstractions
{
    public interface ILecturesPoolService
    {
        int GetCountPages();
        Task<List<Entities.LecturesPool>> GetListAsync(int offset = 1);
        Task AddAsync(LecturesPoolInfo info);
        Task EditAsync(LecturesPoolInfo info);
        Task DeleteAsync(int id);
    }
}
