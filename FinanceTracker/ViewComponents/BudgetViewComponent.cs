using FinanceTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.ViewComponents;

public class BudgetViewComponent : ViewComponent
{
	private readonly FinanceContext _context;

	public BudgetViewComponent(FinanceContext context)
	{
		_context = context;
	}
	public async Task<IViewComponentResult> InvokeAsync()
	{
		var budget = await _context.Budget.FirstAsync();
		return View("Default", budget);
	}
}