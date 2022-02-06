namespace MediaTagger
{
    public class DirectoryServices
    {
        public static MediaDirectory GetMediaDirectory(string path)
        {
            MediaDirectory directory = new();
            directory.Path = path.Replace("[", "[[").Replace("]", "]]");
            
            if (path != null && path.Length > 0)
            {
                try
                {
                    // TODO: Move the extensions list to Configuration Settings
                    string[] extensions = new string[]{".flac", ".dsf", ".mp3", ".m4a", ".wav", ".ogg", ".ape"};

                    DirectoryInfo dirInfo = new(path);
                    List<FileSystemInfo> files = new();
                    List<MediaFileMetadata> mediaFileMetadata = new();

                    if (dirInfo != null)
                    {
                        files = dirInfo.GetFileSystemInfos()
                            .Where(file => extensions.Contains(file.Extension)).ToList();
                    }

                    List<MediaFile> mediaFiles = new();

                    int trackCounter = 0;

                    foreach (FileSystemInfo file in files)
                    {
                        MediaFile mediaFile = new();
                        mediaFile.Ordinal = ++ trackCounter;
                        mediaFile.Name = file.Name;
                        mediaFile.Extension = file.Extension;
                        mediaFile.Hash = file.GetHashCode();

                        mediaFile.Metadata = MetadataManager.GetFileMetadata(file.FullName);

                        mediaFiles.Add(mediaFile);
                    }

                    if (mediaFiles.Count > 0)
                    {
                        directory.Files = new(mediaFiles);
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

            return directory; 
         }        
    }
}
