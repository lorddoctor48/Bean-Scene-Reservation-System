
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using Project_Assessment_Bean_Scene_Registration_Application.Data;

public class ReservationsController : Controller
{
    private readonly ApplicationDbContext _context;

    public ReservationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: RESERVATIONS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Reservations.ToListAsync());
    }

    // GET: RESERVATIONS/Details/5
    public async Task<IActionResult> Details(int? reservationid)
    {
        if (reservationid == null)
        {
            return NotFound();
        }

        var reservation = await _context.Reservations
            .FirstOrDefaultAsync(m => m.ReservationID == reservationid);
        if (reservation == null)
        {
            return NotFound();
        }

        return View(reservation);
    }

    // GET: RESERVATIONS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: RESERVATIONS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ReservationID,MemberID,Sitting,SittingId,FirstName,LastName,Email,PhoneNo,ReservationDate,ReservationStartTime,ReservationEndTime,NumberOfPeople,SourceTitleId,ReservationSource,SpecialRequests,Notes,StatusId,Status,Table")] Reservation reservation)
    {
        if (ModelState.IsValid)
        {
            _context.Add(reservation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(reservation);
    }

    // GET: RESERVATIONS/Edit/5
    public async Task<IActionResult> Edit(int? reservationid)
    {
        if (reservationid == null)
        {
            return NotFound();
        }

        var reservation = await _context.Reservations.FindAsync(reservationid);
        if (reservation == null)
        {
            return NotFound();
        }
        return View(reservation);
    }

    // POST: RESERVATIONS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? reservationid, [Bind("ReservationID,MemberID,Sitting,SittingId,FirstName,LastName,Email,PhoneNo,ReservationDate,ReservationStartTime,ReservationEndTime,NumberOfPeople,SourceTitleId,ReservationSource,SpecialRequests,Notes,StatusId,Status,Table")] Reservation reservation)
    {
        if (reservationid != reservation.ReservationID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(reservation);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(reservation.ReservationID))
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
        return View(reservation);
    }

    // GET: RESERVATIONS/Delete/5
    public async Task<IActionResult> Delete(int? reservationid)
    {
        if (reservationid == null)
        {
            return NotFound();
        }

        var reservation = await _context.Reservations
            .FirstOrDefaultAsync(m => m.ReservationID == reservationid);
        if (reservation == null)
        {
            return NotFound();
        }

        return View(reservation);
    }

    // POST: RESERVATIONS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? reservationid)
    {
        var reservation = await _context.Reservations.FindAsync(reservationid);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ReservationExists(int? reservationid)
    {
        return _context.Reservations.Any(e => e.ReservationID == reservationid);
    }
}
