
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using Project_Assessment_Bean_Scene_Registration_Application.Data;

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
        return View(await _context.Table.ToListAsync());
    }

    // GET: TABLES/Details/5
    public async Task<IActionResult> Details(string? tableno)
    {
        if (tableno == null)
        {
            return NotFound();
        }

        var table = await _context.Table
            .FirstOrDefaultAsync(m => m.TableNo == tableno);
        if (table == null)
        {
            return NotFound();
        }

        return View(table);
    }

    // GET: TABLES/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: TABLES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("TableNo,TableArea,Area,Reservations")] Table table)
    {
        if (ModelState.IsValid)
        {
            _context.Add(table);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(table);
    }

    // GET: TABLES/Edit/5
    public async Task<IActionResult> Edit(string? tableno)
    {
        if (tableno == null)
        {
            return NotFound();
        }

        var table = await _context.Table.FindAsync(tableno);
        if (table == null)
        {
            return NotFound();
        }
        return View(table);
    }

    // POST: TABLES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string? tableno, [Bind("TableNo,TableArea,Area,Reservations")] Table table)
    {
        if (tableno != table.TableNo)
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
        return View(table);
    }

    // GET: TABLES/Delete/5
    public async Task<IActionResult> Delete(string? tableno)
    {
        if (tableno == null)
        {
            return NotFound();
        }

        var table = await _context.Table
            .FirstOrDefaultAsync(m => m.TableNo == tableno);
        if (table == null)
        {
            return NotFound();
        }

        return View(table);
    }

    // POST: TABLES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string? tableno)
    {
        var table = await _context.Table.FindAsync(tableno);
        if (table != null)
        {
            _context.Table.Remove(table);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool TableExists(string? tableno)
    {
        return _context.Table.Any(e => e.TableNo == tableno);
    }
}
