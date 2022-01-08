using System.Diagnostics.CodeAnalysis;

using Spectre.Console.Cli;


namespace MediaTagger
{
    public class ReplaceCommand : Command<ReplaceCommand.Settings>
    {
        public sealed class Settings : BaseCommand.Settings
        {
            [CommandOption("-p|--pattern")]
            public string? Pattern { get; set; }

            [CommandOption("-s|--substitution")]
            public string? Substitution { get; set; }

            [CommandOption("-d|--dictionary")]
            public string? Dictionary { get; set; }

            [CommandOption("-r|--remove")]
            public string? Remove { get; set; }
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            /*
            string text = StringUtilities.StringFromList(settings.OriginalTracks);
            
            if (settings.Dictionary != null && settings.Dictionary.Length > 0)
            {
                text += settings.Dictionary;
            }

            string output = RegExHelper.Replace(text, settings.Pattern, settings.Substitution);

            if (settings.Dictionary != null && settings.Dictionary.Length > 0)
            {
                output = output.Replace(settings.Dictionary + Environment.NewLine, "");
            }

            settings.ModifiedTracks = StringUtilities.ListFromString(output);

            foreach (Track track in settings.ModifiedTracks)
            {
                Console.WriteLine(track.Number + " - " + track.Title + track.Extension);
            }
            */

            return 0;
        }
    }    
}
