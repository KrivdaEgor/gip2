using Domain.Services.ClassRooms.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services.ClassRooms.Abstractions
{
    public interface IClassRoomService
    {
        int GetCountPages();
        Task<List<Entities.ClassRooms>> GetListAsync(int offset = 1);
        Task AddAsync(ClassRoomInfo info);
        Task EditAsync(ClassRoomInfo info);
        Task DeleteAsync(int id);
    }
}
