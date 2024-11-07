using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models;

public class MonthlyBudget
{
	[Key] public int BudgetId { get; init; }
	public decimal NetCashIn { get; set; }
	public decimal CashOut { get; set; }
	public decimal DispIncome { get; set; }
	public string? Note { get; set; }
}