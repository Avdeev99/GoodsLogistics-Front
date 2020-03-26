using System.Threading.Tasks;
using AutoMapper;
using GoodsLogistics.Auth.Extensions;
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
            var authResult = await _authService.LoginAsync(loginRequestModel);
            if (!authResult.IsAuthorized)
            {
                foreach (var authResultError in authResult.Errors)
                {
                    ModelState.AddModelError(authResultError.Key, authResultError.Value);
                }

                return View(loginViewModel);
            }

            var claims = ClaimsExtensions.GenerateClaims(authResult.UserCompany);
            var principal = ClaimsExtensions.CreatePrincipal(claims);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Account");
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
            var authResult = await _authService.RegisterAsync(userCompanyCreateRequestModel);

            if (!authResult.IsAuthorized)
            {
                foreach (var authResultError in authResult.Errors)
                {
                    ModelState.AddModelError(authResultError.Key, authResultError.Value);
                }

                return View(model);
            }

            var claims = ClaimsExtensions.GenerateClaims(authResult.UserCompany);
            var principal = ClaimsExtensions.CreatePrincipal(claims);

            await HttpContext.SignInAsync(principal);

            return RedirectToAction("Index", "Account");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}