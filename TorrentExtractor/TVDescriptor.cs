namespace TorrentExtractor
{
    public class TVDescriptor
    {
        public string Name { get; set; }
        public string Series { get; set; }
        public string Episode { get; set; }
        public string Extension { get; set; }

        public string FileName
        {
            get
            {
                return $"{Name}-S{Series}E{Episode}.{Extension}";
            }
        }
    }
}
