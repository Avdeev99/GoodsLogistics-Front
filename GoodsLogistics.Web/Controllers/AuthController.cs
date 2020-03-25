using System.Threading.Tasks;
using AutoMapper;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.Services.Data.Services.Interfaces;
using GoodsLogistics.ViewModels.DTO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GoodsLogistics.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;

        public AuthController(IMapper mapper, IAuthService authService)
        {
            _mapper = mapper;
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var loginViewModel = new LoginViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(loginViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(
                    nameof(loginViewModel.Password),
                    "Invalid login or password");
                return View(loginViewModel);
            }

            var loginRequestModel = _mapper.Map<UserCompanyLoginRequestModel>(loginViewModel);
            var token = await _authService.LoginAsync(loginRequestModel);

            return Ok(token);
            return RedirectToAction("Index", "Manage");
        }

        public IActionResult Register(string returnUrl)
        {
            var registerViewModel = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };

            return View(registerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userCompanyCreateRequestModel = _mapper.Map<UserCompanyCreateRequestModel>(model);
            var token = await _authService.RegisterAsync(userCompanyCreateRequestModel);
           
            //var claims = ClaimsFunctions.GenerateClaims(user);
            //var principal = ClaimsFunctions.CreatePrincipal(claims);
            //await HttpContext.SignInAsync(principal);yt

            return Ok(token);
            return RedirectToAction("Index", "Manage");
        }

        //[HttpPost]
        //public async Task<IActionResult> Logout()
        //{
        //    await HttpContext.SignOutAsync();

        //    return RedirectToAction("Index", "Home");
        //}

        //[HttpGet]
        //public IActionResult AccessDenied()
        //{
        //    return View();
        //}
    }
}