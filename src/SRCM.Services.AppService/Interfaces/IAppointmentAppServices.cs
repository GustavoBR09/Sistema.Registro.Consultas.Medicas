using SRCM.Domain.Entities;
using SRCM.Domain.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Services.AppService.Interfaces
{
    public interface IAppointmentAppServices
    {
        AppointmentViewModel GetById(Guid id);
        IEnumerable<AppointmentViewModel> Search(Expression<Func<Appointment, bool>> expression);
        IEnumerable<AppointmentViewModel> Search(Expression<Func<Appointment, bool>> expression, int pageNumber, int pageSize);
        AppointmentViewModel Add(AppointmentViewModel viewModel);
        AppointmentViewModel Update(AppointmentViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Appointment, bool>> expression);
    }
}
