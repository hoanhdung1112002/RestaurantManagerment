using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebQuanLyNhaHang.Models
{
    [Table("tblEmployees")]
    public class Employee
    {
        [Key]
        public int EmployeeID { get; set; }
        public string? EmployeeName { get; set; }
        public string? Position { get; set; }
        public string? Image { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public bool? IsActive { get; set; }
        public string? Description { get; set; }
    }
}
