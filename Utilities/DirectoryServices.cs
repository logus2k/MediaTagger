namespace MediaTagger
{
    public class DirectoryServices
    {
        public static Album GetAlbum(string path)
        {
            Album album = new();
            album.Path = path;
            
            if (path != null && path.Length > 0)
            {
                try
                {
                    // TODO: Move the extensions list to Configuration Settings
                    string[] extensions = new string[]{".flac", ".dsf", ".mp3", ".m4a", ".wav", ".ogg", ".ape"};

                    DirectoryInfo dirInfo = new(path);
                    List<FileSystemInfo> files = new();

                    if (dirInfo != null)
                    {
                        album.Name = dirInfo.Name[7..];
                        album.Year = dirInfo.Name[..4];

                        if (dirInfo.Parent != null)
                        {
                            album.Artist = dirInfo.Parent.Name;
                        }

                        files = dirInfo.GetFileSystemInfos()
                            .Where(file => extensions.Contains(file.Extension)).ToList();
                    }

                    List<Track> tracks = new();

                    int trackCounter = 0;

                    foreach (FileSystemInfo file in files)
                    {
                        Track track = new();
                        track.Number = (++ trackCounter).ToString().PadLeft(files.Count.ToString().Length, '0');
                        track.Title = file.Name;
                        track.Extension = file.Extension;
                        track.Hash = file.GetHashCode();

                        tracks.Add(track);
                    }

                    if (tracks.Count > 0)
                    {
                        album.Tracks = new(tracks);
                    }
                    else
                    {
                        Console.WriteLine("Did not find media files in " + path);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Found errors while processing " + path);
                }
            }

            return album; 
         }        
    }
}
