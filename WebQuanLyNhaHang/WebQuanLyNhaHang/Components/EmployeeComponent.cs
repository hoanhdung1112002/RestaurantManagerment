using Microsoft.AspNetCore.Mvc;
using WebQuanLyNhaHang.Models;

namespace WebQuanLyNhaHang.Components
{
    [ViewComponent(Name = "EmployeeView")]
    public class EmployeeComponent :ViewComponent
    {
        private readonly DataContext _context;
        public EmployeeComponent(DataContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofEmployees = (from e in _context.Employees
                              where (e.IsActive == true)
                              orderby e.EmployeeID descending
                              select e).Take(4).ToList();

            return await Task.FromResult((IViewComponentResult)View("Default", listofEmployees));
        }
    }

}
