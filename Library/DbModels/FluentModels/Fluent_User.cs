namespace Library.DbModels.FluentModels
{
    public class Fluent_User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime Created { get; set; }
        public int? ReaderId { get; set; }
        public Fluent_Reader Reader { get; set; }
        public int? EmployeeId { get; set; }
        public Fluent_Employee Employee { get; set; }
        public List<Fluent_UserRole> UsersRoles { get; set; }
    }
}
