using Database;
using Domain.Services.LecturesPool.Abstractions;
using Domain.Services.LecturesPool.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services.LecturesPool
{
    public class LecturesPoolService : ILecturesPoolService
    {
        public int Count { get; set; } = 25;

        private readonly DatabaseContext _context;

        public LecturesPoolService(DatabaseContext context)
        {
            _context = context;
        }

        public int GetCountPages()
        {
            int elms = _context.LecturesPool.Count();
            double elemOfPages = (double)elms / Count;
            return (int)Math.Ceiling(elemOfPages);
        }
        public Task<List<Entities.LecturesPool>> GetListAsync(int offset = 1)
        {
            return _context.LecturesPool.Skip(offset * Count).Take(Count).ToListAsync();
        }
        public Task<Entities.LecturesPool> GetUserAsync(int id)
        {
            return _context.LecturesPool.Where(w => w.IdLecturesPool == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(LecturesPoolInfo info)
        {
            _context.LecturesPool.Add(new Entities.LecturesPool()
            {
                IdLecture = info.IdLecture,
                IdUser = info.IdUser
            });
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(LecturesPoolInfo info)
        {
            Entities.LecturesPool lecturePool = await _context.LecturesPool.FindAsync(info.IdLecturesPool);
            if (lecturePool != null)
            {
                lecturePool.IdLecture = info.IdLecture;
                lecturePool.IdUser = info.IdUser;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            Entities.LecturesPool lecturePool = await _context.LecturesPool.FindAsync(id);
            if (lecturePool != null)
            {
                _context.LecturesPool.Remove(lecturePool);
                await _context.SaveChangesAsync();
            }
        }
    }
}
