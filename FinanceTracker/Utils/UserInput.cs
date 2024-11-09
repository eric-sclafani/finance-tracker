using Spectre.Console;

namespace FinanceTracker.Utils;

public static class UserInput
{
	public static string GetUserSelection(IEnumerable<string> choices)
	{
		var input = AnsiConsole.Prompt(
			new SelectionPrompt<string>()
				.AddChoices(choices)
				.EnableSearch()
				.HighlightStyle(
					new Style()
						.Decoration(Decoration.Bold | Decoration.Italic)
						.Foreground(Color.Aqua)
				)
		);

		return input.Trim('\n').Trim('-').Trim();
	}
}