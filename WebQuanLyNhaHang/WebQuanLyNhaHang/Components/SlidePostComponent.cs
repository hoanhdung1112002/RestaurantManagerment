using Microsoft.AspNetCore.Mvc;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Components
{
    [ViewComponent(Name = "SlidePostView")]
    public class SlidePostComponent : ViewComponent
    {
        private readonly DataContext _dataContext;
        public SlidePostComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _dataContext.Posts
                              where (p.IsActive == true) && (p.Status == 1)
                              orderby p.PostID descending
                              select p).Take(1).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }
    }
}
