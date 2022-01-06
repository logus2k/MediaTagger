namespace MediaTagger
{
    public class DirectoryServices
    {
        public static List<string> GetFiles(string path)
        {
            List<string> files = new();
            
            if (path != null && path.Length > 0)
            {
                try
                {
                    string[] extensions = new[] { ".flac", ".dsf", ".mp3", ".m4a", ".wav", ".ogg", ".ape" };

                    DirectoryInfo dirInfo = new(path);

                    files = dirInfo.GetFiles()
                        .Where(file => extensions.Contains(file.Extension))
                        .Select(file => file.Name)
                        .ToList();
                }
                catch (Exception)
                {
                    Console.WriteLine("Errors found while processing given path: " + path);
                }
            }

            if (files.Count == 0)
            {
                Console.WriteLine("Media files not found in given path: " + path);
            }

            return files; 
         }        
    }
}