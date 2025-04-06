using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanManagementApp.Data;
using LoanManagementApp.Models;

namespace LoanManagementApp.Controllers
{
    public class AvailableMoneyController : Controller
    {
        private readonly AppDbContext _context;

        public AvailableMoneyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AvailableMoney
        public async Task<IActionResult> Index()
        {
            var availableMoney = await _context.AvailableMoney.FirstOrDefaultAsync();
            return View(availableMoney);
        }

        // GET: AvailableMoney/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var availableMoney = await _context.AvailableMoney.FindAsync(id);
            if (availableMoney == null)
            {
                return NotFound();
            }
            return View(availableMoney);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Amount")] AvailableMoney availableMoney)
        {
            if (id != availableMoney.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(availableMoney);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(availableMoney);
        }
    }
}