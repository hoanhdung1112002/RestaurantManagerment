using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyNhaHang.Models
{
    [Table("tblOrder")]
    public class Order
    {
        [Key]
        public int OrderID { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public int SoLuong { get; set; }
        public DateTime? OrderDate { get; set; }
        public string? Note { get; set; }
        public bool? IsActive { get; set; }
    }
}
