using FinanceTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.ViewComponents;

public class FixedExpensesViewComponent : ViewComponent
{
	private readonly FinanceContext _context;

	public FixedExpensesViewComponent(FinanceContext context)
	{
		_context = context;
	}

	public IViewComponentResult Invoke()
	{
		var expenses = _context.FixedExpenses.ToList();
		return View("Default", expenses);
	}
}