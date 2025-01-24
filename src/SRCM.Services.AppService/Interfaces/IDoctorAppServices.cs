using SRCM.Domain.Entities;
using SRCM.Domain.Shared;
using SRCM.Domain.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Services.AppService.Interfaces
{
    public interface IDoctorAppServices
    {
        DoctorViewModel GetById(Guid id);
        IEnumerable<DoctorModel> Search(Expression<Func<Doctor, bool>> expression);
        IEnumerable<DoctorModel> Search(Expression<Func<Doctor, bool>> expression, int pageNumber, int pageSize);
        DoctorViewModel Add(DoctorViewModel viewModel);
        DoctorViewModel Update(DoctorViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Doctor, bool>> expression);
        DoctorModel GetModelById(Guid id);
    }
}
