using AutoMapper;
using MediatR;
using SRCM.Domain.Entities;
using SRCM.Domain.Interfaces;
using SRCM.Domain.Shared.Transaction;
using SRCM.Services.AppService.Interfaces;
using SRCM.Domain.Shared.ViewModel;
using System.Linq.Expressions;

namespace SRCM.Services.AppService.Services
{
    public class DoctorAppService : BaseService, IDoctorAppServices
    {
        protected readonly IDoctorRepository _doctorRepository;
        protected readonly IMapper _mapper;

        public DoctorAppService(IDoctorRepository doctorRepository,
            IMapper mapper,
            IUnitOfWork unitofWork,
            IMediator bus) : base(unitofWork, bus)
        {
            _doctorRepository = doctorRepository;
            _mapper = mapper;
        }

        public DoctorViewModel Add(DoctorViewModel viewModel)
        {
            Doctor doctor = _mapper.Map<Doctor>(viewModel);
            doctor = _doctorRepository.Add(doctor);
            Commit();
            DoctorViewModel doctorViewModel = _mapper.Map<DoctorViewModel>(doctor);
            return doctorViewModel;
        }

        public DoctorViewModel GetById(Guid id)
        {
            Doctor doctor = _doctorRepository.GetById(id);
            DoctorViewModel doctorViewModel = _mapper.Map<DoctorViewModel>(doctor);
            return doctorViewModel;
        }

        public void Remove(Guid id)
        {
            _doctorRepository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<Doctor, bool>> expression)
        {
            _doctorRepository.Remove(expression);
            Commit();
        }

        public IEnumerable<DoctorViewModel> Search(Expression<Func<Doctor, bool>> expression)
        {
            var doctor = _doctorRepository.Search(expression);
            var doctorViewModel = _mapper.Map<IEnumerable<DoctorViewModel>>(expression);
            return doctorViewModel;
        }

        public IEnumerable<DoctorViewModel> Search(Expression<Func<Doctor, bool>> expression, int pageNumber, int pageSize)
        {
            var doctor = _doctorRepository.Search(expression, pageNumber, pageSize);
            var doctorViewModel = _mapper.Map<IEnumerable<DoctorViewModel>>(doctor);
            return doctorViewModel;
        }

        public DoctorViewModel Update(DoctorViewModel viewModel)
        {
            var doctor = _mapper.Map<Doctor>(viewModel);
            doctor = _doctorRepository.Update(doctor);
            Commit();
            var doctorViewModel = _mapper.Map<DoctorViewModel>(doctor);
            return doctorViewModel;
        }
    }
}
