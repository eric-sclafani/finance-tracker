using FinanceTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Pages;

public class IndexModel : PageModel
{
	private readonly ILogger<IndexModel> _logger;
	private readonly FinanceContext _context;

	public Models.Budget Budget { get; set; } = default!;
	public IList<Models.FixedExpense> FixedExpenses { get; set; } = [];
	public IList<Models.Purchase> Purchases { get; set; } = [];

	public IndexModel(ILogger<IndexModel> logger, FinanceContext context)
	{
		_logger = logger;
		_context = context;
	}

	public async void OnGetAsync()
	{
		FixedExpenses = await _context.FixedExpenses.ToListAsync();
		Purchases = await _context.Purchases.ToListAsync();
		Budget = await _context.Budget.FirstAsync();
	}
}