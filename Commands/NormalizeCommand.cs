using System.Diagnostics.CodeAnalysis;

using Spectre.Console.Cli;


namespace MediaTagger
{
    public class NormalizeCommand : Command<NormalizeCommand.Settings>
    {
        public sealed class Settings : BaseCommand.Settings
        {
            [CommandOption("-r|--round-brackets")]
            public bool RoundBrackets { get; set; }

            [CommandOption("-s|--square-brackets")]
            public bool SquareBrackets { get; set; }            
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            SettingsDumper.Dump(settings);

            return 0;
        }
    }    
}
