using Domain.Entities;
using Domain.Services.LecturesPool.Abstractions;
using Domain.Services.LecturesPool.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkMPTest0.Controllers
{
    [Authorize(Roles = "Teacher")]
    [Route("[controller]")]
    public class LecturesPoolController : Controller
    {
        private readonly ILecturesPoolService _service;
        public LecturesPoolController(ILecturesPoolService service)
        {
            _service = service;
        }

        [Route("/Admin/LecturesPool")]
        public async Task<IActionResult> LecturesPool(int offset = 1)
        {
            ViewData["Page"] = offset;
            int Pages = _service.GetCountPages();
            ViewData["AllowPage"] = Pages == 0 ? 1 : Pages;
            List<LecturesPool> model = await _service.GetListAsync(offset - 1) ?? new List<LecturesPool>();
            return View(model);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(LecturesPoolInfo info)
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
        public async Task<IActionResult> Edit(LecturesPoolInfo info)
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