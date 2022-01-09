using Spectre.Console;


namespace MediaTagger
{
    public class ReportViewer
    {
        public static void Files(MediaDirectory directory)
        {
            Table mainTable = TableSectionHeader(directory);

            if (directory.Files != null)
            {
                Table filesTable = new();
                filesTable.MinimalBorder();
                filesTable.HideFooters();
                filesTable.BorderColor(Color.Grey50);

                TableColumn propertiesColumn = new("[grey]#[/]");
                propertiesColumn.RightAligned();
                filesTable.AddColumn(propertiesColumn);

                TableColumn valuesColumn = new("[grey70]Files[/]");
                valuesColumn.LeftAligned();
                valuesColumn.Width(mainTable.Width);
                filesTable.AddColumn(valuesColumn);

                string name = "";

                foreach(MediaFile file in directory.Files)
                {
                    if (file.Name != null)
                    {
                        name = file.Name.Replace("[", "[[").Replace("]", "]]");
                    }
                    
                    filesTable.AddRow("[grey]" + file.Ordinal.ToString() + "[/]", "[grey70]" + name + "[/]");
                }

                mainTable.AddRow(filesTable);
            }

            AnsiConsole.Write(mainTable);
        }
        
        public static void Metadata(MediaDirectory directory)
        {
            Table mainTable = TableSectionHeader(directory);

            if (directory.Files != null)
            {
                // TODO: Move this value to Configuration Settings.            
                int propertiesColumnWidth = 8;                
                
                foreach(MediaFile file in directory.Files)
                {
                    Table filesTable = new();
                    filesTable.MinimalBorder();
                    filesTable.HideFooters();
                    filesTable.BorderColor(Color.Grey50);

                    string name = "";
                    
                    if (file.Name != null)
                    {
                        name = file.Name.Replace("[", "[[").Replace("]", "]]");
                    }

                    TableColumn propertiesColumn = new("[grey]#" + file.Ordinal.ToString() + "[/]");
                    propertiesColumn.LeftAligned();
                    propertiesColumn.Width(propertiesColumnWidth);
                    filesTable.AddColumn(propertiesColumn);

                    TableColumn valuesColumn = new("[grey70]" + name + "[/]");
                    valuesColumn.LeftAligned();
                    valuesColumn.Width(mainTable.Width - propertiesColumnWidth);
                    filesTable.AddColumn(valuesColumn);
                    
                    if (file.Metadata != null)
                    {
                        if (file.Metadata.Title != null)
                        {
                            filesTable.AddRow("[grey70]   Title[/]", "[grey]" + file.Metadata.Title + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[grey70]   Title[/]", "");
                        }

                        if (file.Metadata.TrackNumber != null)
                        {
                            filesTable.AddRow("[grey70]   Track[/]", "[grey]" + file.Metadata.TrackNumber + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[grey70]   Track[/]", "");
                        }

                        if (file.Metadata.Artist != null)
                        {
                            filesTable.AddRow("[grey70]  Artist[/]", "[grey]" + file.Metadata.Artist + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[grey70]  Artist[/]", "");
                        }

                        if (file.Metadata.Album != null)
                        {
                            filesTable.AddRow("[grey70]   Album[/]", "[grey]" + file.Metadata.Album + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[grey70]   Album[/]", "");
                        }

                        if (file.Metadata.Year != null)
                        {
                            filesTable.AddRow("[grey70]    Year[/]", "[grey]" + file.Metadata.Year + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[grey70]    Year[/]", "");
                        }

                        if (file.Metadata.Genre != null)
                        {
                            filesTable.AddRow("[grey70]   Genre[/]", "[grey]" + file.Metadata.Genre + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[grey70]   Genre[/]", "");
                        }
                        
                        mainTable.AddRow(filesTable);
                    }
                }
            }

            AnsiConsole.Write(mainTable);
        }

        private static Table TableSectionHeader(MediaDirectory directory)
        {
            Table mainTable = new();
            mainTable.HideHeaders();
            mainTable.HideFooters();
            mainTable.NoBorder();
            mainTable.Width = TableWidth(directory);

            mainTable.AddColumn(new TableColumn(""));

            Rule topRule = new("[lightpink3]Path[/]");
            topRule.RuleStyle("grey50");
            topRule.LeftAligned();

            mainTable.AddRow(topRule);
            mainTable.AddRow("[lightgoldenrod3] " + directory.Path + "[/]");            

            Table contextTable = new();
            contextTable.HideHeaders();
            contextTable.HideFooters();
            contextTable.NoBorder();

            contextTable.AddColumn("");

            Rule contextRule = new("[lightpink3]version " + directory.Version + "[/]");
            contextRule.RuleStyle("grey50");
            contextRule.RightAligned();

            mainTable.AddRow(contextRule);

            return mainTable;            
        }

        private static int TableWidth(MediaDirectory directory)
        {
            // TODO: Move this value to Configuration Settings
            int minimumMargin = 4;
            
            int width = minimumMargin;

            if (directory.Path != null && directory.Path.Length > width)
            {
                width = directory.Path.Length;
            }

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