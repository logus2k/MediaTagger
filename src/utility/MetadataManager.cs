using ATL;


namespace MediaTagger
{
    public class MetadataManager
    {
        public static MediaFileMetadata GetFileMetadata(string path)
        {
            MediaFileMetadata mediaFileMetadata = new();

            if (!string.IsNullOrEmpty(path))
            {
                Track track = new(path);
                
                mediaFileMetadata.Artist = track.Artist;
                mediaFileMetadata.Album = track.Album;
                mediaFileMetadata.Title = track.Title;
                mediaFileMetadata.TrackNumber = track.TrackNumber.ToString();
                mediaFileMetadata.Year = track.Year.ToString();
                mediaFileMetadata.Genre = track.Genre;
            }

            return mediaFileMetadata;
        }
    }
}
