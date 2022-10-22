using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TE_CodeFirst.Data;
using TE_CodeFirst.Models;
using NToastNotify;

namespace TE_CodeFirst.Controllers
{
    public class TraineesController : Controller
    {
        // NToastNotify
        private readonly ILogger<TraineesController> _logger;
        private readonly IToastNotification _toastNotification;
        private readonly TE_CodeFirstContext _context;

        public TraineesController(ILogger<TraineesController> logger, IToastNotification toastNotification, TE_CodeFirstContext context)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _context = context;
        }

        // GET: Trainees
        public async Task<IActionResult> Index()
        {
              return View(await _context.Trainee.ToListAsync());
        }

        // GET: Trainees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trainee == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainee
                .FirstOrDefaultAsync(m => m.TraineeID == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TraineeID,TraineeName,TraineeAge,TraineeDOJ,TraineeDOB,TraineeMobile,TraineeEmail,TraineePassword,TraineeConfirmPassword")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainee);
                await _context.SaveChangesAsync();
                //toastNotification in green color - > SUCCESS
                _toastNotification.AddSuccessToastMessage("Employee created successfully");
                return RedirectToAction(nameof(Index));
            }
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trainee == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainee.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TraineeID,TraineeName,TraineeAge,TraineeDOJ,TraineeDOB,TraineeMobile,TraineeEmail,TraineePassword,TraineeConfirmPassword")] Trainee trainee)
        {
            if (id != trainee.TraineeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainee);
                    await _context.SaveChangesAsync();
                    //toastNotification in yellow color - > WARNING
                    _toastNotification.AddWarningToastMessage("Employee updated successfully");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.TraineeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trainee == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainee
                .FirstOrDefaultAsync(m => m.TraineeID == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trainee == null)
            {
                return Problem("Entity set 'TE_CodeFirstContext.Trainee'  is null.");
            }
            var trainee = await _context.Trainee.FindAsync(id);
            if (trainee != null)
            {
                _context.Trainee.Remove(trainee);
            }
            
            await _context.SaveChangesAsync();
            //toastNotification in red color - > Error
            _toastNotification.AddErrorToastMessage("Employee deleted successfully");
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
          return _context.Trainee.Any(e => e.TraineeID == id);
        }
    }
}
