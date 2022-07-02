using assignment.Data;
using assignment.Models;
using assignment.Repository.IRepository;

namespace assignment.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        ApplicationDbContext _db;
        public EmployeesRepository(ApplicationDbContext db)
        {
            _db = db;

        }
        public bool CreateEmployees(List<Employees> employees)
        {
            foreach (var employe in employees)
            {
                _db.Employees.Add(employe);
            }
            return save();
        }

        public bool CreateEmploye(Employees employe)
        {
            _db.Employees.Add(employe);
            return save();
        }


        public ICollection<Employees> GetEmployees()
        {
            return _db.Employees.OrderBy(u=>u.id).ToList();
        }
        public ICollection<Employees> GetEmployees(int parentid)
        {
            return _db.Employees.Where(a => a.units.unitId == parentid).ToList();
        }
        public ICollection<Employees> GetEmployees(string[] parentid)
        {
            return _db.Employees.Where(a => Array.IndexOf(parentid, a.units.unitId.ToString()) != -1).ToList();
        }

        public bool DeleteEmployees(Employees employe)
        {
            throw new NotImplementedException();
        }

        public Employees GetEmploye(int employeID)
        {
            throw new NotImplementedException();
        }



        public bool save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }
        public bool UpdateEmployees(Employees unemployeit)
        {
            throw new NotImplementedException();
        }

        public int getEmployeeCount(int id)
        {
            return _db.Employees.Where(a => a.units.unitId == id).Count();
        }
        public int getAllEmployeeCount()
        {
            return _db.Employees.SelectMany(o => _db.Employees).Count();
        }
    }
}
