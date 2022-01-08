using Spectre.Console;


namespace MediaTagger
{
    public class ConsoleWriter
    {
        public static void MediaDirectoryReport(MediaDirectory directory)
        {
            Table mainTable = new();
            mainTable.HideHeaders();
            mainTable.NoBorder();
            mainTable.Width = TableWidth(directory);

            mainTable.AddColumn(new TableColumn(""));

            Rule topRule = new();
            topRule.RuleStyle("grey50");

            mainTable.AddRow(topRule);

            mainTable.AddRow("[lightgoldenrod3]" + directory.Path + "[/]");            

            Table contextTable = new();
            contextTable.HideHeaders();
            contextTable.NoBorder();

            contextTable.AddColumn("");

            Rule contextRule = new("[lightpink3]version " + directory.Version + "[/]");
            contextRule.RuleStyle("grey50");
            contextRule.RightAligned();

            mainTable.AddRow(contextRule);

            Table filesTable = new();
            filesTable.MinimalBorder();
            filesTable.BorderColor(Color.Grey50);

            filesTable.AddColumn(new TableColumn("[deepskyblue3]#[/]").RightAligned());
            filesTable.AddColumn(new TableColumn("[grey70]Files[/]"));

            if (directory.Files != null)
            {
                foreach(MediaFile file in directory.Files)
                {
                    string name = "";
                    
                    if (file.Name != null)
                    {
                        name = file.Name.Replace("[", "[[").Replace("]", "]]");
                    }

                    filesTable.AddRow(
                        "[deepskyblue3]" + file.Ordinal + "[/]",                        
                        "[grey70]" + name + "[/]"
                    );
                }
            }

            Table metadataTable = new();
            metadataTable.MinimalBorder();
            metadataTable.BorderColor(Color.Grey50);

            metadataTable.AddColumn(new TableColumn("[deepskyblue3]Tags[/]"));
            metadataTable.AddColumn(new TableColumn("[grey70]Values[/]"));

            /*
            metadataTable.AddRow("[deepskyblue3]Artist[/]", "[grey70]" + album.Artist + "[/]");
            metadataTable.AddRow("[deepskyblue3]Album [/]", "[grey70]" + album.Name + "[/]");            
            metadataTable.AddRow("[deepskyblue3]Year  [/]", "[grey70]" + album.Year + "[/]");
            metadataTable.AddRow("[deepskyblue3]Genre [/]", "[grey70]" + album.Genre + "[/]");
            */

            Table detailsTable = new();
            detailsTable.HideHeaders();
            detailsTable.NoBorder();

            detailsTable.AddColumn("");
            detailsTable.AddColumn(""); 

            detailsTable.AddRow(filesTable, metadataTable);

            mainTable.AddRow(detailsTable);

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