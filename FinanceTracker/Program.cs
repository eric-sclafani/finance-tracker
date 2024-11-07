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
			userSelection = MainMenuSelection();

			switch (userSelection)
			{
				case "Monthly Budget":
					var budget = new MonthlyBudgetUi(dBContext);
					budget.InitUi();

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
		const string title = "[deeppink3_1]Select an option:[/]";
		var input = UserInput.GetUserSelection(choices, title);
		return input;
	}
}