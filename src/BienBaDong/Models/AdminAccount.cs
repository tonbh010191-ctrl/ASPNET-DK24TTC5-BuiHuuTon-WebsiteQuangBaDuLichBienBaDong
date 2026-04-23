using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BienBaDong.Models
{
    [Table("AdminAccounts")]
    public class AdminAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; } // Giữ plain-text cho đơn giản, thực tế nên mã hóa MD5/SHA
    }
}