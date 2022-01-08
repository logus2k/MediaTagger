using Spectre.Console;
using Spectre.Console.Cli;

namespace MediaTagger
{
    public static class SettingsDumper
    {
        public static void Dump(CommandSettings settings)
        {
            var table = new Table().RoundedBorder().BorderColor(Color.DarkGreen);
            table.AddColumn("[green]Name[/]");
            table.AddColumn("[green]Value[/]");

            var properties = settings.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(settings)
                    ?.ToString()
                    ?.Replace("[", "[[")
                    ?.Replace("]", "]]");

                table.AddRow(
                    property.Name,
                    value ??"[grey]null[/]");
            }

            AnsiConsole.Write(table);
        }
    }
}
