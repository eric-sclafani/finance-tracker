using System.ComponentModel.DataAnnotations;

namespace FinanceTracker.Models;

public class Purchase
{
	[Key] public int PurchaseId { get; init; }
	public DateOnly PurchaseDate { get; set; }
	public decimal Amount { get; set; }
	public string? Description { get; set; }
	public string? Vendor { get; set; }
	public string? Tag { get; set; }
	public string? Note { get; set; }
}