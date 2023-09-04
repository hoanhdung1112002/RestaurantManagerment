using Microsoft.AspNetCore.Mvc;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Areas.Admin.Components
{
    [ViewComponent(Name = "AdminMenu")]
    public class AdminMenuComponent : ViewComponent
    {
        private readonly DataContext _context;

        public AdminMenuComponent(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var mnList = (from mnu in _context.AdminMenus
                          where (mnu.IsActive == true)
                          select mnu).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", mnList));
        }
    }
}

