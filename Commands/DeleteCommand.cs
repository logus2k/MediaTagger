using System.Diagnostics.CodeAnalysis;

using Spectre.Console.Cli;


namespace MediaTagger
{
    public class DeleteCommand : Command<DeleteCommand.Settings>
    {
        public sealed class Settings : BaseCommand.Settings
        {
            [CommandOption("-a|--all")]
            public bool All { get; set; }

            [CommandOption("-c|--all-except-core")]
            public bool AllExceptCore { get; set; }

            [CommandOption("-e|--all-except")]
            public string? AllExcept { get; set; } 

            [CommandOption("-l|--list")]
            public string? List { get; set; }       
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            SettingsDumper.Dump(settings);

            return 0;
        }
    }    
}
