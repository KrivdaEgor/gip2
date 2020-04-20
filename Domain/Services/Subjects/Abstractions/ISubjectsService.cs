using Domain.Services.Subjects.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.Subjects.Abstractions
{
    public interface ISubjectsService
    {
        int GetCountPages();
        Task<List<Entities.Subjects>> GetListAsync(int offset = 1);
        Task AddAsync(SubjectInfo info);
        Task EditAsync(SubjectInfo info);
        Task DeleteAsync(int id);
    }
}
