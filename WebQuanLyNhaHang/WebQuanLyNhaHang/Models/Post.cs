using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyNhaHang.Models
{
    [Table("tblPosts")]
    public class Post
    {
        [Key]
        public int PostID { get; set; }
        public string? Title { get; set; }
        public string? Abstract { get; set; }
        public string? Contents { get; set; }
        public string? Images { get; set; }
        public string? Link { get; set; }
        public string? Author { get; set; }
        public string? Icon { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int Category { get; set; }
        public int Status { get; set; }

    }
}
