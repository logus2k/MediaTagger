using System.Diagnostics.CodeAnalysis;

using Spectre.Console.Cli;


namespace MediaTagger
{
    public class BaseCommand : Command<BaseCommand.Settings>
    {
        public class Settings : CommandSettings
        {
            public MediaDirectory OriginalDirectory = new();
            
            public List<MediaDirectory> ModifiedDirectories = new();
            
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
                        OriginalDirectory = DirectoryServices.GetMediaDirectory(Path);

                        ConsoleWriter.MediaDirectoryReport(OriginalDirectory);
                    }
                }
            }

            private bool _debug;
            
            [CommandOption("--debug")]
            public bool Debug
            { 
                get
                {
                    return _debug;
                }
                set
                {
                    _debug = value;

                    if (_debug)
                    {
                        SettingsDumper.Dump(this);
                    }
                }
            }
        }
       
        public override int Execute([NotNull] CommandContext context, [NotNull] BaseCommand.Settings settings)
        {
            return 0;
        }
    }    
}
