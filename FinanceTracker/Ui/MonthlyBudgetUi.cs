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
	private MonthlyBudget? _budgetData;
	private readonly Table _table;

	public MonthlyBudgetUi(FinanceContext context)
	{
		_context = context;
		_colNames = ["Cash In (net)", "Cash Out", "Disp. Income", "Note"];
		_table = InitTable();
	}

	public void InitUi()
	{
		Console.Clear();
		AnsiConsole.Write(_table);

		string userSelection;
		do
		{
			userSelection = FieldSelection();
		} while (userSelection != "Back to home");

		Console.Clear();
	}

	private string FieldSelection()
	{
		IEnumerable<string> choices = ["---Back to home---\n"];
		choices = choices.Concat(_colNames);

		var input = UserInput.GetUserSelection(choices);
		return input;
	}


	private Table InitTable()
	{
		var table = new Table();
		foreach (var col in _colNames)
		{
			table.AddColumn(new TableColumn($"[orange1]{col}[/]"));
		}

		RetrieveData();
		AddDataToTable();
		return table;
	}

	private async void RetrieveData()
	{
		var data = (await _context.MonthlyBudget.ToListAsync()).FirstOrDefault();
		_budgetData = data;
	}

	private void AddDataToTable()
	{
		if (_budgetData != null)
		{
			_table.AddRow(
				_budgetData.BudgetId.ToString(),
				_budgetData.NetCashIn.ToString(),
				_budgetData.CashOut.ToString(),
				_budgetData.DispIncome.ToString(),
				_budgetData.Note ?? ""
			);
		}
	}
}