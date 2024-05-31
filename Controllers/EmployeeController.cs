using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agri.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        public IActionResult EmployeeDashboard()
        {
            return View();
        }

        // Add methods for employee-specific functionalities here
    }
}
