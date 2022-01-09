namespace MediaTagger
{
    public class MediaDirectory
    {
        public string? Path { get; set; }

        public List<MediaFile>? Files { get; set; }

        public int Version { get; set; }        
    }
}