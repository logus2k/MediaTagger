using System.Diagnostics.CodeAnalysis;

using Spectre.Console.Cli;


namespace MediaTagger
{
    public class BaseCommand : Command<BaseCommand.Settings>
    {
        public class Settings : CommandSettings
        {
            public List<string> OriginalFileNames = new();
            
            public List<string> ModifiedFileNames = new();
            
            private string? _path;

            [CommandArgument(0, "<path>")]
            public string? Path
            {
                get
                {
                    return _path;
                }
                set
                {
                    _path = value;
                    
                    if (Path != null && Path.Length > 0)
                    {
                        OriginalFileNames = DirectoryServices.GetFiles(Path);
                    }
                }
            }
        }
       
        public override int Execute([NotNull] CommandContext context, [NotNull] BaseCommand.Settings settings)
        {
            return 0;
        }
    }

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

    public class ReplaceCommand : Command<ReplaceCommand.Settings>
    {
        public sealed class Settings : BaseCommand.Settings
        {
            [CommandOption("-p|--pattern")]
            public string? Pattern { get; set; }

            [CommandOption("-s|--substitute")]
            public string? Substitute { get; set; }            
        }

        public override int Execute([NotNull] CommandContext context, [NotNull] Settings settings)
        {
            SettingsDumper.Dump(settings);

            foreach (string name in settings.OriginalFileNames)
            {
                Console.WriteLine(name);
            }

            return 0;
        }
    }

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
            SettingsDumper.Dump(settings);

            return 0;
        }
    }

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
            SettingsDumper.Dump(settings);

            return 0;
        }
    }     

    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandApp();

            app.Configure(config =>
            {
                config.SetApplicationName("Media Tagger");
                config.SetApplicationVersion("0.1b");

                config.AddCommand<NormalizeCommand>("normalize");
                config.AddCommand<ReplaceCommand>("replace");
                config.AddCommand<ImportCommand>("import");
                config.AddCommand<DeleteCommand>("delete");
                config.AddCommand<ViewCommand>("view");  
            });

            int output = app.Run(args);
        }
    }
}
