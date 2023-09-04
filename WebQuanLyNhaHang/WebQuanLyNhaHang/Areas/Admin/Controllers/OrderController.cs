using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly DataContext _dataContext;

        public OrderController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var dlList = _dataContext.Orders.OrderBy(p => p.OrderID).ToList();
            return View(dlList);
        }

       //Actionn xóa bàn ăn
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dl = _dataContext.Orders.Find(id);

            if (dl == null)
            {
                return NotFound();
            }
            return View(dl);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var deleOrder = _dataContext.Orders.Find(id);
            if (deleOrder == null)
            {
                return NotFound();
            }
            _dataContext.Orders.Remove(deleOrder);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

