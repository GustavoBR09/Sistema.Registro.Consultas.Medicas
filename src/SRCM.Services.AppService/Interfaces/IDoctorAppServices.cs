﻿using SRCM.Domain.Entities;
using SRCM.Services.AppService.ViewModel;
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
        IEnumerable<DoctorViewModel> Search(Expression<Func<Doctor, bool>> expression);
        IEnumerable<DoctorViewModel> Search(Expression<Func<Doctor, bool>> expression, int pageNumber, int pageSize);
        DoctorViewModel Add(DoctorViewModel viewModel);
        DoctorViewModel Update(DoctorViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Doctor, bool>> expression);
    }
}
