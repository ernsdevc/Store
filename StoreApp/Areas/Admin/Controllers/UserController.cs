using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _manager;

        public UserController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var users = _manager.AuthService.GetAllUsers();
            return View(users);
        }

        public IActionResult CreateUser()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_manager.AuthService.Roles.Select(r => r.Name).ToList())
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser([FromForm] UserDtoForCreation userDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _manager.AuthService.CreateUser(userDto);
                return result.Succeeded ? RedirectToAction("Index") : View();
            }
            return View(userDto);
        }

        public async Task<IActionResult> UpdateUser([FromRoute(Name = "id")] string id)
        {
            var user = await _manager.AuthService.GetOneUserForUpdate(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateUser([FromForm] UserDtoForUpdate userDto)
        {
            if (ModelState.IsValid)
            {
                await _manager.AuthService.UpdateUser(userDto);
                return RedirectToAction("Index");
            }
            return View(userDto);
        }

        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new ResetPasswordDto()
            {
                UserName = id
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _manager.AuthService.ResetPassword(dto);
                return result.Succeeded ? RedirectToAction("Index") : View();
            }
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser([FromForm] UserDto userDto)
        {
            var result = await _manager.AuthService.DeleteOneUser(userDto.UserName);
            return result.Succeeded ? RedirectToAction("Index") : View();
        }
    }
}