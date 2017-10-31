using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Twilio31.Models;
using System.Threading.Tasks;
using Twilio31.ViewModels;

namespace Twilio31.Controllers
{
    public class AccountController : Controller
{
	private readonly Twilio31Context _db;
	private readonly UserManager<ApplicationUser> _userManager;
	private readonly SignInManager<ApplicationUser> _signInManager;

	public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, Twilio31Context db)
	{
		_userManager = userManager;
		_signInManager = signInManager;
		_db = db;
	}

	public IActionResult Index()
	{
		return View();
	}

	public IActionResult Register()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Register(RegisterViewModel model)
	{
		var user = new ApplicationUser { UserName = model.Email };
		IdentityResult result = await _userManager.CreateAsync(user, model.Password);
		if (result.Succeeded)
		{
			return RedirectToAction("Index");
		}
		else
		{
			return View();
		}
	}

	public IActionResult Login()
	{
		return View();
	}

	[HttpPost]
	public async Task<IActionResult> Login(LoginViewModel model)
	{
		Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
		if (result.Succeeded)
		{
			return RedirectToAction("Index");
		}
		else
		{
			return View();
		}
	}

	[HttpPost]
	public async Task<IActionResult> LogOff()
	{
		await _signInManager.SignOutAsync();
		return RedirectToAction("Index");
	}
}
}