using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using FinanceTracker.Models;
using FinanceTracker.Services;

namespace FinanceTracker.Pages.FixedExpense
{
    public class CreateModel : PageModel
    {
        private readonly FinanceContext _context;

        public CreateModel(FinanceContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.FixedExpense FixedExpense { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.FixedExpenses.Add(FixedExpense);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
