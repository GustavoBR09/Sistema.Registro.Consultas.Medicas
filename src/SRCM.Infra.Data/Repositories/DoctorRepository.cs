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
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly IAddressRepository _addressRepository;
        public DoctorRepository(SRCMDbContext context, IAddressRepository addressRepository) : base(context)
        {
            _addressRepository = addressRepository;
        }

        public Doctor Add(Doctor entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Doctor GetById(Guid id)
        {
            var context = DbSet.AsQueryable().Include("Address");
            var doctor = context.FirstOrDefault(c => c.Id == id);
            return doctor;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Doctor, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);

            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Doctor> Search(Expression<Func<Doctor, bool>> predicate)
        {
            var context = DbSet.AsQueryable().Include("Address");
            var entities = context.Where(predicate);

            return entities;
        }

        public IEnumerable<Doctor> Search(Expression<Func<Doctor, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable().Include("Address");
            var entities = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return entities;
        }

        public Doctor Update(Doctor entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}