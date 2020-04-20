using Database;
using Domain.Services.ClassRooms.Abstractions;
using Domain.Services.ClassRooms.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.ClassRooms
{
    public class ClassRoomService : IClassRoomService
    {
        public int Count { get; set; } = 25;

        private readonly DatabaseContext _context;

        public ClassRoomService(DatabaseContext context)
        {
            _context = context;
        }

        public int GetCountPages()
        {
            int elms = _context.ClassRooms.Count();
            double elemOfPages = (double)elms / Count;
            return (int)Math.Ceiling(elemOfPages);
        }
        public Task<List<Entities.ClassRooms>> GetListAsync(int offset = 1)
        {
            return _context.ClassRooms.Skip(offset * Count).Take(Count).ToListAsync();
        }
        public Task<Entities.ClassRooms> GetUserAsync(int id)
        {
            return _context.ClassRooms.Where(w => w.IdClassRoom == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(ClassRoomInfo info)
        {
            _context.ClassRooms.Add(new Entities.ClassRooms()
            {
                Location = info.Location,
                Capacity = info.Capacity,
                Resource = info.Resource,
            });
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(ClassRoomInfo info)
        {
            Entities.ClassRooms classRoom = await _context.ClassRooms.FindAsync(info.IdClassRoom);
            if (classRoom != null)
            {
                classRoom.Location = info.Location;
                classRoom.Capacity = info.Capacity;
                classRoom.Resource = info.Resource;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            Entities.ClassRooms classRoom = await _context.ClassRooms.FindAsync(id);
            if (classRoom != null)
            {
                _context.ClassRooms.Remove(classRoom);
                await _context.SaveChangesAsync();
            }
        }
    }
}
