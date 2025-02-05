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
    public interface IPatientAppServices
    {
        PatientViewModel GetById(Guid id);
        PatientModel GetModelById(Guid id);
        IEnumerable<PatientModel> Search(Expression<Func<Patient, bool>> expression);
        IEnumerable<PatientModel> Search(Expression<Func<Patient, bool>> expression, int pageNumber, int pageSize);
        PatientViewModel Add(PatientViewModel viewModel);
        PatientViewModel Update(PatientViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Patient, bool>> expression);
    }
}
