namespace Library.DbModels.FluentModels
{
    public class Fluent_BookWithDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PagesCount { get; set; }
        public decimal Price { get; set; }
    }
}
