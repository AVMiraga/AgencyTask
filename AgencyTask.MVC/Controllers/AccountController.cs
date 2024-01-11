using AgencyTask.Business.Services.Interfaces;
using AgencyTask.Business.ViewModels.UserVms;
using AgencyTask.Core.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgencyTask.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _accountService;
        private readonly IMapper _mapper;
        public AccountController(
        SignInManager<AppUser> signInManager,
        IAccountService accountService,
        RoleManager<IdentityRole> roleManager,
        IMapper mapper)
        {
            _signInManager = signInManager;
            _accountService = accountService;
            _roleManager = roleManager;
            _mapper = mapper;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm, string? returnUrl)
        {
            var result = await _accountService.RegisterAsync(registerVm);

            if (result.Result is null)
            {
                ModelState.AddModelError("", "Something went wrong.");
                return View(registerVm);
            }

            if (!result.Result.Succeeded)
            {
                foreach (var error in result.Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(registerVm);
            }

            await _signInManager.SignInAsync(result.User, false);

            if (returnUrl != null && returnUrl != "/Account/Login" && returnUrl != "/Account/Register")
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm, string? returnUrl)
        {
            AppUser user = await _accountService.ValidateUserCredentialsAsync(loginVm);

            if (user is null)
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
                return View(loginVm);
            }

            var result = _signInManager.PasswordSignInAsync(user, loginVm.Password, true, true).Result;

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account is locked out.");
                return View(loginVm);
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
                return View(loginVm);
            }

            if (returnUrl != null && returnUrl != "/Account/Login" && returnUrl != "/Account/Register")
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateRole()
        {
            await _accountService.CreateRoleAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
