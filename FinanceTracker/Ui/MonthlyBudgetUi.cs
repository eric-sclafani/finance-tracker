using FinanceTracker.Db;
using FinanceTracker.Models;
using FinanceTracker.Utils;
using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace FinanceTracker.Ui;

public class MonthlyBudgetUi
{
	private readonly FinanceContext _context;
	private readonly string[] _colNames;
	private readonly Table _table;
	private MonthlyBudget? _budgetData;

	public MonthlyBudgetUi(FinanceContext context)
	{
		_context = context;
		_colNames = ["Cash In (net)", "Cash Out", "Disp. Income", "Note"];
		_table = new Table();
	}

	public void InitUi()
	{
		InitTable();
		AnsiConsole.Write(_table);

		string userSelection;
		do
		{
			userSelection = FieldSelection();
			switch (userSelection)
			{
				case "Exit":
					Environment.Exit(0);
					break;
			}
		} while (userSelection != "Back to home");

		Console.Clear();
	}

	private string FieldSelection()
	{
		IEnumerable<string> choices =
		[
			"\n---Back to home---",
			"\n---Exit---"
		];
		choices = _colNames.Concat(choices);

		var input = UserInput.GetUserSelection(choices);
		return input;
	}


	private void InitTable()
	{
		foreach (var col in _colNames)
		{
			_table.AddColumn(new TableColumn($"[orange1]{col}[/]"));
		}

		RetrieveData();
		TryAddDataToTable();
	}

	private async void RetrieveData()
	{
		var data = (await _context.MonthlyBudget.ToListAsync()).FirstOrDefault();
		_budgetData = data;
	}

	private void CalculateCashOut()
	{
	}

	private void CalculateDispIncome()
	{
	}

	private void TryAddDataToTable()
	{
		if (_budgetData != null)
		{
			_table.AddRow(
				_budgetData.NetCashIn.ToString() ?? string.Empty,
				_budgetData.CashOut.ToString() ?? string.Empty,
				_budgetData.DispIncome.ToString() ?? string.Empty,
				_budgetData.Note ?? string.Empty
			);
		}
	}
}