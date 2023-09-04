using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly DataContext _dataContext;

        public MenuController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        //Action Index
        public IActionResult Index()
        {
            var mnList = _dataContext.Menus.OrderBy(m => m.MenuID).ToList();
            return View(mnList);
        }
        //Action Thêm Menu
        public IActionResult Create()
        {
            var mnList = (from m in _dataContext.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mnList = mnList;
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Action thêm Menu vào CSDL
        public IActionResult Create(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Menus.Add(mn);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
        //Action sửa Menu
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _dataContext.Menus.Find(id);
            if (mn == null)
            {
                return NotFound();
            }
            var mnList = (from m in _dataContext.Menus
                          select new SelectListItem()
                          {
                              Text = m.MenuName,
                              Value = m.MenuID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View(mn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Menu mn)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Menus.Update(mn);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mn);
        }
        //Action sửa Menu trong CSDL

        //Action Xoá Menu
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var mn = _dataContext.Menus.Find(id);

            if (mn == null)
            {
                return NotFound();
            }
            return View(mn);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var deleMenu = _dataContext.Menus.Find(id);
            if (deleMenu == null)
            {
                return NotFound();
            }
            _dataContext.Menus.Remove(deleMenu);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

