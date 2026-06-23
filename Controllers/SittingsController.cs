using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Data;
using Project_Assessment_Bean_Scene_Registration_Application.Models;

namespace Project_Assessment_Bean_Scene_Registration_Application.Controllers
{
    public class SittingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SittingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sittings
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sittings.Include(s => s.SittingType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sittings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings
                .Include(s => s.SittingType)
                .FirstOrDefaultAsync(m => m.SittingId == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // GET: Sittings/Create
        public IActionResult Create()
        {
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "SittingTypeId", "SittingTitle");
            return View();
        }

        // POST: Sittings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SittingId,SittingTypeId,SittingDate,SittingStartTime,SittingEndTime,SittingCapacity,IsClosed,ClosureDate,ClosureReason")] Sitting sitting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sitting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "SittingTypeId", "SittingTitle", sitting.SittingTypeId);
            return View(sitting);
        }


        // GET: Sittings/Create
        public IActionResult BulkCreateOnRange()
        {
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "SittingTypeId", "SittingTitle");
            return View();
        }

        // POST: Sittings/BulkCreateOnRange
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BulkCreateOnRange([Bind("SittingId,SittingTypeId,SittingStartDate,SittingEndDate,SittingStartTime,SittingEndTime,SittingCapacity,IsClosed,ClosureDate,ClosureReason")] Sitting sitting) //A custom method for creating multiple sittings based on the range between start and end date.
        {
            if (!ModelState.IsValid) //checking whether the inputted fields 
            {
                ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "SittingTypeId", "SittingTitle", sitting.SittingTypeId);
                return View(sitting);
            }

            /* A for loop for creating sittings from the inputted start date to the inputted start date */
            for (var date = sitting.SittingStartDate; date <= sitting.SittingEndDate; date = date.AddDays(1)) //AddDays method to create a date instance for every sitting records being bulk inserted into the database
            {
                var newSitting = new Sitting
                {

                    /* Creating values for the each new sitting records */
                    SittingTypeId = sitting.SittingTypeId,
                    SittingDate = date,
                    SittingStartTime = sitting.SittingStartTime,
                    SittingEndTime = sitting.SittingEndTime,
                    SittingCapacity = sitting.SittingCapacity,
                    IsClosed = sitting.IsClosed,
                    ClosureDate = sitting.ClosureDate,
                    ClosureReason = sitting.ClosureReason
                };

                _context.Sittings.Add(newSitting); //Adding new sitting records into the ApplicationDbContext
            }
            await _context.SaveChangesAsync(); //Saves the newly created sittings records
            return RedirectToAction(nameof(Index)); //Redirect the user to the index page of 
        }

        // GET: Sittings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings.FindAsync(id);
            if (sitting == null)
            {
                return NotFound();
            }
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "SittingTypeId", "SittingTitle", sitting.SittingTypeId);
            return View(sitting);
        }

        // POST: Sittings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SittingId,SittingTypeId,SittingDate,SittingStartTime,SittingEndTime,SittingCapacity,IsClosed,ClosureDate,ClosureReason")] Sitting sitting)
        {
            if (id != sitting.SittingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sitting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SittingExists(sitting.SittingId))
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
            ViewData["SittingTypeId"] = new SelectList(_context.SittingTypes, "SittingTypeId", "SittingTitle", sitting.SittingTypeId);
            return View(sitting);
        }

        // GET: Sittings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sitting = await _context.Sittings
                .Include(s => s.SittingType)
                .FirstOrDefaultAsync(m => m.SittingId == id);
            if (sitting == null)
            {
                return NotFound();
            }

            return View(sitting);
        }

        // POST: Sittings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sitting = await _context.Sittings.FindAsync(id);
            if (sitting != null)
            {
                _context.Sittings.Remove(sitting);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SittingExists(int id)
        {
            return _context.Sittings.Any(e => e.SittingId == id);
        }
    }
}
