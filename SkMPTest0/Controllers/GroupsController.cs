using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services.Groups.Abstractions;
using Domain.Services.Groups.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SkMPTest0.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("[controller]")]
    public class GroupsController : Controller
    {
        private readonly IGroupsService _service;
        public GroupsController(IGroupsService service)
        {
            _service = service;
        }

        [Route("/Admin/Groups")]
        public async Task<IActionResult> Groups(int offset = 1)
        {
            ViewData["Page"] = offset;
            int Pages = _service.GetCountPages();
            ViewData["AllowPage"] = Pages == 0 ? 1 : Pages;
            List<Groups> model = await _service.GetListAsync(offset - 1) ?? new List<Groups>();
            return View(model);
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(GroupInfo info)
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
        public async Task<IActionResult> Edit(GroupInfo info)
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