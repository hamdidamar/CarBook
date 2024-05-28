namespace CarBook.Dto.BlogDtos
{
    public class BlogComment:BaseDto
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public string BlogId { get; set; }
    }
}