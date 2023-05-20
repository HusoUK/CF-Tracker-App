using CFTracker.Models;
using CFTracker.Services;
using CFTrackerServices;
using CFTrackerServices.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CFTracker.Controllers
{
	public class UserInfoController : Controller
	{
		private readonly ILogger<UserInfoController> _logger;
		private readonly UserDB _userDBAccess;
		private readonly UserInfoViewModel _viewModel;
		private readonly UserInfo _dBModel;

		private string SignedInUserEmail => User.FindFirstValue(ClaimTypes.Email);


		public UserInfoController(ILogger<UserInfoController> logger, UserDB userDBAccess, UserInfoViewModel viewModel, UserInfo dBModel)
		{
			_logger = logger;
			_userDBAccess = userDBAccess;
			_viewModel = viewModel;
			_dBModel = dBModel;
		}

		[Authorize]
		public async Task<IActionResult> Index()
		{
			UserInfo userDBInfo = await _userDBAccess.GetUserAsync(SignedInUserEmail);

			if (userDBInfo != null)
			{
				UserInfoViewModel userInfo = ModelsMapper.UserInfoDBModelToViewModel(userDBInfo, _viewModel);
				return View(userInfo);
			}
			return View();
		}

		[Authorize]
		public IActionResult Create()
		{
			return View();
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("PatientId,FirstName,LastName,DateOfBirth,PhoneNumber,EmailAddress")] UserInfoViewModel userInput)
		{
			if (ModelState.IsValid)
			{
				UserInfo newUser = ModelsMapper.UserInfoViewModelToDBModel(userInput, _dBModel);
				await _userDBAccess.AddUserAsync(newUser);
				var exists = await _userDBAccess.GetUserAsync(newUser.EmailAddress);

				if (exists != null)
				{
					return RedirectToAction("Index", "UserInfo");
				}
				return View(userInput);
			}
			return View(userInput);
		}

		[Authorize]
		public async Task<IActionResult> Edit(string user)
		{
			if (user is null)
			{
				return NotFound();
			}
			
			UserInfo userInfoToEdit = await _userDBAccess.GetUserAsync(user);

			if (userInfoToEdit is null)
			{
				return NotFound();
			}
			return View(userInfoToEdit);
		}

		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(UserInfo updatedUserInfo)
		{
			if (ModelState.IsValid)
			{
				await _userDBAccess.UpdateUserAsync(updatedUserInfo);
				return RedirectToAction("Index", "UserInfo");
			}
			return View(updatedUserInfo);
		}
	}
}
