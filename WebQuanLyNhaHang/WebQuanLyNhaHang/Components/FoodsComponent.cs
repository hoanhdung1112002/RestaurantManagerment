using Microsoft.AspNetCore.Mvc;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Components
{
    [ViewComponent(Name = "FoodsView")]
    public class FoodsComponent :ViewComponent
    {
        private readonly DataContext _context;
        public FoodsComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofFood = (from f in _context.Foods
                              where (f.IsActive == true) && (f.Status == 1)
                              orderby f.FoodID ascending
                              select f).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofFood));
        }
    }
}
