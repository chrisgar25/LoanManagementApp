using LoanManagementApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LoanManagementApp.Services
{
    public class OverdueService : BackgroundService
    {
        private readonly IServiceProvider _services;
        private readonly ILogger<OverdueService> _logger;

        public OverdueService(IServiceProvider services, ILogger<OverdueService> logger)
        {
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    var overdueLoans = await db.Loans
                        .Where(l => !l.IsPaid && l.DueDate < DateTime.Now)
                        .ToListAsync();

                    foreach (var loan in overdueLoans)
                    {
                        loan.IsOverdue = true;
                        _logger.LogInformation($"Préstamo {loan.Id} marcado como moroso");
                    }

                    await db.SaveChangesAsync();
                }

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}