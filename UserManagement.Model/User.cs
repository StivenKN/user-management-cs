using System.ComponentModel.DataAnnotations.Schema;

namespace UserManagement.Model
{
    public class User
    {
        [Column("id")]
        public int? Id { get; set; }

        [Column("user_full_name")]
        public required string UserFullName { get; set; }

        [Column("user_email")]
        public required string UserEmail { get; set; }

        [Column("user_password")]
        public required string UserPassword { get; set; }

        [Column("db_namespace")]
        public required string DbNamespace { get; set; }

        [Column("user_status")]
        public string? UserStatus { get; set; }

        [Column("id_user_api_key_fk")]
        public required int IdUserApiKeyFk { get; set; }

        [Column("id_user_role_fk")]
        public required int IdUserRoleFk { get; set; }
    }
}
