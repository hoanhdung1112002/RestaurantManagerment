using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyNhaHang.Models
{
    [Table("tblMenuFooter")]
    public class MenuFooter
    {
        [Key]
        public int MenuFooterID { get; set; }
        public string? MenuFooterName { get; set; }
        public bool? IsActive { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public int Levels { get; set; }
        public int ParentID { get; set; }
        public int MenuOrder { get; set; }
        public int Position { get; set; }
        public string Icon { get; set; }
    }
}
