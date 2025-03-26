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
    public interface IAppointmentSchedulingAppServices
    {
        AppointmentSchedulingViewModel GetById(Guid id);
        IEnumerable<AppointmentSchedulingViewModel> Search(Expression<Func<AppointmentScheduling, bool>> expression);
        IEnumerable<AppointmentSchedulingViewModel> Search(Expression<Func<AppointmentScheduling, bool>> expression, int pageNumber, int pageSize);
        AppointmentSchedulingViewModel Add(AppointmentSchedulingViewModel viewModel);
        AppointmentSchedulingViewModel Update(AppointmentSchedulingViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<AppointmentScheduling, bool>> expression);
        IEnumerable<AppointmentSchedulingModel> GetAppointmentScheduling(DateTime? date, string name);
    }
}
