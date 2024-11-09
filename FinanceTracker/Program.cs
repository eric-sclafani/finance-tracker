using System.Reflection.PortableExecutable;
using FinanceTracker.Db;
using FinanceTracker.Ui;
using FinanceTracker.Utils;
using Spectre.Console;

namespace FinanceTracker;

internal class Program
{
	public static void Main()
	{
		var dBContext = new FinanceContext();
		
		string userSelection;
		do
		{
			DisplayInitMessage();
			userSelection = MainMenuSelection();
			Console.Clear();

			switch (userSelection)
			{
				case "Monthly Budget":
					var budget = new MonthlyBudgetUi(dBContext);
					budget.InitUi();
					break;
				
				case "Fixed Expenses":
					var expenses = new FixedExpensedUi(dBContext);
					expenses.InitUi();
					break;
			}
		} while (userSelection != "Exit");
	}

	private static string MainMenuSelection()
	{
		string[] choices =
		[
			"Purchases",
			"Fixed Expenses",
			"Monthly Budget",
			"Exit"
		];
		var input = UserInput.GetUserSelection(choices);
		return input;
	}

	private static void DisplayInitMessage()
	{
		AnsiConsole.Write(
			new FigletText("Finance Tracker")
				.Centered()
				.Color(Color.Red));
	}
}