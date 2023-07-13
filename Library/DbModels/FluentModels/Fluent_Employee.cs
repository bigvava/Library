using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Library.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using Library.DbModels.FluentModels;

namespace Library.DbModels
{
    public class Fluent_Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public int EmployeeTypeId { get; set; }
        public Fluent_User User { get; set; }
        public List<Fluent_Book> Books { get; set; }
    }
}
