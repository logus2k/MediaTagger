using Spectre.Console.Cli;


namespace MediaTagger
{
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
