
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using Project_Assessment_Bean_Scene_Registration_Application.Data;

public class StatusController : Controller
{
    private readonly ApplicationDbContext _context;

    public StatusController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: STATUSS
    public async Task<IActionResult> Index()
    {
        return View(await _context.Status.ToListAsync());
    }

    // GET: STATUSS/Details/5
    public async Task<IActionResult> Details(int? statusid)
    {
        if (statusid == null)
        {
            return NotFound();
        }

        var status = await _context.Status
            .FirstOrDefaultAsync(m => m.StatusId == statusid);
        if (status == null)
        {
            return NotFound();
        }

        return View(status);
    }

    // GET: STATUSS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: STATUSS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("StatusId,StatusTitle")] Status status)
    {
        if (ModelState.IsValid)
        {
            _context.Add(status);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(status);
    }

    // GET: STATUSS/Edit/5

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var status = await _context.Status.FindAsync(id);
        if (status == null)
        {
            return NotFound();
        }
        return View(status);
    }

    // POST: STATUSS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("StatusId,StatusTitle")] Status status)
    {
        if (id != status.StatusId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(status);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatusExists(status.StatusId))
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
        return View(status);
    }

    // GET: STATUSS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var status = await _context.Status
            .FirstOrDefaultAsync(m => m.StatusId == id);
        if (status == null)
        {
            return NotFound();
        }

        return View(status);
    }

    // POST: STATUSS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? statusid)
    {
        var status = await _context.Status.FindAsync(statusid);
        if (status != null)
        {
            _context.Status.Remove(status);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool StatusExists(int? statusid)
    {
        return _context.Status.Any(e => e.StatusId == statusid);
    }
}
