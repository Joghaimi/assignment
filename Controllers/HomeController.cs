using assignment.Data;
using assignment.Models;
using assignment.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
namespace assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IUnitsRepository _UReosetory;
        private IEmployeesRepository _EReosetory;
        private ApplicationDbContext _applicationDbContext;
        public HomeController(ILogger<HomeController> logger, IUnitsRepository UReosetory, IEmployeesRepository EReosetory,ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _UReosetory = UReosetory;
            _EReosetory = EReosetory;
            _applicationDbContext=applicationDbContext;

        }
        public IActionResult Index()
        {

            var rootUnits = _UReosetory.GetUnits(-1);
            //ViewBag.json = Json(rootUnits);
            return View(rootUnits);
        }
        public IActionResult getUnits(int id)
        {
            List<Units> rootUnits = _UReosetory.GetUnits(id).ToList();
            return Json(rootUnits);
        }
        public IActionResult getAllUnits()
        {
            List<Units> rootUnits = _UReosetory.GetUnits(-1).ToList();
            return Json(rootUnits);
        }
        public IActionResult getAllEmployees()
        {
            var employeeNumer = _EReosetory.getAllEmployeeCount();
            var draw = HttpContext.Request.Query["draw"].ToString();
            var start =int.Parse( HttpContext.Request.Query["start"]);
            var length = int.Parse(HttpContext.Request.Query["length"]);
            return Json(new { draw = draw, totalRecords = employeeNumer, recordsFiltered = employeeNumer, data = _applicationDbContext.Employees.OrderBy(u => u.id).Skip(start).Take(length) });
        }




        public IActionResult getEmployees(string ids)
        {
            if (ids == null) return Json("");
            List<Employees> employeesList = new List<Employees>();
            string[] idList = ids.Split(",");
            List <int>idintList = new List<int>();
            int employeeNumer = 0;
            foreach (var id in idList)
            {
                if (id != "" && id != ",")
                {
                    employeeNumer += _EReosetory.getEmployeeCount(int.Parse(id));// employeesList.AddRange(_EReosetory.GetEmployees(int.Parse(id)));
                    idintList.Add(int.Parse(id));
                }
            }
            var draw = HttpContext.Request.Query["draw"].ToString();
            var start = int.Parse(HttpContext.Request.Query["start"]);
            var length = int.Parse(HttpContext.Request.Query["length"]);
            
            return Json(new { draw = draw, totalRecords= employeeNumer, recordsFiltered = employeeNumer, data = _applicationDbContext.Employees.Where(a => idintList.Contains(a.units.parentId)).Skip(start).Take(length) });
        }




        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}