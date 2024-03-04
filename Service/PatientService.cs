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
    public class PatientService
    {
        private HosbitalDbContext _context;
        public PatientService()
        {
            _context = new HosbitalDbContext();
        }
        public void Create(Patient entity)
        {
            do
            {
                while (string.IsNullOrWhiteSpace(entity.Fullname) || _context.Patients.Any(x => x.Fullname == entity.Fullname))
                {
                    Console.WriteLine("Already exists or not null enter please again !");
                    Console.Write("Fullname: ");
                    entity.Fullname = Console.ReadLine();
                }

                do
                {
                    if ((string.IsNullOrWhiteSpace(entity.Email) || _context.Patients.Any(x => x.Email == entity.Email)))
                    {
                        Console.WriteLine("Patient email already exists. Please again !");
                        Console.Write("Email: ");
                        entity.Email = Console.ReadLine();
                    }
                } while (_context.Patients.Any(x => x.Email == entity.Email));

            } while (_context.Patients.Any(x => x.Fullname == entity.Fullname));

            _context.Patients.Add(entity);
            _context.SaveChanges();
        }



        public List<string> ShowAll()
        {
            var patients = _context.Patients.Include(p => p.Appointments).ToList();

            List<string> patientShowAll = new List<string>();

            foreach (var patient in patients)
            {
                string patientInf = $"{patient.Id}. {patient.Fullname} ({patient.Email})";

                int countAppointments = patient.Appointments.Count;

                var nextAppointments = patient.Appointments
                    .Where(a => a.StartDate >= DateTime.Now)
                    .OrderBy(a => a.StartDate)
                    .ToList();

                if (nextAppointments.Any())
                {
                    DateTime firstNextAppointmentDate = nextAppointments.First().StartDate;
                    patientInf += $", Count Appointments: {countAppointments}, First next Appointment Date: {firstNextAppointmentDate.ToShortDateString()}";
                }
                else
                {
                    patientInf += $", Count Appointments: {countAppointments}, No next Appointments";
                }

                patientShowAll.Add(patientInf);
            }

            return patientShowAll;
        }

        public void Delete(int id)
        {
            var entity = _context.Patients.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Patient not found");

            _context.Patients.Remove(entity);
            _context.SaveChanges();
        }
        public void Update(int id, Patient entity)
        {
            var existEntity = _context.Patients.FirstOrDefault(x => x.Id == id);

            if (existEntity == null) throw new EntityNotFoundException("Patient not found");

            existEntity.Fullname = entity.Fullname;
            existEntity.Email = entity.Email;

            _context.SaveChanges();
        }
        public Patient GetById(int id)
        {
            var entity = _context.Patients.FirstOrDefault(x => x.Id == id);

            if (entity == null) throw new EntityNotFoundException("Patient not found");
            return entity;
        }

    }
}
