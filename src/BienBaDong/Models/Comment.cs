using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BienBaDong.Models
{
    [Table("Comments")]
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public int DestinationId { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
        [StringLength(50)]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập nội dung")]
        [StringLength(500)]
        public string Content { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public bool IsApproved { get; set; } = true;

        [ForeignKey("DestinationId")]
        public virtual Destination Destination { get; set; }
    }
}