using Microsoft.EntityFrameworkCore;
using SRCM.Domain.Entities;
using SRCM.Domain.Interfaces;
using SRCM.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Infra.Data.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(SRCMDbContext context) : base(context)
        {
        }

        public Patient Add(Patient entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Patient GetById(Guid id)
        {
            var context = DbSet.AsQueryable().Include("Address");
            var patient = context.FirstOrDefault(c => c.Id == id);
            return patient;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Patient, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);

            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Patient> Search(Expression<Func<Patient, bool>> predicate)
        {
            var context = DbSet.AsQueryable().Include("Address");
            var entities = context.Where(predicate);
            return entities;
        }

        public IEnumerable<Patient> Search(Expression<Func<Patient, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable().Include("Address");
            var entities = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return entities;
        }

        public Patient Update(Patient entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
