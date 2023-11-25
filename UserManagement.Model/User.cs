namespace UserManagement.Model
{
    public class User
    {
        public required int Id { get; set; }
        public required string UserFullName { get; set; }
        public required string UserEmail { get; set; }
        public required string UserPassword { get; set; }
        public required string DbNamespace { get; set; }
        public required string UserStatus { get; set; }
        public required int IdUserApiKeyFk { get; set; }
        public required int IdUserRoleFk { get; set; }
    }
}
