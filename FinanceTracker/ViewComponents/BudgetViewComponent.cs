using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.ViewComponents;

public class BudgetViewComponent : ViewComponent
{
	public async Task<IViewComponentResult> InvokeAsync()
	{
		return View("Default");
	}
}