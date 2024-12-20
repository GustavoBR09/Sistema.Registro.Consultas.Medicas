using AutoMapper;
using MediatR;
using SRCM.Domain.Entities;
using SRCM.Domain.Interfaces;
using SRCM.Domain.Shared.Transaction;
using SRCM.Services.AppService.Interfaces;
using SRCM.Domain.Shared.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Services.AppService.Services
{
    public class AppointmentSchedulingAppService : BaseService, IAppointmentSchedulingAppServices
    {
        protected readonly IAppointmentSchedulingRepository _appointmentSchedulingRepository;
        protected readonly IMapper _mapper;

        public AppointmentSchedulingAppService(IAppointmentSchedulingRepository appointmentSchedulingRepository 
            , IMapper mapper
            ,IUnitOfWork uoW
            , IMediator bus) : base(uoW, bus)
        {
            _appointmentSchedulingRepository = appointmentSchedulingRepository;
            _mapper = mapper;
        }

        public AppointmentSchedulingViewModel Add(AppointmentSchedulingViewModel viewModel)
        {
            AppointmentScheduling appointmentScheduling = _mapper.Map<AppointmentScheduling>(viewModel);
            appointmentScheduling = _appointmentSchedulingRepository.Add(appointmentScheduling);
            Commit();
            AppointmentSchedulingViewModel appointmentSchedulingViewModel = _mapper.Map<AppointmentSchedulingViewModel>(viewModel);
            return appointmentSchedulingViewModel;
        }

        public AppointmentSchedulingViewModel GetById(Guid id)
        {
            AppointmentScheduling appointmentScheduling = _appointmentSchedulingRepository.GetById(id);
            AppointmentSchedulingViewModel appointmentSchedulingViewModel = _mapper.Map<AppointmentSchedulingViewModel>(appointmentScheduling);
            return appointmentSchedulingViewModel;
        }

        public void Remove(Guid id)
        {
            _appointmentSchedulingRepository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<AppointmentScheduling, bool>> expression)
        {
            _appointmentSchedulingRepository.Remove(expression);
            Commit();
        }

        public IEnumerable<AppointmentSchedulingViewModel> Search(Expression<Func<AppointmentScheduling, bool>> expression)
        {
            var appointmentScheduling = _appointmentSchedulingRepository.Search(expression);
            var appointmentSchedulingViewModel = _mapper.Map<IEnumerable<AppointmentSchedulingViewModel>>(appointmentScheduling);
            return appointmentSchedulingViewModel;
        }

        public IEnumerable<AppointmentSchedulingViewModel> Search(Expression<Func<AppointmentScheduling, bool>> expression, int pageNumber, int pageSize)
        {
            var appointmentScheduling = _appointmentSchedulingRepository.Search(expression, pageNumber, pageSize);
            var appointmentSchedulingViewModel = _mapper.Map<IEnumerable<AppointmentSchedulingViewModel>>(appointmentScheduling);
            return appointmentSchedulingViewModel;
        }

        public AppointmentSchedulingViewModel Update(AppointmentSchedulingViewModel viewModel)
        {
            var appointmentScheduling = _mapper.Map<AppointmentScheduling>(viewModel);
            appointmentScheduling = _appointmentSchedulingRepository.Update(appointmentScheduling);
            Commit();
            var appointmentSchedulingViewModel = _mapper.Map<AppointmentSchedulingViewModel>(appointmentScheduling);
            return appointmentSchedulingViewModel;
        }
    }
}
