using Domain.Entities;
using Domain.Services.Users.Abstractions;
using Domain.Services.Users.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Domain.Services.Groups.Abstractions;

namespace SkMPTest0.Controllers
{
    [Authorize(Roles = "Administrator")]
    [Route("[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _service;
        private readonly IGroupsService _groups;

        public UsersController(IUsersService service, IGroupsService groups)
        {
            _service = service;
            _groups = groups;
        }

        [Route("/Admin/Users")]
        public async Task<IActionResult> Users(int offset = 1)
        {
            ViewData["Page"] = offset;
            int Pages = _service.GetCountPages();
            ViewData["AllowPage"] = Pages == 0 ? 1 : Pages;

            List<Groups> groups = await _groups.GetListAsync();
            ViewData["Groups"] = groups.ToArray();

            List<IdentityUser> model = await _service.GetListAsync(offset - 1) ?? new List<IdentityUser>();
            return View(model);
        }

        [Route("/Admin/Users/{id}/")]
        public async Task<IActionResult> Users(string id, int offset = 1)
        {
            ViewData["Page"] = offset;
            int Pages = _service.GetCountPages();
            ViewData["AllowPage"] = Pages == 0 ? 1 : Pages;

            List<Groups> groups = await _groups.GetListAsync();
            ViewData["Groups"] = groups.ToArray();

            List<IdentityUser> model = new List<IdentityUser>();
            model.Add(await _service.GetUserAsync(id));
            return View(model);
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Add(UserInfo info)
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
        public async Task<IActionResult> Edit(UserInfo info)
        {
            await _service.EditAsync(info);
            return Json(new { Status = "Ok" });
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            await _service.DeleteAsync(id);
            return Json(new { Status = "Ok" });
        }
    }
}