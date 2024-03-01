using Core.Entitiy;
using Data;
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
            if (_context.Patients.Any(x => x.Fullname == entity.Fullname))
                throw new EntityDublicateException("Patient already exists by fullname: " + entity.Fullname);
            _context.Patients.Add(entity);
            _context.SaveChanges();
        }
        public List<Patient> ShowAll()
        {
            return _context.Patients.ToList();
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
