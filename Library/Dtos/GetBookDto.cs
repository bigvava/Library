namespace Library.Dtos
{
    public class GetBookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PagesCount { get; set; }
        public string PublisherName { get; set; }
        public string AuthorName { get; set; }
        public string PriceInGel { get; set; }
        public string PriceInUsd { get; set; }

    }
}
