using Spectre.Console;


namespace MediaTagger
{
    public class ConsoleWriter
    {
        public static void MediaDirectoryReport(MediaDirectory directory)
        {
            Table mainTable = new();
            mainTable.HideHeaders();
            mainTable.HideFooters();
            mainTable.NoBorder();
            mainTable.Width = TableWidth(directory);

            mainTable.AddColumn(new TableColumn(""));

            Rule topRule = new();
            topRule.RuleStyle("grey50");

            mainTable.AddRow(topRule);

            mainTable.AddRow("[lightgoldenrod3]" + directory.Path + "[/]");            

            Table contextTable = new();
            contextTable.HideHeaders();
            contextTable.HideFooters();
            contextTable.NoBorder();

            contextTable.AddColumn("");

            Rule contextRule = new("[lightpink3]version " + directory.Version + "[/]");
            contextRule.RuleStyle("grey50");
            contextRule.RightAligned();

            mainTable.AddRow(contextRule);

            Table filesTable = new();
            filesTable.MinimalHeavyHeadBorder();
            filesTable.HideFooters();
            filesTable.BorderColor(Color.Grey50);

            filesTable.AddColumn(new TableColumn("[grey]#[/]").RightAligned());
            filesTable.AddColumn(new TableColumn("[grey70]Files[/]"));
            filesTable.AddColumn(new TableColumn("[grey70]Tags[/]"));
            filesTable.AddColumn(new TableColumn("[grey70]Values[/]"));

            if (directory.Files != null)
            {
                foreach(MediaFile file in directory.Files)
                {
                    string name = "";
                    
                    if (file.Name != null)
                    {
                        name = file.Name.Replace("[", "[[").Replace("]", "]]");
                    }

                    if (file.Metadata != null)
                    {
                        if (file.Metadata.TrackNumber != null)
                        {
                            filesTable.AddRow("[grey]" + file.Ordinal + "[/]", "[grey70]" + name + "[/]", "[grey]Track[/]", "[grey]" + file.Metadata.TrackNumber + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[grey]" + file.Ordinal + "[/]", "[grey70]" + name + "[/]", "", "");
                        }

                        if (file.Metadata.Artist != null)
                        {                        
                            filesTable.AddRow("", "", "[grey]Artist[/]", "[grey]" + file.Metadata.Artist + "[/]");
                        }
                        
                        if (file.Metadata.Album != null)
                        {
                            filesTable.AddRow("", "", "[grey]Album[/]", "[grey]" + file.Metadata.Album + "[/]");
                        }
                        
                        if (file.Metadata.Year != null)
                        {                        
                            filesTable.AddRow("", "", "[grey]Year[/]", "[grey]" + file.Metadata.Year + "[/]");
                        }
                        
                        if (file.Metadata.Genre != null)
                        {                        
                            filesTable.AddRow("", "", "[grey]Genre[/]", "[grey]" + file.Metadata.Genre + "[/]");
                        }
                        
                        filesTable.AddEmptyRow();
                    }
                }
            }

            mainTable.AddRow(filesTable);

            AnsiConsole.Write(mainTable);
        }

        public static int TableWidth(MediaDirectory directory)
        {
            // TODO: Move this value to Configuration Settings
            int minimumMargin = 40;
            
            int width = minimumMargin;

            /*
            if (album.Path != null && album.Path.Length > width)
            {
                width = album.Path.Length;
            }
            */

            if (directory.Files != null)
            {           
                foreach (MediaFile file in directory.Files)
                {
                    if (file.Name != null && file.Name.Length > width)
                    {
                        width = file.Name.Length;
                    }
                }
            }

            width += minimumMargin;

            return width;
        }
    }
}