
using Humanizer.Localisation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Assessment_Bean_Scene_Registration_Application.Data;
using Project_Assessment_Bean_Scene_Registration_Application.Models;
using System.Security.Claims;


namespace Project_Assessment_Bean_Scene_Registration_Application.Controllers
{

    [Authorize(Roles = "Member, Staff, Manager")]
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ReservationsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: RESERVATIONS
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Reservations
            .Include(r => r.Sitting)
            .ThenInclude(s => s.SittingType)
            .Include(r => r.ReservationSource)
            .Include(r => r.Status)
            .Include(r => r.Tables)
            .Include(r => r.User)
            .OrderBy(r => r.Sitting.SittingDate).ThenBy(r => r.ReservationStartTime);

            // Check if user is Member - ONLY display their own reservations
            if (User.IsInRole("Member"))
            {
                // Get user ID for member
                string? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var filteredReservations = applicationDbContext.Where(r => r.UserId == userId);

                // Load view for the member reservation listing
                return View("MemberIndex", await filteredReservations.OrderBy(r => r.ReservationId).ToListAsync());
            }

            //return View(await _context.Reservations.ToListAsync());
            return View(await applicationDbContext.OrderBy(r => r.Sitting.SittingDate).ToListAsync());

        }

        // GET: Reservations/Pending14Days
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Pending14DaysReport()
        {
            var applicationDbContext = _context.Reservations
                .Include(r => r.Sitting)
                .ThenInclude(s => s.SittingType)
                .Include(r => r.User)
                .Include(r => r.Status)
                    .Where(r =>
                    r.StatusId == 1 &&
                    r.Sitting.SittingDate <= DateOnly.FromDateTime(DateTime.Today.AddDays(14)) &&
                    r.Sitting.SittingDate >= DateOnly.FromDateTime(DateTime.Today)
                    )
                    .OrderBy(r => r.Sitting.SittingDate)
                    .ThenBy(r => r.ReservationStartTime);

            // Load Pending14Days "report" view
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Reservations/Sources4Days
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Source30DaysReport()
        {
            var applicationDbContext = _context.Reservations
                .Include(r => r.Sitting)
                .ThenInclude(s => s.SittingType)
                //.Include(r => r.User)
                .Include(r => r.ReservationSource)
                    .Where(r =>
                    r.Sitting.SittingDate >= DateOnly.FromDateTime(DateTime.Today.AddDays(-30)) &&
                    r.Sitting.SittingDate <= DateOnly.FromDateTime(DateTime.Today)
                    )
                    .OrderBy(r => r.Sitting.SittingDate)
                    .ThenBy(r => r.ReservationStartTime);

            // Load Pending14Days "report" view
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Reservations/Cancelled30Days
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Cancellations30DaysReport()
        {
            var applicationDbContext = _context.Reservations
                .Include(r => r.Sitting)
                .ThenInclude(s => s.SittingType)
                .Include(r => r.User)
                .Include(r => r.Status)
                .Include(r => r.Tables)
                    .Where(r =>
                    r.StatusId == 3 && // Cannelled status
                    //r.Sitting.SittingDate >= DateOnly.FromDateTime(DateTime.Today.AddDays(-30)) &&
                    //r.Sitting.SittingDate <= DateOnly.FromDateTime(DateTime.Today)
                    r.Sitting.SittingDate >= DateOnly.FromDateTime(DateTime.Today.AddDays(-30)) &&
                    r.Sitting.SittingDate <= DateOnly.FromDateTime(DateTime.Today)
                    )
                    .OrderBy(r => r.Sitting.SittingDate)
                    .ThenBy(r => r.ReservationStartTime);

            // Load Pending14Days "report" view
            return View(await applicationDbContext.ToListAsync());
        }


        // GET: Reservations/Tables14Days
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Tables30DaysReport()
        {
            var applicationDbContext = _context.Reservations
                   //.Include(r => r.ReservationId)
                   .Include(r => r.Sitting)
                       .ThenInclude(s => s.SittingType).Include(r => r.Status)
                   //.Include(r => r.User)
                   //.Include(r => r.ReservationSource)
                   .Include(r => r.Tables)
                   .Where(r => r
                   .Tables.Any() && // Only include reservations that have tables assigned
                    r.Sitting.SittingDate <= DateOnly.FromDateTime(DateTime.Today) &&
                    r.Sitting.SittingDate >= DateOnly.FromDateTime(DateTime.Today.AddDays(-30))
                    )
                    .OrderBy(r => r.Sitting.SittingDate)
                    .ThenBy(r => r.ReservationStartTime);

            // Load Pending14Days "report" view
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: RESERVATIONS/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: RESERVATIONS/Create
        [AllowAnonymous]
        public async Task<IActionResult> CreateAsync()
        {
            var sittings = _context.Sittings.Include(s => s.SittingType).ToList();

            // Make empty reservation
            Reservation reservation = new();

            // Check if user is Member - prefill their contact details
            if (User.IsInRole("Member"))
            {
                // Get ApplicationUser object from the UserManager (to access our custom properties)
                var user = await _userManager.GetUserAsync(User);

                if (user != null)
                {
                    // Attach contact details against reservation
                    reservation.FirstName = user.FirstName;
                    reservation.LastName = user.LastName;
                    reservation.Email = user.Email;
                    reservation.PhoneNo = user.PhoneNumber;
                }
            }

            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "Description");
            ViewData["SourceTitleId"] = new SelectList(_context.ReservationsSource, "SourceTitleId", "SourceTitle");
            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusTitle");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "FullName");

            return View(reservation);
        }

        // POST: RESERVATIONS/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Create([Bind("ReservationId,UserId,SittingId,FirstName,LastName,Email,PhoneNo,ReservationDate,ReservationStartTime,ReservationEndTime,NumberOfPeople,SourceTitleId,SpecialRequests,Notes,StatusId")] Reservation reservation)
        {
            reservation.StatusId = 1; // Set default status to "Pending" (assuming StatusId 1 corresponds to "Pending")

            reservation.SourceTitleId = 3; // Set default source to "Online" (assuming SourceTitleId 3 corresponds to "Online")


            if (ModelState.IsValid)
            {
                //reservation.ReservationDate = DateOnly.FromDateTime(DateTime.Today);
                //reservation.ReservationDate = reservation.Sitting.SittingDate;

                // Check if user is Member - assign UserId to Reservation
                if (User != null && User.IsInRole("Member"))
                {
                    // Get user ID for member and assign to reservation
                    reservation.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                }

                _context.Add(reservation);
                await _context.SaveChangesAsync();

                // Check if anonymous - redirect to confirmation page (not logged in)
                if (User?.Identity?.IsAuthenticated != true)
                {
                    reservation.Sitting = await _context.Sittings.FindAsync(reservation.SittingId);
                    //return RedirectToAction(actionName: nameof(Index), controllerName: "Home");
                    return View("Confirmation", reservation);
                }

                return RedirectToAction(nameof(Index));
            }

            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "Description");

            //ViewData["SourceTitleId"] = new SelectList(_context.SittingTypes, "SittingTypeId", "SittingTitle", reservation.SourceTitleId);

            ViewData["SourceTitleId"] = new SelectList(_context.ReservationsSource, "SourceTitleId", "SourceTitle", reservation.SourceTitleId);

            //ViewData["StatusId"] = new SelectList(_context.ReservationsSource, "StatusId", "StatusTitle", reservation.StatusId);

            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusTitle", reservation.StatusId);

            return View(reservation);
        }

        // GET: RESERVATIONS/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();


            var reservation = await _context.Reservations
                .Include(r => r.Status).OrderBy(r => r.StatusId)
                .Include(r => r.ReservationSource)
                .Include(r => r.Sitting)
                .Include(r => r.Tables)
                .FirstOrDefaultAsync(r => r.ReservationId == id);

            if (reservation == null)
                return NotFound();

            var sittings = _context.Sittings.Include(s => s.SittingType).ToList();

            var tables = _context.Table.Include(t => t.TableArea).ToList();

            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "Description", reservation.SittingId);

            ViewData["SourceTitleId"] = new SelectList(_context.ReservationsSource, "SourceTitleId", "SourceTitle", reservation.SourceTitleId);

            ViewData["StatusId"] = new SelectList(_context.Status, "StatusId", "StatusTitle", reservation.StatusId);

            //ViewBag["TableNo"] = new MultiSelectList(_context.Table, "TableNo", "TableArea", reservation.Tables.Select(t => t.TableNo));
            PopulateTableLists(reservation);

            return View(reservation);
        }

        // POST: RESERVATIONS/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("ReservationId,MemberID,SittingId,FirstName,LastName,Email,PhoneNo,ReservationDate,ReservationStartTime,ReservationEndTime,NumberOfPeople,SourceTitleId,SpecialRequests,Notes,StatusId")] Reservation reservation)
        {
            if (id != reservation.ReservationId)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.ReservationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            //var existingReservation = await _context.Reservations.Include(r => r.Tables).FirstOrDefaultAsync(r => r.ReservationId == reservation.ReservationId);

            //reservation.Tables = existingReservation?.Tables ?? new List<Table>(); PopulateTableLists(reservation);


            reservation.Tables = await _context.Table.Where(r => r.Reservations.Contains(reservation)).ToListAsync();


            PopulateTableLists(reservation);

            return View(reservation);
        }

        // GET: RESERVATIONS/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: RESERVATIONS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Reservations/AssignRoom
        [HttpPost]
        public async Task<IActionResult> AssignTable(int reservationId, string tableNo)
        {
            // Look up reservation with rooms
            var reservation = await _context.Reservations
                .Include(r => r.Tables)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            // Check if reservation not found
            if (reservation == null)
            {
                return NotFound("Reservation not found.");

            }

            // Look up room
            var table = await _context.Table.FindAsync(tableNo);

            // Check if room not found
            if (table == null)
            {
                return NotFound("Room not found.");
            }

            // Add room to reservation
            reservation.Tables.Add(table);

            // Update database
            _context.Update(reservation);
            await _context.SaveChangesAsync();

            // Redirect to edit view
            return RedirectToAction(nameof(Edit), new { id = reservationId });
        }

        // POST: Reservations/UnassignTable
        [HttpPost]
        [Authorize(Roles = "Staff, Manager")]
        public async Task<IActionResult> UnassignTable(int reservationId, string tableNo)
        {
            // Look up reservation with rooms
            var reservation = await _context.Reservations
                .Include(r => r.Tables)
                .FirstOrDefaultAsync(r => r.ReservationId == reservationId);

            // Check if reservation not found
            if (reservation == null)
            {
                return NotFound("Reservation not found.");
            }

            // Look up room
            var table = await _context.Table.FindAsync(tableNo);

            // Check if room not found
            if (table == null) return NotFound("Room not found.");

            // Remove room from reservation
            reservation.Tables.Remove(table);

            // Update database
            _context.Update(reservation);
            await _context.SaveChangesAsync();

            // Redirect to edit view
            return RedirectToAction(nameof(Edit), new { id = reservationId });
        }


        private bool ReservationExists(int? id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }


        private void PopulateTableLists(Reservation reservation)
        {
            // Get assigned rooms
            var assignedTables = reservation.Tables.Select(r => r.TableNo).ToList();

            // Find ALL room codes that have been assigned for THIS reservation's slot
            var unavailableTables = _context.Reservations
            .Include(r => r.Tables)
            .Where(res =>

            // Check if within same slot
            res.ReservationId != reservation.ReservationId &&
                    res.SittingId == reservation.SittingId &&


            // Check if times overlap (NOTE the ! NOT operator)
            !(res.ReservationEndTime <= reservation.ReservationStartTime || res.ReservationStartTime >= reservation.ReservationEndTime))
                // Flatten the reservation with rooms collection into a single list/collection (only the room code)
                // Param 1: Collection selector (find Rooms within Reservation)
                // Param 2: Result selector (project/select the Code from each Room)
                .SelectMany(res => res.Tables)
                .Select(t => t.TableNo)
                .ToList();

            // Find available/unassigned rooms
            var unassignedTables = _context.Table
                .Where(r => !unavailableTables.Contains(r.TableNo))
                .Select(r => r.TableNo)
                .ToList();

            // Pass to ViewData
            ViewData["AssignedTablesList"] = new SelectList(assignedTables);
            ViewData["UnassignedTablesList"] = new SelectList(unassignedTables);
        }
    }
}