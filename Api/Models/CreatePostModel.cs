namespace Api.Models
{
    public class CreatePostModel
    {
        public List<MetadataModel>? Pictures { get; set; }
        public string? Description { get; set; }
    }
}
