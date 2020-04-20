using Database;
using Domain.Services.Lectures.Abstractions;
using Domain.Services.Lectures.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Lectures
{
    public class LecturesService : ILecturesService
    {
        public int Count { get; set; } = 25;

        private readonly DatabaseContext _context;

        public LecturesService(DatabaseContext context)
        {
            _context = context;
        }

        public int GetCountPages()
        {
            int elms = _context.Lectures.Count();
            double elemOfPages = (double)elms / Count;
            return (int)Math.Ceiling(elemOfPages);
        }
        public Task<List<Entities.Lectures>> GetListAsync(int offset = 1)
        {
            return _context.Lectures.Skip(offset * Count).Take(Count).ToListAsync();
        }
        public Task<Entities.Lectures> GetUserAsync(int id)
        {
            return _context.Lectures.Where(w => w.IdLecture == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(LectureInfo info)
        {
            _context.Lectures.Add(new Entities.Lectures()
            {
                IdClassRoom = info.IdClassRoom,
                IdSubject = info.IdSubject,
                DateTime = info.DateTime
            });
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(LectureInfo info)
        {
            Entities.Lectures lecture = await _context.Lectures.FindAsync(info.IdLecture);
            if (lecture != null)
            {
                lecture.IdClassRoom = info.IdClassRoom;
                lecture.IdSubject = info.IdSubject;
                lecture.DateTime = info.DateTime;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            Entities.Lectures lecture = await _context.Lectures.FindAsync(id);
            if (lecture != null)
            {
                _context.Lectures.Remove(lecture);
                await _context.SaveChangesAsync();
            }
        }
    }
}
