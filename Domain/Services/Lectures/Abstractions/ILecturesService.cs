using Domain.Services.Lectures.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.Lectures.Abstractions
{
    public interface ILecturesService
    {
        int GetCountPages();
        Task<List<Entities.Lectures>> GetListAsync(int offset = 1);
        Task AddAsync(LectureInfo info);
        Task EditAsync(LectureInfo info);
        Task DeleteAsync(int id);
    }
}
