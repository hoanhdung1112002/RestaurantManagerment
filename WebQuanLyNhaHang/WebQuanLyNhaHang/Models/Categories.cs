using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyNhaHang.Models
{
    [Table("tblCategories")]
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public int Position { get; set; }
        public string? DataFilter { get; set; }
    }
}
