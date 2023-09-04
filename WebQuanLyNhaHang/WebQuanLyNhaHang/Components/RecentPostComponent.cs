using Microsoft.AspNetCore.Mvc;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Components
{
    [ViewComponent(Name = "RecentPost")]
    public class RecentPostComponent : ViewComponent
    {
        private readonly DataContext _dataContext;

        public RecentPostComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _dataContext.Posts
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.PostID descending
                              select p).Take(5).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
