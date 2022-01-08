using System.Diagnostics.CodeAnalysis;

using Spectre.Console.Cli;


namespace MediaTagger
{
    public class ViewCommand : Command<ViewCommand.Settings>
    {
        public sealed class Settings : BaseCommand.Settings
        {
            [CommandOption("-t|--table")]
            public bool Table { get; set; }

            [CommandOption("-r|--record")]
            public bool Record { get; set; }

            [CommandOption("-d|--distinct")]
            public bool Distinct { get; set; } 
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            return 0;
        }
    }    
}
