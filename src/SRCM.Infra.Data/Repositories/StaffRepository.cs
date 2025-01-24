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
    public class StaffRepository : Repository<Staff>, IStaffRepository
    {
        public StaffRepository(SRCMDbContext context) : base(context)
        {
        }

        public Staff Add(Staff entity)
        {
            DbSet.Add(entity);
            return entity;
        }

        public Staff GetById(Guid id)
        {
            var context = DbSet.AsQueryable().Include("Address");
            var staff = context.FirstOrDefault(c => c.Id == id);
            return staff;
        }

        public void Remove(Guid id)
        {
            var obj = GetById(id);
            if (obj != null)
            {
                DbSet.Remove(obj);
            }
        }

        public void Remove(Expression<Func<Staff, bool>> predicate)
        {
            var context = DbSet.AsQueryable();
            var entities = context.Where(predicate);

            DbSet.RemoveRange(entities);
        }

        public IEnumerable<Staff> Search(Expression<Func<Staff, bool>> predicate)
        {
            var context = DbSet.AsQueryable().Include("Address");
            var entities = context.Where(predicate);
            return entities;
        }

        public IEnumerable<Staff> Search(Expression<Func<Staff, bool>> predicate, int pageNumber, int pageSize)
        {
            var context = DbSet.AsQueryable().Include("Address");
            var entities = context.Where(predicate).Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return entities;
        }

        public Staff Update(Staff entity)
        {
            DbSet.Update(entity);
            return entity;
        }
    }
}
