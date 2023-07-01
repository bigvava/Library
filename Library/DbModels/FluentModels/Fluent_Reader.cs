using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Library.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Library.DbModels
{
    public class Fluent_Reader
    {
        //[Key]
        public int Id { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string FirstName { get; set; }
        //[Required]
        //[MaxLength(100)]
        public string LastName { get; set; }
        //[Column("Phone")]
        //[MaxLength(20)]
        public string PhoneNumber { get; set; }
        //[NotMapped]
        public int TempId { get; set; }
        public List<Fluent_BookReader> BookReaders { get; set; }
    }
}
