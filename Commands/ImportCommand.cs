using System.Diagnostics.CodeAnalysis;

using Spectre.Console.Cli;


namespace MediaTagger
{
    public class ImportCommand : Command<ImportCommand.Settings>
    {
        public sealed class Settings : BaseCommand.Settings
        {
            [CommandOption("-f|--from-file")]
            public bool FromFile { get; set; }

            [CommandOption("-d|--from-file-and-directory")]
            public bool FromFileAndDirectory { get; set; }           
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            return 0;
        }
    }
}
