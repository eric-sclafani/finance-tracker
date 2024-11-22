using FinanceTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Pages;

public class IndexModel : PageModel
{
	private readonly ILogger<IndexModel> _logger;
	private readonly FinanceContext _context;
	public IList<Models.FixedExpense> FixedExpense { get; set; } = [];

	public IndexModel(ILogger<IndexModel> logger, FinanceContext context)
	{
		_logger = logger;
		_context = context;
	}

	public async void OnGetAsync()
	{
		FixedExpense = await _context.FixedExpenses.ToListAsync();
	}
}