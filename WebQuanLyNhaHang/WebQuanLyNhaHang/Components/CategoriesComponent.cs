using Microsoft.AspNetCore.Mvc;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Components
{
    [ViewComponent(Name = "CategoriesView")]
    public class CategoriesComponent : ViewComponent
    {
        private DataContext _dataContext;
        public CategoriesComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofCategory = (from c in _dataContext.Categories
                                  select c).Take(5).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofCategory));
        }
    }
}
