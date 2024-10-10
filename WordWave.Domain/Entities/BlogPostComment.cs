namespace WordWave.Domain.Entities
{
    public class BlogPostComment
    {
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }
    }
}