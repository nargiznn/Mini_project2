using Core.Entitiy;
using System;
using Data;
using Service.Exceptions;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entitiy;
using Data;
using Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Service
{
    public class DoctorService
    {
        private HosbitalDbContext _context;
        public DoctorService()
        {
            _context = new HosbitalDbContext();
        }
        public void Create(Doctor entity)
        {
            if (_context.Doctors.Any(x => x.Fullname == entity.Fullname))
                throw new EntityDublicateException("Doctor already exists by fullname: " + entity.Fullname);
            _context.Doctors.Add(entity);
            _context.SaveChanges();
        }
        public List<string> ShowAll()
        {
            var doctors = _context.Doctors.Include(d => d.Appointments).ToList();

            List<string> doctorInfList = new List<string>();

            foreach (var doctor in doctors)
            {
                string doctorInf = $"{doctor.Id}. {doctor.Fullname} ({doctor.Email})";

                var nextAppointments = doctor.Appointments
                    .Where(a => a.StartDate >= DateTime.Now)
                    .OrderBy(a => a.StartDate)
                    .ToList();

                int nextAppointmentsCount = nextAppointments.Count;

                doctorInf += $", Next Appointments: {nextAppointmentsCount}";

                doctorInfList.Add(doctorInf);
            }

            return doctorInfList;
        }

        public void Delete(int id)
        {
            var entity = _context.Doctors.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Doctor not found");

            _context.Doctors.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(int id, Doctor entity)
        {
            var existEntity = _context.Doctors.FirstOrDefault(x => x.Id == id);

            if (existEntity == null) throw new EntityNotFoundException("Doctor not found");

            existEntity.Fullname = entity.Fullname;
            existEntity.Email = entity.Email;
            _context.SaveChanges();
        }
        public Doctor GetById(int id)
        {
            var entity = _context.Doctors.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Doctor not found");
            return entity;
        }
    }
}
