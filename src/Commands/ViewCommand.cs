using System.Diagnostics.CodeAnalysis;

using Spectre.Console;
using Spectre.Console.Cli;


namespace MediaTagger
{
    public class ViewCommand : Command<ViewCommand.Settings>
    {
        public sealed class Settings : BaseCommand.Settings
        {
            [CommandOption("-f|--files")]
            public bool Files { get; set; }

            [CommandOption("-m|--metadata")]
            public bool Metadata { get; set; }

            [CommandOption("-d|--distinct")]
            public bool Distinct { get; set; } 
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            if (settings.Files)
            {
                ReportViewer.Files(settings.OriginalDirectory);
            }
            else if (settings.Metadata)
            {
                ReportViewer.Metadata(settings.OriginalDirectory);
            }
            else if (settings.Distinct)
            {
                AnsiConsole.WriteException(new NotImplementedException("Distinct View is not implemented yet."));
            }
            
            return 0;
        }
    }    
}
