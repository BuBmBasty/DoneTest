using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Note.Identity.Models;


namespace Note.Identity.Controllers
{    
    public class AuthController: Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;

        public AuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager,  IIdentityServerInteractionService interactionService)
            => (signInManager, userManager, interactionService) = 
            (_signInManager,_userManager,_interactionService);

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel 
            { 
                ReturnUrl = returnUrl 
            };
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid) 
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByNameAsync(viewModel.Username);

            if (user == null) 
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(viewModel);
            }

			var result = await _signInManager.PasswordSignInAsync(viewModel.Username, viewModel.Password, false,false);

			if (result.Succeeded)
			{				
				return Redirect(viewModel.ReturnUrl);
			}

            ModelState.AddModelError(string.Empty, "Login Error");

			return View(viewModel);
        }

        [HttpGet]
        public IActionResult Register (string returnUrl)
        {
            var model = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(returnUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel) ;
            }

            var user = new AppUser
            {
                UserName = viewModel.Username,
            }

            var result = await _userManager.CreateAsync(user, viewModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction(viewModel.ReturnUrl);
            }

            ModelState.AddModelError(string.Empty, "Error occured");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logout)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logout);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}
