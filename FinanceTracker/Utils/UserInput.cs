using Spectre.Console;

namespace FinanceTracker.Utils;

public static class UserInput
{
	public static string GetUserSelection(IEnumerable<string> choices, string title = "")
	{
		var input = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.Title(title)
				.AddChoices(choices)
				.EnableSearch()
		);

		return input.Trim('\n').Trim('-');
	}
}