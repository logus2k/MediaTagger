using Spectre.Console;


namespace MediaTagger
{
    public class ReportViewer
    {
        public static void Files(MediaDirectory directory)
        {
            TablesWidth tablesWidth = SetTablesWidth(ReportView.File, directory);
            Table mainTable = TableSectionHeader(directory, tablesWidth.MainTable);

            if (directory.Files != null)
            {
                // TODO: Move these constants to Configuration Settings.
                string propertyNameColor = "darkgreen";
                string propertyValueColor = "silver";

                Table filesTable = new();
                filesTable.MinimalBorder();
                filesTable.HideFooters();
                filesTable.BorderColor(Color.DarkGreen);

                TableColumn propertiesColumn = new("[" + propertyNameColor + "]#[/]");
                propertiesColumn.RightAligned();
                filesTable.AddColumn(propertiesColumn);

                TableColumn valuesColumn = new("[lightskyblue3_1]Files[/]");
                valuesColumn.LeftAligned();
                valuesColumn.Width(tablesWidth.FileTable);
                filesTable.AddColumn(valuesColumn);

                string name = "";

                foreach(MediaFile file in directory.Files)
                {
                    if (file.Name != null)
                    {
                        name = file.Name.Replace("[", "[[").Replace("]", "]]");
                    }
                    
                    filesTable.AddRow("[" + propertyNameColor + "]" + file.Ordinal.ToString() + "[/]", "[" + propertyValueColor + "]" + name + "[/]");
                }

                mainTable.AddRow(filesTable);
            }

            AnsiConsole.Write(mainTable);
        }
        
