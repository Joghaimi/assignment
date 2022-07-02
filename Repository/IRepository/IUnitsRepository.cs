using assignment.Models;

namespace assignment.Repository.IRepository
{
    public interface IUnitsRepository
    {
        ICollection<Units> GetUnits();
        Units GetUnit(int unitID);
        ICollection<Units> GetUnits(int parentid);
        bool CreateUnits(List<Units> units);
        void CreateUnit(Units unit);
        bool UpdateUnit(Units unit);
        bool DeleteUnit(Units unit);
        bool save();

    }
}
