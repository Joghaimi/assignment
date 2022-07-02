using assignment.Data;
using assignment.Models;
using assignment.Repository.IRepository;

namespace assignment.Repository
{
    public class UnitsRepository : IUnitsRepository
    {
        ApplicationDbContext _db;
        public UnitsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateUnits(List<Units> units)
        {
            foreach (var unit in units)
            {
                _db.Unit.Add(unit);
            }
            return save();
        }


        public void CreateUnit(Units unit)
        {
            _db.Unit.Add(unit);
        }


        public bool DeleteUnit(Units unit)
        {
            throw new NotImplementedException();
        }

        public Units GetUnit(int unitID)
        {
            throw new NotImplementedException();
        }

        public ICollection<Units> GetUnits()
        {
            return _db.Unit.OrderBy(a=>a.unitId).ToList();
        }
        public ICollection<Units> GetUnits(int parentid)
        {
            return _db.Unit.Where(a=>a.parentId == parentid).ToList();
        }

        public bool UpdateUnit(Units unit)
        {
            throw new NotImplementedException();
        }
        public bool save()
        {
            return _db.SaveChanges() > 0 ? true : false;
        }
    }
}
