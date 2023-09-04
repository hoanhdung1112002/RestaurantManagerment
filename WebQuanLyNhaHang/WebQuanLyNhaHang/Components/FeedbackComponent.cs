using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Components
{
    [ViewComponent(Name ="FeedbackView")]
    public class FeedbackComponent :ViewComponent
    {
        private readonly DataContext _dataContext;

        public FeedbackComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofFeedback = (from f in _dataContext.Feedbacks
                              where (f.IsActive == true)
                              orderby f.FeedbackID descending
                              select f).Take(4).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofFeedback));
        }
    }
}
