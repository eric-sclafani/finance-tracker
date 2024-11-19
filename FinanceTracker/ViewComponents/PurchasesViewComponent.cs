using FinanceTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.ViewComponents;

public class PurchasesViewComponent : ViewComponent
{
	private readonly FinanceContext _context;

	public PurchasesViewComponent(FinanceContext context)
	{
		_context = context;
	}

	public IViewComponentResult Invoke()
	{
		var purchases = _context.Purchases.ToList();
		return View("Default", purchases);
	}
}