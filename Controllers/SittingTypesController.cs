//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Rendering;
//using Microsoft.EntityFrameworkCore;
//using Project_Assessment_Bean_Scene_Registration_Application.Data;
//using Project_Assessment_Bean_Scene_Registration_Application.Models;

//namespace Project_Assessment_Bean_Scene_Registration_Application.Controllers
//{
//    public class SittingTypesController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public SittingTypesController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: SittingTypes
//        public async Task<IActionResult> Index()
//        {
//            return View(await _context.SittingTypes.ToListAsync());
//        }

//        // GET: SittingTypes/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var sittingType = await _context.SittingTypes
//                .FirstOrDefaultAsync(m => m.SittingTypeId == id);
//            if (sittingType == null)
//            {
//                return NotFound();
//            }

//            return View(sittingType);
//        }

//        // GET: SittingTypes/Create
//        public IActionResult Create()
//        {
//            return View();
//        }

//        // POST: SittingTypes/Create
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create([Bind("SittingTypeId,SittingTitle")] SittingType sittingType)
//        {
//            if (ModelState.IsValid)
//            {
//                _context.Add(sittingType);
//                await _context.SaveChangesAsync();
//                return RedirectToAction(nameof(Index));
//            }
//            return View(sittingType);
//        }

//        // GET: SittingTypes/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var sittingType = await _context.SittingTypes.FindAsync(id);
//            if (sittingType == null)
//            {
//                return NotFound();
//            }
//            return View(sittingType);
//        }

//        // POST: SittingTypes/Edit/5
//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("SittingTypeId,SittingTitle")] SittingType sittingType)
//        {
//            if (id != sittingType.SittingTypeId)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(sittingType);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!SittingTypeExists(sittingType.SittingTypeId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            return View(sittingType);
//        }

//        // GET: SittingTypes/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var sittingType = await _context.SittingTypes
//                .FirstOrDefaultAsync(m => m.SittingTypeId == id);
//            if (sittingType == null)
//            {
//                return NotFound();
//            }

//            return View(sittingType);
//        }

//        // POST: SittingTypes/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var sittingType = await _context.SittingTypes.FindAsync(id);
//            if (sittingType != null)
//            {
//                _context.SittingTypes.Remove(sittingType);
//            }

//            await _context.SaveChangesAsync();
//            return RedirectToAction(nameof(Index));
//        }

//        private bool SittingTypeExists(int id)
//        {
//            return _context.SittingTypes.Any(e => e.SittingTypeId == id);
//        }
//    }
//}
