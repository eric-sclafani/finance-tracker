using FinanceTracker.Services;
using Microsoft.AspNetCore.Mvc;


namespace FinanceTracker.ViewComponents;

public class BudgetViewComponent : ViewComponent
{
	private readonly FinanceContext _context;

	public BudgetViewComponent(FinanceContext context)
	{
		_context = context;
	}

	public IViewComponentResult Invoke()
	{
		var budget = _context.Budget.First();
		return View("Default", budget);
	}
}