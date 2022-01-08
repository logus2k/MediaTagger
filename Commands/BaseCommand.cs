using System.Diagnostics.CodeAnalysis;

using Spectre.Console.Cli;

namespace MediaTagger
{
    public class BaseCommand : Command<BaseCommand.Settings>
    {
        public class Settings : CommandSettings
        {
            public Album OriginalAlbum = new();
            
            public List<Album> ModifiedAlbums = new();
            
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
                        OriginalAlbum = DirectoryServices.GetAlbum(Path);

                        Album.ToConsole(OriginalAlbum);
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
