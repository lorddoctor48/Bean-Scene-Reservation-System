
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using Project_Assessment_Bean_Scene_Registration_Application.Data;

public class ReservationSourcesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReservationSourcesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: RESERVATIONSOURCES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.ReservationsSource.ToListAsync());
    }

    // GET: RESERVATIONSOURCES/Details/5
    public async Task<IActionResult> Details(int? sourcetitleid)
    {
        if (sourcetitleid == null)
        {
            return NotFound();
        }

        var reservationsource = await _context.ReservationsSource
            .FirstOrDefaultAsync(m => m.SourceTitleId == sourcetitleid);
        if (reservationsource == null)
        {
            return NotFound();
        }

        return View(reservationsource);
    }

    // GET: RESERVATIONSOURCES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RESERVATIONSOURCES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SourceTitleId,SourceTitle")] ReservationSource reservationsource)
    {
        if (ModelState.IsValid)
        {
            _context.Add(reservationsource);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(reservationsource);
    }

    // GET: RESERVATIONSOURCES/Edit/5
    public async Task<IActionResult> Edit(int? sourcetitleid)
    {
        if (sourcetitleid == null)
        {
            return NotFound();
        }

        var reservationsource = await _context.ReservationsSource.FindAsync(sourcetitleid);
        if (reservationsource == null)
        {
            return NotFound();
        }
        return View(reservationsource);
    }

    // POST: RESERVATIONSOURCES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? sourcetitleid, [Bind("SourceTitleId,SourceTitle")] ReservationSource reservationsource)
    {
        if (sourcetitleid != reservationsource.SourceTitleId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(reservationsource);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationSourceExists(reservationsource.SourceTitleId))
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
        return View(reservationsource);
    }

    // GET: RESERVATIONSOURCES/Delete/5
    public async Task<IActionResult> Delete(int? sourcetitleid)
    {
        if (sourcetitleid == null)
        {
            return NotFound();
        }

        var reservationsource = await _context.ReservationsSource
            .FirstOrDefaultAsync(m => m.SourceTitleId == sourcetitleid);
        if (reservationsource == null)
        {
            return NotFound();
        }

        return View(reservationsource);
    }

    // POST: RESERVATIONSOURCES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? sourcetitleid)
    {
        var reservationsource = await _context.ReservationsSource.FindAsync(sourcetitleid);
        if (reservationsource != null)
        {
            _context.ReservationsSource.Remove(reservationsource);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReservationSourceExists(int? sourcetitleid)
    {
        return _context.ReservationsSource.Any(e => e.SourceTitleId == sourcetitleid);
    }
}
