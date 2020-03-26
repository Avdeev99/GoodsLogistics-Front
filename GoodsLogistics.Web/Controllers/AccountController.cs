using System.Security.Claims;
using System.Threading.Tasks;
using GoodsLogistics.Services.Data.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GoodsLogistics.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserCompanyService _userCompanyService;

        public AccountController(IUserCompanyService userCompanyService)
        {
            _userCompanyService = userCompanyService;
        }

        public async Task<IActionResult> Index(string status)
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var userCompany = await _userCompanyService.GetUserCompany(email);
            ViewBag.Status = status;

            return View(userCompany);
        }

        public IActionResult ChangePassword(string status)
        {
            ViewBag.Status = status;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}