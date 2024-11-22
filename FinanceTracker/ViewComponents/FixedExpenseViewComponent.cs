using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.ViewComponents;

public class FixedExpenseViewComponent : ViewComponent
{
	public async Task<IViewComponentResult> InvokeAsync()
	{
		return View("Default");
	}
}