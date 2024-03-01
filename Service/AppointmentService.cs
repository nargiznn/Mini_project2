using Core.Entitiy;
using Data;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Service
{
    public class AppointmentService
    {
        private HosbitalDbContext _context;

        public AppointmentService()
        {
            _context = new HosbitalDbContext();
        }

        public void Create(Appointment entity)
        {
            Patient patient = _context.Patients.Include(x => x.Appointments).FirstOrDefault(x => x.Id == entity.PatientId);
            if (patient == null) throw new EntityNotFoundException("Patient not found");
            Doctor doctor = _context.Doctors.Include(x => x.Appointments).FirstOrDefault(x => x.Id == entity.DoctorId);
            if (doctor == null) throw new EntityNotFoundException("Doctor not found");
            _context.Appointment.Add(entity);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Appointment entity = _context.Appointment.Find(id);
            if(entity==null) throw new EntityNotFoundException("Appointment not found");
            _context.Appointment.Remove(entity);
            _context.SaveChanges();

        }
        public void Update(int id,Appointment entity)
        {
            Appointment existEntity = _context.Appointment.Find(id);
            if (existEntity == null) throw new EntityNotFoundException("Appointment not found");
            if (entity.PatientId != existEntity.PatientId)
            {
                var patient = _context.Patients.Include(x => x.Appointments).FirstOrDefault(x => x.Id == entity.PatientId);

                if (patient == null) throw new EntityNotFoundException("Patient not found");

            }
            if (entity.DoctorId != existEntity.DoctorId)
            {
                var doctor = _context.Doctors.Include(x => x.Appointments).FirstOrDefault(x => x.Id == entity.DoctorId);

                if (doctor == null) throw new EntityNotFoundException("Doctor not found");

            }
              existEntity.PatientId = entity.PatientId;
            existEntity.DoctorId = entity.DoctorId;
            existEntity.StartDate = entity.StartDate;
            _context.SaveChanges();

        }
        public List<Appointment> ShowAll()
        {
            return _context.Appointment.ToList();
        }
    }
}
