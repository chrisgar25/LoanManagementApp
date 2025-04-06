using Microsoft.AspNetCore.Mvc;
using LoanManagementApp.Data;

namespace LoanManagementApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var availableMoney = _context.AvailableMoney.FirstOrDefault();
            ViewBag.AvailableMoney = availableMoney?.Amount.ToString("C") ?? "$0.00";
            return View();
        }
    }
}