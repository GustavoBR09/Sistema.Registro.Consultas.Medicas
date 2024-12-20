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
    public class AppointmentAppService : BaseService, IAppointmentAppServices
    {
        protected readonly IAppointmentRepository _appointmentRepository;
        protected readonly IMapper _mapper;
        public AppointmentAppService(IAppointmentRepository appointmentRepository,
            IMapper mapper,
            IUnitOfWork uoW,
            IMediator bus) : base(uoW, bus)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public AppointmentViewModel Add(AppointmentViewModel viewModel)
        {
            Appointment appointment = _mapper.Map<Appointment>(viewModel);
            appointment = _appointmentRepository.Add(appointment);
            Commit();
            AppointmentViewModel appointmentViewModel = _mapper.Map<AppointmentViewModel>(appointment);
            return appointmentViewModel;
        }

        public AppointmentViewModel GetById(Guid id)
        {
            Appointment appointment = _appointmentRepository.GetById(id);
            AppointmentViewModel appointmentViewModel = _mapper.Map<AppointmentViewModel>(appointment);
            return appointmentViewModel;
        }

        public void Remove(Guid id)
        {
            _appointmentRepository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<Appointment, bool>> expression)
        {
            _appointmentRepository.Remove(expression);
            Commit();
        }

        public IEnumerable<AppointmentViewModel> Search(Expression<Func<Appointment, bool>> expression)
        {
            var appointment = _appointmentRepository.Search(expression);
            var appointmentViewModel = _mapper.Map<IEnumerable<AppointmentViewModel>>(appointment);
            return appointmentViewModel;
        }

        public IEnumerable<AppointmentViewModel> Search(Expression<Func<Appointment, bool>> expression, int pageNumber, int pageSize)
        {
            var appointment = _appointmentRepository.Search(expression,pageNumber, pageSize);
            var appointmentViewModel = _mapper.Map<IEnumerable<AppointmentViewModel>>(appointment);
            return appointmentViewModel;
        }

        public AppointmentViewModel Update(AppointmentViewModel viewModel)
        {
            var appointment = _mapper.Map<Appointment>(viewModel);
            appointment = _appointmentRepository.Update(appointment);
            Commit();
            var appointmentViewModel = _mapper.Map<AppointmentViewModel>(appointment);
            return appointmentViewModel;
        }
    }
}
