using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Models;

public class FinanceContext : DbContext
{
	public DbSet<MonthlyBudget> MonthlyBudget { get; set; }
	public DbSet<FixedExpense> FixedExpenses { get; set; }
	public DbSet<Purchase> Purchases { get; set; }

	private string? DbPath { get; set; }

	public FinanceContext()
	{
		var path = Directory.GetCurrentDirectory();
		DbPath = Path.Join(path, "Db/finance.db");
	}

	protected override void OnConfiguring(DbContextOptionsBuilder options)
		=> options.UseSqlite($"Data Source={DbPath}");
}