        public static void Metadata(MediaDirectory directory)
        {
            TablesWidth tablesWidth = SetTablesWidth(ReportView.Metadata, directory);
            Table mainTable = TableSectionHeader(directory, tablesWidth.MainTable);

            if (directory.Files != null)
            {
                // TODO: Move these constants to Configuration Settings.
                int propertiesColumnWidth = 8;
                string propertyNameHeaderColor = "darkgreen";
                string propertyValueHeaderColor = "lightgoldenrod3";
                string propertyNameColor = "lightskyblue3_1";
                string propertyValueColor = "silver";

                foreach(MediaFile file in directory.Files)
                {
                    Table filesTable = new();
                    filesTable.MinimalBorder();
                    filesTable.HideFooters();
                    filesTable.BorderColor(Color.DarkGreen);

                    string name = "";
                    
                    if (file.Name != null)
                    {
                        name = file.Name.Replace("[", "[[").Replace("]", "]]");
                    }

                    TableColumn propertiesColumn = new("[" + propertyNameHeaderColor + "]#" + file.Ordinal.ToString() + "[/]");
                    propertiesColumn.LeftAligned();
                    propertiesColumn.Width(propertiesColumnWidth);
                    filesTable.AddColumn(propertiesColumn);

                    TableColumn valuesColumn = new("[" + propertyValueHeaderColor + "]" + name + "[/]");
                    valuesColumn.LeftAligned();
                    valuesColumn.Width(tablesWidth.FileTable - propertiesColumnWidth);
                    filesTable.AddColumn(valuesColumn);
                    
                    if (file.Metadata != null)
                    {
                        if (file.Metadata.Title != null)
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]   Title[/]", "[" + propertyValueColor + "]" + file.Metadata.Title + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]   Title[/]", "");
                        }

                        if (file.Metadata.TrackNumber != null)
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]   Track[/]", "[" + propertyValueColor + "]" + file.Metadata.TrackNumber + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]   Track[/]", "");
                        }

                        if (file.Metadata.Artist != null)
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]  Artist[/]", "[" + propertyValueColor + "]" + file.Metadata.Artist + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]  Artist[/]", "");
                        }

                        if (file.Metadata.Album != null)
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]   Album[/]", "[" + propertyValueColor + "]" + file.Metadata.Album + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]   Album[/]", "");
                        }

                        if (file.Metadata.Year != null)
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]    Year[/]", "[" + propertyValueColor + "]" + file.Metadata.Year + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]    Year[/]", "");
                        }

                        if (file.Metadata.Genre != null)
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]   Genre[/]", "[" + propertyValueColor + "]" + file.Metadata.Genre + "[/]");
                        }
                        else
                        {
                            filesTable.AddRow("[" + propertyNameColor + "]   Genre[/]", "");
                        }
                        
                        mainTable.AddRow(filesTable);
                    }
                }

                Console.WriteLine("tablesWidth.FileTable: {0}", tablesWidth.FileTable);
            }

            AnsiConsole.Write(mainTable);
        }

        private static Table TableSectionHeader(MediaDirectory directory, int mainTableWidth)
        {
            AnsiConsole.WriteLine(Ruler());
            
            Table mainTable = new();
            mainTable.HideHeaders();
            mainTable.HideFooters();
            mainTable.NoBorder();

            mainTable.AddColumn(new TableColumn(""));

            Rule topRule = new("[lightskyblue3_1]Path[/]");
            topRule.RuleStyle("darkgreen");
            topRule.LeftAligned();

            mainTable.AddRow(topRule);
            
            if (directory.Path != null)
            {
                mainTable.AddRow("[lightgoldenrod3] " + directory.Path + "[/]");
            }
            else
            {
                mainTable.AddRow("[lightgoldenrod3] <Invalid path or path not found!>[/]");
            }

            Table contextTable = new();
            contextTable.HideHeaders();
            contextTable.HideFooters();
            contextTable.NoBorder();

            contextTable.AddColumn("");

            Rule contextRule = new("[orange3]version " + directory.Version + "[/]");
            contextRule.RuleStyle("darkgreen");
            contextRule.RightAligned();

            mainTable.AddRow(contextRule);

            mainTable.Width = mainTableWidth;

            Console.WriteLine("mainTableWidth: {0}", mainTableWidth);

            return mainTable;            
        }

        private static TablesWidth SetTablesWidth(ReportView reportView, MediaDirectory directory)
        {
            // TODO: Move these constants to Configuration Settings
            // int minimumMainTableMargin = 0;
            // int minimumFileTableMargin = 0;

            int mainTableMargin = 0;
            int fileTableMargin = 0;
            
            int mainTableWidth = 0;
            int fileTableWidth = 0;
            int propertiesColumnWidth = 8;
            
            if (reportView == ReportView.Metadata)
            {
                mainTableMargin = 4;
                fileTableMargin = propertiesColumnWidth;

                mainTableWidth += mainTableMargin;
                fileTableWidth += fileTableMargin;

                if (directory.Files != null)
                {           
                    foreach (MediaFile file in directory.Files)
                    {
                        if (file.Name != null && (file.Name.Length + fileTableMargin) > fileTableWidth)
                        {
                            fileTableWidth = file.Name.Length + fileTableMargin;
                        }
                    }
                }

                if (directory.Path != null && directory.Path.Length + mainTableMargin > mainTableWidth)
                {
                    mainTableWidth = directory.Path.Length + mainTableMargin;

                    if (mainTableWidth < fileTableWidth)
                    {
                        mainTableWidth = fileTableWidth;
                    }
                }
            }
            else if (reportView == ReportView.File)
            {
                
            }

            return new(mainTableWidth, fileTableWidth);
        }

        private static string Ruler()
        {
            return 
            "1        10        20        30        40        50        60        70        80        90        100       110       120       130       140       150" + 
            Environment.NewLine + 
            "123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789" + 
            Environment.NewLine +
            "|........|.........|.........|.........|.........|.........|.........|.........|.........|.........|.........|.........|.........|.........|.........|.........";
        }

        private record TablesWidth(int MainTable, int FileTable);  

        private enum ReportView{File, Metadata};      
    }
}