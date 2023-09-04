using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly DataContext _dataContext;

        public PostController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IActionResult Index()
        {
            var dlList = _dataContext.Posts.OrderBy(p => p.PostID).ToList();
            return View(dlList);
        }

        //Action thêm bài viết
        public IActionResult Create()
        {
            var mList = (from m in _dataContext.Posts
                         select new SelectListItem()
                         {
                             Text = m.Title,
                             Value = m.PostID.ToString(),
                         }).ToList();
            mList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = "0"
            });
            ViewBag.pList = mList;
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Action thêm bài viết vào CSDL
        public IActionResult Create(Post p)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Posts.Add(p);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        //Action sửa bài viết
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var p = _dataContext.Posts.Find(id);
            if (p == null)
            {
                return NotFound();
            }
            var pList = (from m in _dataContext.Posts
                         select new SelectListItem()
                         {
                             Text = m.Title,
                             Value = m.PostID.ToString(),
                         }).ToList();
            pList.Insert(0, new SelectListItem()
            {
                Text = "----Select----",
                Value = string.Empty
            });
            ViewBag.mnList = pList;
            return View(p);
        }
        //Action sửa bài viết trong CSDL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post p)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Posts.Update(p);
                _dataContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var dl = _dataContext.Posts.Find(id);

            if (dl == null)
            {
                return NotFound();
            }
            return View(dl);
        }

        [HttpPost]

        public IActionResult Delete(int id)
        {
            var delePost = _dataContext.Posts.Find(id);
            if (delePost == null)
            {
                return NotFound();
            }
            _dataContext.Posts.Remove(delePost);
            _dataContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

