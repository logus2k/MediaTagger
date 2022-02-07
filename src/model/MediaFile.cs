namespace MediaTagger
{
    public class MediaFile
    {
        public int Ordinal { get; set; }
        public string? Name { get; set; }
        public string? Extension { get; set; }
        public int Hash { get; set; }
        public MediaFileMetadata? Metadata { get; set; }

    }
}
