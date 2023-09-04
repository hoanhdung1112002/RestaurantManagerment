using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeesController : Controller
    {
        private readonly DataContext _dataContext;

        public EmployeesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var dsList = _dataContext.Employees.OrderBy(d => d.EmployeeID).ToList();
            return View(dsList);
        }

        //Action thêm nhân viên
        public IActionResult Create()
        {
            var edList = (from m in _dataContext.Employees
                          select new SelectListItem()
                          {
                              Text = m.EmployeeName,
                              Value = m.EmployeeID.ToString(),
                          }).ToList();
            edList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.mnList = edList;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Action thêm nhân viên vào CSDL
        public IActionResult Create(Employee ed)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Employees.Add(ed);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ed);
        }

        //Action sửa nhân viên
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var fd = _dataContext.Employees.Find(id);
            if (fd == null)
            {
                return NotFound();
            }
            var mnList = (from m in _dataContext.Employees
                          select new SelectListItem()
                          {
                              Text = m.EmployeeName,
                              Value = m.EmployeeID.ToString(),
                          }).ToList();
            mnList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = mnList;
            return View(fd);
        }

        //Action sửa nhân viên trong CSDL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Employee ed)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Employees.Update(ed);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ed);
        }

        //Action xóa nhân viên
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dl = _dataContext.Employees.Find(id);

            if (dl == null)
            {
                return NotFound();
            }
            return View(dl);
        }
        //Action xóa nhân viên trong CSDL
        [HttpPost]

        public IActionResult Delete(int id)
        {
            var deleEmployees = _dataContext.Employees.Find(id);
            if (deleEmployees == null)
            {
                return NotFound();
            }
            _dataContext.Employees.Remove(deleEmployees);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

