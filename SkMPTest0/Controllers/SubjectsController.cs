using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services.Subjects.Abstractions;
using Domain.Services.Subjects.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SkMPTest0.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Route("[controller]")]
    public class SubjectsController : Controller
    {
        private readonly ISubjectsService _service;
        public SubjectsController(ISubjectsService service)
        {
            _service = service;
        }

        [Route("/Admin/Subjects")]
        public async Task<IActionResult> Subjects(int offset = 1)
        {
            ViewData["Page"] = offset;
            int Pages = _service.GetCountPages();
            ViewData["AllowPage"] = Pages == 0 ? 1 : Pages;
            List<Subjects> model = await _service.GetListAsync(offset - 1) ?? new List<Subjects>();
            return View(model);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(SubjectInfo info)
        {
            try
            {
                await _service.AddAsync(info);
                return Json(new { Status = "Ok" });
            }
            catch (DbUpdateException ex)
            {
                return Json(new { Status = "Er", Message = ex });
            }
        }
        [HttpPost]
        [Route("Edit")]
        public async Task<IActionResult> Edit(SubjectInfo info)
        {
            await _service.EditAsync(info);
            return Json(new { Status = "Ok" });
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return Json(new { Status = "Ok" });
        }
    }
}