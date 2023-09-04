using Microsoft.AspNetCore.Mvc;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Components
{
    [ViewComponent(Name = "MenuFooterView")]
    public class MenuFooterComponent : ViewComponent
    {
        private readonly DataContext _dataContext;

        public MenuFooterComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenuFooter = (from m in _dataContext.MenuFooter
                              where (m.IsActive == true) && (m.Position == 1)
                              select m).ToList();
            //m.Position == 1 là những menu nằm phía trên

            return await Task.FromResult((IViewComponentResult)View("Default", listofMenuFooter));
        }
    }
}
