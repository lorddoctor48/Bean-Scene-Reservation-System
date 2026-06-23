
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using Project_Assessment_Bean_Scene_Registration_Application.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class TablesController : Controller
{
    private readonly ApplicationDbContext _context;

    public TablesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: TABLES
    public async Task<IActionResult> Index()
    {
        var applicationDbContext = _context.Table.Include(s => s.TableArea);
        return View(await applicationDbContext.ToListAsync());
    }

    // GET: TABLES/Details/5
    public async Task<IActionResult> Details(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var table = await _context.Table
            .FirstOrDefaultAsync(m => m.TableNo == id);
        if (table == null)
        {
            return NotFound();
        }

        return View(table);
    }

    // GET: TABLES/Create
    public IActionResult Create()
    {
        ViewData["TableAreaId"] = new SelectList(_context.TableAreas, "TableAreaId", "Area");
        return View();
    }

    // POST: TABLES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("TableNo,TableAreaId,")] Project_Assessment_Bean_Scene_Registration_Application.Models.Table table)
    {
        if (!ModelState.IsValid)
        {
            return View(table);
        }

        if (ModelState.IsValid)
        {
            _context.Add(table);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        ViewData["TableAreaId"] = new SelectList(_context.TableAreas, "TableAreaId", "Area");
        return View(table);
    }

    // GET: TABLES/Edit/5
    public async Task<IActionResult> Edit(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var table = await _context.Table.FindAsync(id);
        if (table == null)
        {
            return NotFound();
        }

        ViewData["TableAreaId"] = new SelectList(_context.TableAreas, "TableAreaId","Area",table.TableAreaId);

        return View(table);
    }

    // POST: TABLES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string? id, [Bind("TableNo,TableAreaId")] Project_Assessment_Bean_Scene_Registration_Application.Models.Table table)
    {
        if (id != table.TableNo)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(table);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TableExists(table.TableNo))
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
        ViewData["TableAreaId"] = new SelectList(_context.TableAreas, "TableAreaId", "TableArea", table.TableAreaId);
        return View(table);
    }

    // GET: TABLES/Delete/5
    public async Task<IActionResult> Delete(string? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var table = await _context.Table
            .FirstOrDefaultAsync(m => m.TableNo == id);
        if (table == null)
        {
            return NotFound();
        }

        return View(table);
    }

    // POST: TABLES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string? id)
    {
        var table = await _context.Table.FindAsync(id);
        if (table != null)
        {
            _context.Table.Remove(table);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TableExists(string? id)
    {
        return _context.Table.Any(e => e.TableNo == id);
    }
}
