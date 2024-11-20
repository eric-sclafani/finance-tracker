using System.ComponentModel.DataAnnotations;
using FinanceTracker.Models;
using FinanceTracker.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinanceTracker.Pages
{
	public class AddFixedExpenseModel : PageModel
	{
		private readonly FinanceContext _context;
		public string OnPostMessage = string.Empty;
		public bool Success = false;

		[BindProperty, Required] public string? Category { get; set; }
		[BindProperty, Required] public int Amount { get; set; }

		public AddFixedExpenseModel(FinanceContext context)
		{
			_context = context;
		}

		public void OnGet()
		{
		}

		public void OnPost()
		{
			try
			{
				_context.Add(new FixedExpense { Category = Category, Amount = Amount });
				_context.SaveChanges();
				OnPostMessage = "New fixed expense added!";
				Success = true;
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				OnPostMessage = "Oops! Something went wrong :(";
				Success = false;
			}
		}
	}
}