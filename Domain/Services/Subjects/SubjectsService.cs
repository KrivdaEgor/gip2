using Database;
using Domain.Services.Subjects.Abstractions;
using Domain.Services.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services.Subjects
{
    public class SubjectsService : ISubjectsService
    {
        public int Count { get; set; } = 25;

        private readonly DatabaseContext _context;

        public SubjectsService(DatabaseContext context)
        {
            _context = context;
        }

        public int GetCountPages()
        {
            int elms = _context.Subjects.Count();
            double elemOfPages = (double)elms / Count;
            return (int)Math.Ceiling(elemOfPages);
        }
        public Task<List<Entities.Subjects>> GetListAsync(int offset = 1)
        {
            return _context.Subjects.Skip(offset * Count).Take(Count).ToListAsync();
        }
        public Task<Entities.Subjects> GetUserAsync(string id)
        {
            return _context.Subjects.Where(w => w.IdSubject == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(SubjectInfo info)
        {
            _context.Subjects.Add(new Entities.Subjects()
            {
                Name = info.Name.Trim(),
                StudentPoints = info.StudentPoints
            });
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(SubjectInfo info)
        {
            Entities.Subjects subject = await _context.Subjects.FindAsync(info.IdSubject);
            if (subject != null)
            {
                subject.Name = info.Name.Trim();
                subject.StudentPoints = info.StudentPoints;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            Entities.Subjects subject = await _context.Subjects.FindAsync(id);
            if (subject != null)
            {
                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();
            }
        }
    }
}
