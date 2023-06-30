using Microsoft.AspNetCore.Mvc;
using CFTrackerServices.Models;
using CFTrackerServices;
using CFTracker.Models;
using System.Security.Claims;
using CFTracker.Mappers;
using Microsoft.AspNetCore.Authorization;

namespace CFTracker.Controllers
{
    public class BodyMassIndexController : Controller
    {
        private readonly ILogger<BodyMassIndexController> _logger;
        private readonly UserDB _userDB;
        private readonly BodyMassIndexViewModel _viewModel;
        private readonly BodyMassIndex _dBModel;

        private string SignedInUserEmail => User.FindFirstValue(ClaimTypes.Email);

        public BodyMassIndexController(ILogger<BodyMassIndexController> logger, UserDB userDB, BodyMassIndexViewModel viewModel, BodyMassIndex dBModel)
        {
            _logger = logger;
            _userDB = userDB;
            _viewModel = viewModel;
            _dBModel = dBModel;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            UserInfo user = await _userDB.GetUserWithBodyMassIndexesAsync(SignedInUserEmail);

            if (user is null)
            {
                return NotFound();
            }
            List<BodyMassIndex> bodyMassIndexes = user.BodyMassIndexes
                .OrderBy(i => i.Date)
                .ToList();

            return bodyMassIndexes != null ?
                View(bodyMassIndexes) :
                Problem("Entity set 'CFTrackerContext.BodyMassIndexes' is null.");
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            UserInfo user = await _userDB.GetUserWithBodyMassIndexesAsync(SignedInUserEmail);

            if (id == null || user.BodyMassIndexes == null)
            {
                return NotFound();
            }

            var bodyMassIndex = user.BodyMassIndexes
                .FirstOrDefault(m => m.Id == id);

            if (bodyMassIndex == null)
            {
                return NotFound();
            }

            return View(bodyMassIndex);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,WeightKg,WeightTestingMachine,HeightCm,HeightTestingMachine,Bmi")] BodyMassIndexViewModel bodyMassIndexInput)
        {
            if (ModelState.IsValid)
            {
                var userInfo = await _userDB.GetUserAsync(SignedInUserEmail);
                var newBodyMassIndex = bodyMassIndexInput.ToDBModel(_dBModel);
                newBodyMassIndex.User = userInfo;
                await _userDB.AddBodyMassIndexAsync(newBodyMassIndex);

                return RedirectToAction(nameof(Index));
            }
            return View(bodyMassIndexInput);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            UserInfo user = await _userDB.GetUserWithBodyMassIndexesAsync(SignedInUserEmail);

            if (id == null || user.BodyMassIndexes == null)
            {
                return NotFound();
            }

            var bodyMassIndex = user.BodyMassIndexes
                .FirstOrDefault(m => m.Id == id);

            if (bodyMassIndex == null)
            {
                return NotFound();
            }
            var bodyMassIndexView = bodyMassIndex.ToViewModel(_viewModel);
            return View(bodyMassIndexView);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,WeightKg,WeightTestingMachine,HeightCm,HeightTestingMachine,Bmi")] BodyMassIndexViewModel bodyMassIndex)
        {
            if (id != bodyMassIndex.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var bodyMassIndexDB = bodyMassIndex.ToDBModel(_dBModel);
                await _userDB.UpdateBodyMassIndexAsync(bodyMassIndexDB);

                return RedirectToAction(nameof(Index));
            }
            return View(bodyMassIndex);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userDB.GetUserWithBodyMassIndexesAsync(SignedInUserEmail);

            if (id == null || user.BodyMassIndexes == null)
            {
                return NotFound();
            }

            var bodyMassIndex = user.BodyMassIndexes
                .FirstOrDefault(m => m.Id == id);

            if (bodyMassIndex == null)
            {
                return NotFound();
            }

            return View(bodyMassIndex);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            UserInfo user = await _userDB.GetUserWithBodyMassIndexesAsync(SignedInUserEmail);

            if (user.BodyMassIndexes == null)
            {
                return Problem("Entity set 'CFTrackerContext.BodyMassIndexes'  is null.");
            }
            var bodyMassIndex = user.BodyMassIndexes
                .FirstOrDefault(m => m.Id == id);

            if (bodyMassIndex != null)
            {
                _userDB.DeleteBodyMassIndexAsync(bodyMassIndex);
            }
            
            return RedirectToAction(nameof(Index));
        }
    }
}
