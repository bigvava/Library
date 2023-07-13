namespace Library.DbModels.FluentModels
{
    public class Fluent_UserRole
    {
        public int UserId { get; set; }
        public Fluent_User User { get; set; }
        public int RoleId { get; set; }
        public Fluent_Role Role { get; set; }
    }
}
