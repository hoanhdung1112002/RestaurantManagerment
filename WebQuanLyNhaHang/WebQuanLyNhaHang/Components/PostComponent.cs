using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Components
{
    [ViewComponent(Name ="PostView")]
    public class PostComponent :ViewComponent
    {
        private readonly DataContext _dataContext;

        public PostComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _dataContext.Posts
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.PostID descending
                              select p).Take(3).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
