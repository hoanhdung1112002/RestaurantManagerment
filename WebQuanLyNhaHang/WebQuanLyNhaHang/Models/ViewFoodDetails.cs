using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebQuanLyNhaHang.Models
{
    [Table("View_FoodDetails")]
    public class ViewFoodDetails
    {
        [Key]
        public int CategoryID { get; set; }
        public string? EmployeeName { get; set; }
        public int FoodID { get; set; }
        public string? CategoryName { get; set; }
        public string? FoodName { get; set; }
        public string? Description { get; set; }
        public string? Material { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public string? Link { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public int Status { get; set; }
        public string? DataFood { get; set; }
    }
}
