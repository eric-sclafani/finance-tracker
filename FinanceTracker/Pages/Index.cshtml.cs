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

	public void OnGet()
	{
		GetData();
		UpdateBudget();
	}


	private async void GetData()
	{
		FixedExpenses = await _context.FixedExpenses.ToListAsync();
		Purchases = await _context.Purchases.ToListAsync();
		Budget = await _context.Budget.FirstAsync();
	}

	private int CalculateCashOut()
	{
		var expenses = from expense in FixedExpenses select expense.Amount;
		var expensesSum = expenses.Sum();
		return expensesSum;
	}

	private int CalculateDispoIncome()
	{
		return Budget.CashIn - (int)Budget.CashOut;
	}

	private async void UpdateBudget()
	{
		var entity = _context.Budget.FirstOrDefault(item => item.Id == 1);
		if (entity != null)
		{
			entity.CashOut = CalculateCashOut();
			entity.DisposableIncome = CalculateDispoIncome();
			await _context.SaveChangesAsync();
		}
	}
}