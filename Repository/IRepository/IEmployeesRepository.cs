using assignment.Models;

namespace assignment.Repository.IRepository
{
    public interface IEmployeesRepository
    {
        ICollection<Employees> GetEmployees();
        ICollection<Employees> GetEmployees(int parentid);
        ICollection<Employees> GetEmployees(string[] parentid);

        int getEmployeeCount(int id);
        int getAllEmployeeCount();
        Employees GetEmploye(int employeID);
        bool CreateEmployees(List<Employees> employees);
        bool CreateEmploye(Employees employe);
        bool UpdateEmployees(Employees unemployeit);
        bool DeleteEmployees(Employees employe);
        bool save();
    }
}
