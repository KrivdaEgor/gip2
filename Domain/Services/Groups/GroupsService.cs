using Database;
using Domain.Services.Groups.Abstractions;
using Domain.Services.Groups.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services.Groups
{
    public class GroupsService : IGroupsService
    {
        public int Count { get; set; } = 25;

        private readonly DatabaseContext _context;

        public GroupsService(DatabaseContext context)
        {
            _context = context;
        }

        public int GetCountPages()
        {
            int elms = _context.Groups.Count();
            double elemOfPages = (double)elms / Count;
            return (int)Math.Ceiling(elemOfPages);
        }
        public Task<List<Entities.Groups>> GetListAsync(int offset = 0)
        {
            return _context.Groups.Skip(offset * Count).Take(Count).ToListAsync();
        }
        public Task<Entities.Groups> GetUserAsync(int id)
        {
            return _context.Groups.Where(w => w.IdGroup == id).FirstOrDefaultAsync();
        }

        public async Task AddAsync(GroupInfo info)
        {
            _context.Groups.Add(new Entities.Groups()
            {
                IdGroup = info.IdGroup,
                Name = info.Name
            });
            await _context.SaveChangesAsync();
        }
        public async Task EditAsync(GroupInfo info)
        {
            Entities.Groups group = await _context.Groups.FindAsync(info.IdGroup);
            if (group != null)
            {
                group.Name = info.Name;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync(int id)
        {
            Entities.Groups group = await _context.Groups.FindAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }
    }
}
