using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public bool Create(LeaveType entity)
        {
            // Connect to the database = _db | Specify Table = .LeaveTypes | Add new entity as parameter as what the function expects. 
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {

            // Returns a list as a GET * (everything) from SQL within the Leavetypes table
           return _db.LeaveTypes.ToList();
            // second way of writing this line
            // var leaveTypes = _db.LeaveTypes.ToList();
            //    return leaveTypes;
            // 1. return _db = Access to private implementation of the database 2. dot LeaveTypes specifies the table being  called 3. dot ToList(); returns the array within a list (C# glorified Array)


        }

        public LeaveType FindById(int id)
        {
            var leaveType = _db.LeaveTypes.Find(id);
            return leaveType;

        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges();
            return changes > 0;
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();

        }
    }
}
