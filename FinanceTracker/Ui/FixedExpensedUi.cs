using FinanceTracker.Db;
using FinanceTracker.Models;
using FinanceTracker.Utils;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace FinanceTracker.Ui;

public class FixedExpensedUi
{
	private readonly FinanceContext _context;
	private readonly string[] _colNames;
	private readonly Table _table;
	private IEnumerable<FixedExpense>? _expenseData;

	public FixedExpensedUi(FinanceContext context)
	{
		_context = context;
		_colNames = ["Date", "Desc", "Vendor", "Tag", "Amount", "Balance"];
		_table = new Table();
	}

	public void InitUi()
	{
		InitTable();
		AnsiConsole.Write(_table);

		string userSelection;
		do
		{
			userSelection = ActionSelecton();
			switch (userSelection)
			{
				case "Exit":
					Environment.Exit(0);
					break;
			}
		} while (userSelection != "Back to home");

		Console.Clear();
	}

	private string ActionSelecton()
	{
		IEnumerable<string> choices =
		[
			"Add new",
			"Edit",
			"Delete",
			"\n---Back to home---",
			"\n---Exit---"
		];
		var input = UserInput.GetUserSelection(choices);
		return input;
	}

	private void InitTable()
	{
		foreach (var col in _colNames)
		{
			_table.AddColumn(new TableColumn($"[plum2]{col}[/]"));
		}

		RetrieveData();
		TryAddDataToTable();
	}

	private async void RetrieveData()
	{
		var data = await _context.FixedExpenses.ToListAsync();
		_expenseData = data;
	}

	private void TryAddDataToTable()
	{
		if (_expenseData != null)
		{
			foreach (var expense in _expenseData)
			{
				_table.AddRow(
					expense.Category ?? string.Empty,
					expense.Amount.ToString(),
					expense.DueDate.ToString()
				);
			}
		}
	}
}