using System.Globalization;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GoodsLogistics.Auth.Constants;
using GoodsLogistics.Auth.Extensions;
using GoodsLogistics.Auth.Options;
using GoodsLogistics.Auth.Services.Interfaces;
using GoodsLogistics.Localization.Resources;
using GoodsLogistics.Models.DTO.UserCompany;
using GoodsLogistics.Services.Data.Services.Interfaces;
using GoodsLogistics.ViewModels.DTO;
using GoodsLogistics.Web.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GoodsLogistics.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IOptions<CookieAuthOptions> _cookieAuthOptions;
        private readonly IUserCompanyService _userCompanyService;
        private readonly ICookiesService _cookiesService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public AccountController(
            IUserCompanyService userCompanyService, 
            ICookiesService cookiesService, IMapper mapper, 
            IAuthService authService,
            IOptions<CookieAuthOptions> cookieAuthOptions)
        {
            _userCompanyService = userCompanyService;
            _cookiesService = cookiesService;
            _mapper = mapper;
            _authService = authService;
            _cookieAuthOptions = cookieAuthOptions;
        }

        public async Task<IActionResult> Index(string status)
        {
            var email = User.FindFirst(ClaimTypes.Email).Value;
            var serviceResponse = await _userCompanyService.GetUserCompany(email);
            var userCompanyViewModel = _mapper.Map<UserCompanyViewModel>(serviceResponse.Data);
            ViewBag.Status = status;

            return View(userCompanyViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserCompanyViewModel userViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userViewModel);
            }

            var email = User.FindFirst(ClaimTypes.Email).Value;
            var updateRequestModel = _mapper.Map<UserCompanyUpdateRequestModel>(userViewModel);
            var serviceResponse = await _userCompanyService.UpdateUserCompany(email, updateRequestModel);
            var userCompanyViewModel = _mapper.Map<UserCompanyViewModel>(serviceResponse.Data);

            ViewBag.Status = Resources.PersonalDataWasChangedSuccessfully;

            return View(userCompanyViewModel);
        }

        public IActionResult ChangePassword(string status)
        {
            ViewBag.Status = status;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(changePasswordViewModel);
            }

            var email = User.FindFirst(ClaimTypes.Email).Value;
            var response = await _userCompanyService.GetUserCompany(email);
            var updateRequestModel = _mapper.Map<UserCompanyUpdateRequestModel>(response.Data);
            updateRequestModel.OldPassword = changePasswordViewModel.OldPassword;
            updateRequestModel.NewPassword = changePasswordViewModel.NewPassword;

            var serviceResponse = await _userCompanyService.UpdateUserCompany(email, updateRequestModel);
            if (!serviceResponse.IsSuccess)
            {
                ModelState.AddModelErrors(serviceResponse.Errors);
                return View(changePasswordViewModel);
            }

            var loginRequestModel = new UserCompanyLoginRequestModel()
            {
                Email = email,
                Password = changePasswordViewModel.NewPassword
            };

            var authResult = await _authService.LoginAsync(loginRequestModel);

            _cookiesService.SetCookie(
                AuthConstants.JwtToken,
                authResult.JwtToken,
                _cookieAuthOptions.Value.ExpirationTimeInSeconds);

            var claims = ClaimsExtensions.GenerateClaims(authResult.UserCompany);
            var principal = ClaimsExtensions.CreatePrincipal(claims);

            await HttpContext.SignInAsync(principal);

            ViewBag.Status = Resources.PasswordWasChangedSuccessfully;

            return View(changePasswordViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            _cookiesService.RemoveCookie(AuthConstants.JwtToken);
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}