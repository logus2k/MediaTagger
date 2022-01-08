using Spectre.Console;


namespace MediaTagger
{
    public class Album
    {
        public string? Name { get; set; }
        public string? Artist { get; set; }
        public List<Track>? Tracks { get; set; }
        public string? Year { get; set; }
        public string? Genre { get; set; }
        public string? Path { get; set; }
        public int Version { get; set; }

        public static void ToConsole(Album album)
        {
            Table mainTable = new();
            mainTable.HideHeaders();
            mainTable.NoBorder();
            mainTable.Width = TableWidth(album);

            mainTable.AddColumn(new TableColumn(""));

            Rule rule = new("[salmon1]" + album.Path + "[/]");
            rule.RuleStyle("deepskyblue4");
            rule.LeftAligned();

            mainTable.AddRow(rule);

            mainTable.AddEmptyRow();

            mainTable.AddRow("  [darkseagreen]Artist: [/][grey84]" + album.Artist + "[/]");
            mainTable.AddRow("  [darkseagreen]Album:  [/][grey84]" + album.Name + "[/]");            
            mainTable.AddRow("  [darkseagreen]Genre:  [/][grey84]" + album.Genre + "[/]");
            mainTable.AddRow("  [darkseagreen]Year:   [/][grey84]" + album.Year + "[/]");

            Table tracksTable = new();
            tracksTable.MinimalBorder();
            tracksTable.BorderColor(Color.DeepSkyBlue4);

            tracksTable.AddColumn(new TableColumn("[darkseagreen]Files[/]"));

            if (album.Tracks != null)
            {
                foreach(Track track in album.Tracks)
                {
                    string title = "";
                    
                    if (track.Title != null)
                    {
                        title = track.Title.Replace("[", "[[").Replace("]", "]]");
                    }

                    tracksTable.AddRow("[silver]" + title + "[/]");
                }
            }

            mainTable.AddRow(tracksTable);

            Table contextTable = new();
            contextTable.HideHeaders();
            contextTable.NoBorder();

            contextTable.AddColumn("");

            Rule contextRule = new("[salmon1]Version " + album.Version + "[/]");
            contextRule.RuleStyle("deepskyblue4");
            contextRule.RightAligned();

            mainTable.AddRow(contextRule);

            AnsiConsole.Write(mainTable);
        }

        public static int TableWidth(Album album)
        {
            int minimumMargin = 12;
            
            // TODO: Move this value to Configuration Setiings
            int width = minimumMargin;

            if (album.Path != null && album.Path.Length > width)
            {
                width = album.Path.Length;
            }

            if (album.Tracks != null)
            {           
                foreach (Track track in album.Tracks)
                {
                    if (track.Title != null)
                    {
                        if (track.Title.Length > width)
                        {
                            width = track.Title.Length;
                        }
                    }
                }
            }

            width += minimumMargin;

            return width;
        }
    }
}
