using assignment.Models;
using assignment.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace assignment.Controllers
{
    public class UnitsController : Controller
    {

        private IUnitsRepository _UReosetory;
        public UnitsController(IUnitsRepository UReosetory)
        {
            _UReosetory = UReosetory;
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
        public IActionResult CreateUnits()
        {
            if (HttpContext.Request.Form.Files.Count == 0)
                return RedirectToAction("Create");

            var file = HttpContext.Request.Form.Files[0]; // Uploaded Text File 
            List<Units> listOfUnits = new List<Units>();
            List<int> listOfUnitId = new List<int>();
            if (file.Length < 3000000)
            {
                var fileStream = file.OpenReadStream();
                StreamReader UnitsFile = new StreamReader(fileStream);
                Random rnd = new Random();
                int levelDistributor = 0;
                int startingUnitid = 1;
                int count = 0;
                int strtingUnitID = -1;
                int strtingUnitLevel = 0;
                int numberOfParentChildren = 0;

                while (UnitsFile.Peek() >= 0)
                {
                    Units unit = new Units();
                    unit.unitName = UnitsFile.ReadLine().Trim();
                    if (numberOfParentChildren < 40)
                    {
                        numberOfParentChildren++;
                        if (count < 4)
                        {
                            unit.unitLevel = strtingUnitLevel;
                            unit.parentId = strtingUnitID;
                            _UReosetory.CreateUnit(unit);
                            _UReosetory.save();
                            strtingUnitID = unit.unitId;
                            listOfUnitId.Add(unit.unitId);
                            strtingUnitLevel++;
                            count++;
                        }
                        else
                        {
                            count = 0;
                            strtingUnitID = -1;
                            strtingUnitLevel = 0;
                        }
                    }
                    else
                    {

                        unit.unitLevel = 1;
                        unit.parentId = listOfUnitId[rnd.Next(0, listOfUnitId.Count-1)];
                        _UReosetory.CreateUnit(unit);
                        _UReosetory.save();

                    }


                    //    if (levelDistributor == 0)
                    //    {
                    //        // get the unitId
                    //        unit.unitLevel = 0;
                    //        unit.parentId = -1;
                    //        _UReosetory.CreateUnit(unit);
                    //        _UReosetory.save();
                    //        listOfUnitId.Add(unit.unitId);
                    //        startingUnitid = unit.unitId;

                    //    }
                    //    else if (levelDistributor < 10)
                    //    {
                    //        // Set Top Level Units
                    //        unit.unitLevel = 0;
                    //        unit.parentId = -1;
                    //        listOfUnitId.Add(++startingUnitid);
                    //    }
                    //    else if (levelDistributor < 20)
                    //    {
                    //        // Set Level 2 Units
                    //        unit.unitLevel = 1;
                    //        unit.parentId = listOfUnitId[rnd.Next(0,9)];
                    //        listOfUnitId.Add(++startingUnitid);

                    //    }
                    //    else if (levelDistributor < 30)
                    //    {
                    //        // Unit 3
                    //        unit.unitLevel = 2;
                    //        unit.parentId = listOfUnitId[rnd.Next(10, 19)];
                    //        listOfUnitId.Add(++startingUnitid);

                    //    }
                    //    else
                    //    {
                    //        int randomNumber = rnd.Next(9, 29);
                    //        Units randomUnitParent = listOfUnits[randomNumber];
                    //        unit.unitLevel = randomUnitParent.unitLevel + 1;
                    //        unit.parentId = listOfUnitId[randomNumber];
                    //        listOfUnitId.Add(++startingUnitid);
                    //    }

                    //    listOfUnits.Add(unit);
                    //    levelDistributor++;
                    //}
                    //// Update Taple
                    //listOfUnits.RemoveAt(0);
                    //bool result = _UReosetory.CreateUnits(listOfUnits);

                }
            }



            return RedirectToAction("index", "Home");


        }
    }
}
