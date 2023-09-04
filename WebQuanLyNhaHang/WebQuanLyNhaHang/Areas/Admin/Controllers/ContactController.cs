using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly DataContext _dataContext;

        public ContactController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var dlList = _dataContext.Contacts.OrderBy(p => p.ContactID).ToList();
            return View(dlList);
        }

        //Actionn xóa liên hệ khách hàng
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dl = _dataContext.Contacts.Find(id);

            if (dl == null)
            {
                return NotFound();
            }
            return View(dl);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var deleContact = _dataContext.Contacts.Find(id);
            if (deleContact == null)
            {
                return NotFound();
            }
            _dataContext.Contacts.Remove(deleContact);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

