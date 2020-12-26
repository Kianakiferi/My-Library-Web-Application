using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using WebApplication3.Models;
using WebApplication3.ViewModels;

namespace WebApplication3.Controllers
{
	public class AccountController : Controller
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly SignInManager<ApplicationUser> _signInManager;

		private readonly ILogger<AccountController> _logger;

		public AccountController
			(
				UserManager<ApplicationUser> userManager,
				SignInManager<ApplicationUser> signInManager,
				ILogger<AccountController> logger
			)
		{
			_userManager = userManager;
			_signInManager = signInManager;
			_logger = logger;
		}

		public async Task<IActionResult> Index()
		{
			if (_signInManager.IsSignedIn(User))
			{
				var user = await _userManager.GetUserAsync(User);
				if (user == null)
				{
					return RedirectToAction("InternalError", "Error");
				}
				var userViewModel = new UserViewModel
				{
					Id = user.Id,
					UUID = user.UUID,
					UserName = user.UserName,
					Email = user.Email,
					BorrowQuantity = (int)user.UserBorrowQuantity
				};
				return View(userViewModel);
			}

			return RedirectToAction(nameof(SignIn));
		}


		[HttpGet]
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel viewModel, string ReturnUrl)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync
					(
						viewModel.UserName,
						viewModel.Password,
						viewModel.RememberMe,
						lockoutOnFailure: false
					);

				if (result.Succeeded)
				{
					_logger.LogInformation("User logged in.");
					return RedirectToAction(nameof(Index), "Home");
				}
				if (result.RequiresTwoFactor)
				{
					return RedirectToAction(nameof(TwoFactorAuthentication));
				}
				if (result.IsLockedOut)
				{
					_logger.LogWarning("User account locked out.");
					return Forbid();
				}
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Invalid login attempt.");
				return View();
			}

			return View();
		}

		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(Login));
		}


		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var user = new ApplicationUser
				{
					UserName = viewModel.UserName,
					UserBorrowQuantity = 0,
					UserGenderId = 0,
					UserRegisterDate = DateTime.Now,

				};
				var result = await _userManager.CreateAsync(user, viewModel.Password);

				if (result.Succeeded)
				{
					_logger.LogInformation("User created a new account with password.");

					await _signInManager.SignInAsync(user, isPersistent: false);
					return RedirectToAction(nameof(Index));
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}

			// If we got this far, something failed, redisplay form
			return View();
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> Edit()
		{
			if (_signInManager.IsSignedIn(User))
			{
				var user = await _userManager.GetUserAsync(User);
				if (user == null)
				{
					return RedirectToAction("InternalError", "Error");
				}
				return View(new EditViewModel
				{
					UUID = user.UUID,
					UserName = user.UserName,
					Email = user.Email
				});
			}

			return RedirectToAction(nameof(SignIn));
		}

		[HttpPost]
		public async Task<IActionResult> Edit(EditViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.GetUserAsync(User);

				user.UUID = viewModel.UUID;
				user.UserName = viewModel.UserName;
				user.Email = viewModel.Email;

				
				var result = await _userManager.UpdateAsync(user);
				if (result.Succeeded)
				{
					return RedirectToAction(nameof(Index));
				}

				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View(viewModel);
		}

		public async Task<IActionResult> List()
		{
			return View(await _userManager.Users.ToListAsync());
		}

		public IActionResult TwoFactorAuthentication()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Delete()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound();
			}

			return View(user);
		}

		[HttpPost, ActionName("Delete")]
		[Authorize]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed()
		{
			var user = await _userManager.GetUserAsync(User);
			if (user == null)
			{
				return NotFound();
			}

			var result = await _userManager.DeleteAsync(user);
			var userId = await _userManager.GetUserIdAsync(user);
			if (!result.Succeeded)
			{
				throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{userId}'.");
			}

			await _signInManager.SignOutAsync();

			_logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

			return RedirectToAction(nameof(Login));
		}
	}
}
