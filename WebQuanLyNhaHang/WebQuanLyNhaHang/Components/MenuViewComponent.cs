using Microsoft.AspNetCore.Mvc;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Components
{
    [ViewComponent(Name = "MenuView")]
    public class MenuViewComponent :ViewComponent
    {
        private DataContext _dataContext;
        public MenuViewComponent(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofMenu = (from m in _dataContext.Menus
                              where (m.IsActive == true) && (m.Position == 1)
                              select m).ToList();
            //m.Position == 1 là những menu nằm phía trên

            return await Task.FromResult((IViewComponentResult)View("Default", listofMenu));
        }
    }
}
