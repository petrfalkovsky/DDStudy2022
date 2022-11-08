namespace Api.Models
{
    public class PostModel
    {
        public List<MetadataModel>? Pictures { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset CreatedPost { get; set; }

        public PostModel(List<MetadataModel>? pictures, string? description, DateTimeOffset createdPost)
        {
            Pictures = pictures;
            Description = description;
            CreatedPost = createdPost;
        }
    }
}
