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
    public class StaffAppService : BaseService, IStaffAppServices
    {
        protected readonly IStaffRepository _staffRepository;
        protected readonly IMapper _mapper;

        public StaffAppService(IStaffRepository staffRepository, IMapper mapper, IUnitOfWork uoW, IMediator bus) : base(uoW, bus)
        {
            _staffRepository = staffRepository;
            _mapper = mapper;
        }

        public StaffViewModel Add(StaffViewModel viewModel)
        {
            Staff staff = _mapper.Map<Staff>(viewModel);
            staff = _staffRepository.Add(staff);
            Commit();
            StaffViewModel staffViewModel = _mapper.Map<StaffViewModel>(staff);
            return staffViewModel;
        }

        public StaffViewModel GetById(Guid id)
        {
            Staff staff = _staffRepository.GetById(id);
            StaffViewModel staffViewModel = _mapper.Map<StaffViewModel>(staff);
            return staffViewModel;
        }

        public void Remove(Guid id)
        {
            _staffRepository.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<Staff, bool>> expression)
        {
            _staffRepository.Remove(expression);
            Commit();
        }

        public IEnumerable<StaffViewModel> Search(Expression<Func<Staff, bool>> expression)
        {
            var staff = _staffRepository.Search(expression);
            var staffViewModel = _mapper.Map<IEnumerable<StaffViewModel>>(staff);
            return staffViewModel;
        }

        public IEnumerable<StaffViewModel> Search(Expression<Func<Staff, bool>> expression, int pageNumber, int pageSize)
        {
            var staffs = _staffRepository.Search(expression, pageNumber, pageSize);
            var staffsViewModel = _mapper.Map<IEnumerable<StaffViewModel>>(staffs);
            return staffsViewModel;
        }

        public StaffViewModel Update(StaffViewModel viewModel)
        {
            var staff = _mapper.Map<Staff>(viewModel);
            staff = _staffRepository.Update(staff);
            Commit();
            var staffViewModel = _mapper.Map<StaffViewModel>(staff);
            return staffViewModel;
        }
    }
}
