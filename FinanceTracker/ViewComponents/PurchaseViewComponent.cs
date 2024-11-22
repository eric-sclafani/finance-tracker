using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.ViewComponents;

public class PurchaseViewComponent : ViewComponent
{
	public async Task<IViewComponentResult> InvokeAsync()
	{
		return View("Default");
	}
}