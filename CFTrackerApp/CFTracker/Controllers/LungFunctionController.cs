using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CFTrackerServices.Data;
using CFTrackerServices.Models;
using System.Security.Claims;
using CFTrackerServices;
using CFTracker.Models;
using CFTracker.Services;
using Microsoft.AspNetCore.Authorization;

namespace CFTracker.Controllers
{
    public class LungFunctionController : Controller
    {
        private readonly ILogger<LungFunctionController> _logger;
        private readonly UserDB _userDB;
        private readonly LungFunctionViewModel _viewModel;
        private readonly LungFunction _dBModel;

        private string SignedInUserEmail => User.FindFirstValue(ClaimTypes.Email);

        public LungFunctionController(ILogger<LungFunctionController> logger, UserDB userDB, LungFunction dBModel, LungFunctionViewModel viewModel)
        {
            _logger= logger;
            _userDB = userDB;
            _viewModel = viewModel;
            _dBModel = dBModel;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            UserInfo user = await _userDB.GetUserWithLungFunctionsAsync(SignedInUserEmail);

            if (user is null)
            {
                return NotFound();
            }

            List<LungFunction> lungFunctions = user.LungFunctions
                .OrderBy(i => i.Date)
                .ToList();

            return lungFunctions != null ? 
                View(lungFunctions) : 
                Problem("Entity set 'CFTrackerContext.LungFunctions' is null.");
        }

        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            UserInfo user = await _userDB.GetUserWithLungFunctionsAsync(SignedInUserEmail);

            if (id == null || user.LungFunctions == null)
            {
                return NotFound();
            }

            var lungFunction = user.LungFunctions
                .FirstOrDefault(m => m.Id == id);

            if (lungFunction == null)
            {
                return NotFound();
            }

            return View(lungFunction);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Date,Fev,Fvc1,TestingMachine")] LungFunctionViewModel lungFunctionInput)
        {            
            if (ModelState.IsValid)
            {
                var usersInfo = await _userDB.GetUserAsync(SignedInUserEmail);
                var newLungFunction = ModelsMapper.LungFunctionViewModelToDBModel(lungFunctionInput, _dBModel);
                newLungFunction.User = usersInfo;
                await _userDB.AddLungFunctionAsync(newLungFunction);

                return RedirectToAction(nameof(Index));
            }
            return View(lungFunctionInput);
        }

        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            UserInfo user = await _userDB.GetUserWithLungFunctionsAsync(SignedInUserEmail);

            if (id == null || user.LungFunctions == null)
            {
                return NotFound();
            }

            var lungFunction = user.LungFunctions
                .FirstOrDefault(m => m.Id == id);

            if (lungFunction == null)
            {
                return NotFound();
            }
            var lungFunctionView = ModelsMapper.LungFunctionDBModelToViewModel(lungFunction, _viewModel);
            return View(lungFunctionView);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Fev,Fvc1,TestingMachine")] LungFunctionViewModel lungFunction)
        {
            if (id != lungFunction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var lungFunctionDB = ModelsMapper.LungFunctionViewModelToDBModel(lungFunction, _dBModel);
                await _userDB.UpdateLungFunctionAsync(lungFunctionDB);
                
                return RedirectToAction(nameof(Index));
            }
            return View(lungFunction);
        }

        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            var user = await _userDB.GetUserWithLungFunctionsAsync(SignedInUserEmail);

            if (id == null || user.LungFunctions == null)
            {
                return NotFound();
            }

            var lungFunction = user.LungFunctions
                .FirstOrDefault(m => m.Id == id);

            if (lungFunction == null)
            {
                return NotFound();
            }

            return View(lungFunction);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userDB.GetUserWithLungFunctionsAsync(SignedInUserEmail);

            if (user.LungFunctions == null)
            {
                return Problem("Entity set 'CFTrackerContext.LungFunctions'  is null.");
            }

            var lungFunction = user.LungFunctions
                .FirstOrDefault(m => m.Id == id);

            if (lungFunction != null)
            {
                _userDB.DeleteLungFunctionAsync(lungFunction);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
