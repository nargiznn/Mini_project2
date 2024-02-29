using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service
{
    public class PatientService
    {
        private HosbitalDbContext _context;
        //private CourseDbContext _context;
        //public GroupService()
        //{
        //    _context = new CourseDbContext();
        //}
        //public void Create(Group entity)
        //{
        //    if (_context.Groups.Any(x => x.No == entity.No))
        //        throw new EntityDublicateException("Group already exists by no: " + entity.No);

        //    _context.Groups.Add(entity);
        //    _context.SaveChanges();
        //}
    }
}
