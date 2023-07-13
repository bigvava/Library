namespace Library.DbModels
{
    //[Table("Book_Readers")]
    public class Fluent_BookReader
    {
        public int BookId { get; set; }
        public Fluent_Book Book { get; set; }
        public int ReaderId { get; set; }
        public Fluent_Reader Reader { get; set; }
    }
}
