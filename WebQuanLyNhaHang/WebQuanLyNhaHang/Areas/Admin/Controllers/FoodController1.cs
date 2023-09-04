using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FoodsController : Controller
    {
        private readonly DataContext _dataContext;

        public FoodsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var dlList = _dataContext.Foods.OrderBy(d => d.FoodID).ToList();
            return View(dlList);
        }

        //Action thêm món
        public IActionResult Create()
        {
            var fdList = (from m in _dataContext.Foods
                          select new SelectListItem()
                          {
                              Text = m.FoodName,
                              Value = m.FoodID.ToString(),
                          }).ToList();
            fdList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mnList = fdList;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Action thêm món vào CSDL
        public IActionResult Create(Foods fd)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Foods.Add(fd);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fd);
        }

        //Action sửa món
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var fd = _dataContext.Foods.Find(id);
            if (fd == null)
            {
                return NotFound();
            }
            var mnList = (from m in _dataContext.Foods
                          select new SelectListItem()
                          {
                              Text = m.FoodName,
                              Value = m.FoodID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View(fd);
        }

        //Action sửa món trong CSDL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Foods fd)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Foods.Update(fd);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fd);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dl = _dataContext.Foods.Find(id);

            if (dl == null)
            {
                return NotFound();
            }
            return View(dl);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var deleFoods = _dataContext.Foods.Find(id);
            if (deleFoods == null)
            {
                return NotFound();
            }
            _dataContext.Foods.Remove(deleFoods);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

