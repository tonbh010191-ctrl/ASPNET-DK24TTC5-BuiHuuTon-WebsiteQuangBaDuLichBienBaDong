using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace BienBaDong.Models
{
    [Table("Destinations")]
    public class Destination
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập tên địa điểm")]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        [AllowHtml]
        public string FullDescription { get; set; } 

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public bool IsActive { get; set; } = true;

        public int ViewCount { get; set; } = 0;

        public virtual ICollection<Comment> Comments { get; set; }
    }
}