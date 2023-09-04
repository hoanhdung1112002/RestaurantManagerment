using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebQuanLyNhaHang.Models
{
    [Table("tblFeedback")]
    public class Feedback
    {
        [Key]
        public int FeedbackID { get; set; }
        public string? Icon { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public string? Profession { get; set; }
        public bool? IsActive { get; set; }
    }
}
