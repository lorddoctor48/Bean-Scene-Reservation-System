
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using Project_Assessment_Bean_Scene_Registration_Application.Data;

public class TableAreasController : Controller
{
    private readonly ApplicationDbContext _context;

    public TableAreasController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: TABLEAREAS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.TableAreas.ToListAsync());
    }

    // GET: TABLEAREAS/Details/5
    public async Task<IActionResult> Details(string? area)
    {
        if (area == null)
        {
            return NotFound();
        }

        var tablearea = await _context.TableAreas
            .FirstOrDefaultAsync(m => m.Area == area);
        if (tablearea == null)
        {
            return NotFound();
        }

        return View(tablearea);
    }

    // GET: TABLEAREAS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TABLEAREAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Area")] TableArea tablearea)
    {
        if (ModelState.IsValid)
        {
            _context.Add(tablearea);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(tablearea);
    }

    // GET: TABLEAREAS/Edit/5
    public async Task<IActionResult> Edit(string? area)
    {
        if (area == null)
        {
            return NotFound();
        }

        var tablearea = await _context.TableAreas.FindAsync(area);
        if (tablearea == null)
        {
            return NotFound();
        }
        return View(tablearea);
    }

    // POST: TABLEAREAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string? area, [Bind("Area")] TableArea tablearea)
    {
        if (area != tablearea.Area)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(tablearea);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableAreaExists(tablearea.Area))
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
        return View(tablearea);
    }

    // GET: TABLEAREAS/Delete/5
    public async Task<IActionResult> Delete(string? area)
    {
        if (area == null)
        {
            return NotFound();
        }

        var tablearea = await _context.TableAreas
            .FirstOrDefaultAsync(m => m.Area == area);
        if (tablearea == null)
        {
            return NotFound();
        }

        return View(tablearea);
    }

    // POST: TABLEAREAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string? area)
    {
        var tablearea = await _context.TableAreas.FindAsync(area);
        if (tablearea != null)
        {
            _context.TableAreas.Remove(tablearea);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TableAreaExists(string? area)
    {
        return _context.TableAreas.Any(e => e.Area == area);
    }
}
