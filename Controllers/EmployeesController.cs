using assignment.Models;
using assignment.Repository.IRepository;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers
{
    public class EmployeesController : Controller
    {
        private IUnitsRepository _UReosetory;
        private IEmployeesRepository _EReosetory;

        public EmployeesController(IUnitsRepository UReosetory, IEmployeesRepository EReosetory)
        {
            _UReosetory = UReosetory;
            _EReosetory = EReosetory;
        }
        public IActionResult Index()
        {
            return View();
        }
        //GET - CREATE
        public IActionResult Create()
        {
            return View();
        }
        // Post
        [HttpPost]
        public IActionResult CreateEmployees()
        {
            if(HttpContext.Request.Form.Files.Count==0)
                return RedirectToAction("Create");
            var file = HttpContext.Request.Form.Files[0]; // Uploaded Text File 
            List<Employees> listOfEmployees = new List<Employees>();
            var faker = new Faker();
            //List<int> listOfUnitId = new List<int>();
            if (file.Length < 3000000)
            {
                var fileStream = file.OpenReadStream();
                StreamReader EmployeeFile = new StreamReader(fileStream);
                // Get All units id 
                List<Units> unitsList = _UReosetory.GetUnits().ToList(); // Do some thing if its empty
                Random rnd = new Random();
                if (unitsList.Count > 0)
                {

                    while (EmployeeFile.Peek() >= 0)
                    {
                        Employees employee = new Employees();
                        employee.fullName = EmployeeFile.ReadLine().Trim();
                        employee.number = faker.Phone.ToString();
                        employee.jobTitle = faker.Name.JobTitle();
                        employee.email = faker.Internet.Email();
                        employee.country = faker.Address.Country();
                        employee.units = unitsList[rnd.Next(0, unitsList.Count)];
                        listOfEmployees.Add(employee);
                    }
                    bool result = _EReosetory.CreateEmployees(listOfEmployees);
                }
                else { 
                
                    // To DO
                
                }
            }
            return RedirectToAction("index","Home");
        }
    }

}
