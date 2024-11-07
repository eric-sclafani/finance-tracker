using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models;

public class FixedExpense
{
	[Key] public int ExpenseId { get; init; }
	public string? Category { get; set; }
	public decimal Amount { get; set; }
	public DateOnly DueDate { get; set; }
}