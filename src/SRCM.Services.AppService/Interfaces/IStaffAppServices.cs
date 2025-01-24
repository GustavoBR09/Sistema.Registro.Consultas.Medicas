using SRCM.Domain.Entities;
using SRCM.Domain.Shared.Models;
using SRCM.Domain.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Services.AppService.Interfaces
{
    public interface IStaffAppServices
    {
        StaffViewModel GetById(Guid id);
        StaffModel GetModelById(Guid id);
        IEnumerable<StaffModel> Search(Expression<Func<Staff, bool>> expression);
        IEnumerable<StaffModel> Search(Expression<Func<Staff, bool>> expression, int pageNumber, int pageSize);
        StaffViewModel Add(StaffViewModel viewModel);
        StaffViewModel Update(StaffViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Staff, bool>> expression);
    }
}
