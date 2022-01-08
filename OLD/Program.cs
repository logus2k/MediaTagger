/*
using ATL;


namespace MediaTagger
{
    public class Tagger
    {
        static void Main2(string[] args)
        {
            if (args.Length < 5)
            {
                Console.WriteLine("Usage: MediaTagger <media files directory path> <artist> <album> <year> <genre>");
                Environment.Exit(0);
            }

            string artist = args[1];
            string title = "";
            string album = args[2];
            int trackNumber = 0;
            int year = Int32.TryParse(args[3], out int yearResult) ? Int32.Parse(args[3]) : 0;
            string genre = args[4];

            string dirPath = args[0];

            DirectoryInfo dirInfo = new(dirPath);

            FileInfo[] dirFiles = dirInfo.GetFiles("*.flac");

            ProgressBar.WriteProgressBar(0);

            for (int n = 0; n < dirFiles.Length; n++)
            {
                string filePath = dirFiles[n].FullName;
                string fileName = dirFiles[n].Name;

                trackNumber = Int32.TryParse(fileName[..2], out int trackNumberResult) ? Int32.Parse(fileName[..2]) : 0;

                title = fileName[5..^10]; // .Substring(5, fileName.Length - 10);

                Track mediaFile = new(filePath);
                mediaFile.Artist = artist;
                mediaFile.Album = album;
                mediaFile.Title = title;
                mediaFile.TrackNumber = trackNumber;
                mediaFile.Year = year;
                mediaFile.Genre = genre;
                mediaFile.Save();

                float percentage = (float)(n + 1) / dirFiles.Length * 100;
                ProgressBar.WriteProgressBar((int)percentage, true);
            }

            Console.WriteLine("\n");

            Environment.Exit(0);
        }
    }
}
*/