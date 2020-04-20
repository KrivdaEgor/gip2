using Domain.Entities;
using Domain.Services.Lectures.Abstractions;
using Domain.Services.Lectures.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkMPTest0.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Route("[controller]")]
    public class LecturesController : Controller
    {
        private readonly ILecturesService _service;
        public LecturesController(ILecturesService service)
        {
            _service = service;
        }

        [Route("/Admin/Lectures")]
        public async Task<IActionResult> Lectures(int offset = 1)
        {
            ViewData["Page"] = offset;
            int Pages = _service.GetCountPages();
            ViewData["AllowPage"] = Pages == 0 ? 1 : Pages;
            List<Lectures> model = await _service.GetListAsync(offset - 1) ?? new List<Lectures>();
            return View(model);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(LectureInfo info)
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
        public async Task<IActionResult> Edit(LectureInfo info)
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