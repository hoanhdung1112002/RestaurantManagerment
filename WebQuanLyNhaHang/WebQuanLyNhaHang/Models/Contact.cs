using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyNhaHang.Models
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        public int ContactID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Title { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
    }
}
