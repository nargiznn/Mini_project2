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
        private readonly HosbitalDbContext _context;

        public AppointmentService()
        {
            _context = new HosbitalDbContext();
        }
        public void Create(Appointment entity)
        {
            Patient patient = null;
            Doctor doctor = null;

            while (patient == null || doctor == null)
            {
                int patientId = entity.PatientId;
                patient = _context.Patients.Include(x => x.Appointments).FirstOrDefault(x => x.Id == patientId);

                if (patient == null)
                {
                    Console.WriteLine("Patient not found. Try again? (Y/N)");
                    if (Console.ReadLine().Trim().ToUpper() == "Y")
                    {
                        Console.Write("Enter new Patient ID: ");
                        int newPatientId;
                        if (int.TryParse(Console.ReadLine(), out newPatientId))
                        {
                            entity.PatientId = newPatientId;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Patient ID format. Please enter a valid integer.");
                        }
                    }
                    else
                    {
                        throw new EntityNotFoundException("Patient not found");
                    }
                }
                int doctorId = entity.DoctorId;
                doctor = _context.Doctors.Include(x => x.Appointments).FirstOrDefault(x => x.Id == doctorId);

                if (doctor == null)
                {
                    Console.WriteLine("Doctor not found. Do you want to try again? (Y/N)");
                    if (Console.ReadLine().Trim().ToUpper() == "Y")
                    {
                        Console.Write("Enter new Doctor ID: ");
                        int newDoctorId;
                        if (int.TryParse(Console.ReadLine(), out newDoctorId))
                        {
                            entity.DoctorId = newDoctorId;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Doctor ID format. Please enter a valid integer.");
                        }
                    }
                    else
                    {
                        throw new EntityNotFoundException("Doctor not found");
                    }
                }
            }
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


        public List<Appointment> FilterByDoctor(int doctorId)
        {
            return _context.Appointment
                .Where(appointment => appointment.DoctorId == doctorId)
                .ToList();
        }

        public List<Appointment> FilterByPatient(int patientId)
        {
            return _context.Appointment
                .Where(appointment => appointment.PatientId == patientId)
                .ToList();
        }

        public List<Appointment> FilterByDateRange(DateTime startDate, DateTime endDate)
        {
            return _context.Appointment
                .Where(appointment => appointment.StartDate >= startDate && appointment.StartDate <= endDate)
                .ToList();
        }
    }
    }

