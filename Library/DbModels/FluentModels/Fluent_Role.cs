namespace Library.DbModels.FluentModels
{
    public class Fluent_Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public List<Fluent_User> Users { get; set; }
        public List<Fluent_UserRole> UsersRoles { get; set; }
    }
}
