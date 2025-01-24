using AutoMapper;
using MediatR;
using SRCM.Domain.Entities;
using SRCM.Domain.Interfaces;
using SRCM.Domain.Shared.Transaction;
using SRCM.Services.AppService.Interfaces;
using SRCM.Domain.Shared.ViewModel;
using System.Linq.Expressions;
using SRCM.Domain.Shared.Models;

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

        public StaffModel GetModelById(Guid id)
        {
            Staff staff = _staffRepository.GetById(id);
            StaffModel staffModel = _mapper.Map<StaffModel>(staff);
            return staffModel;
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

        public IEnumerable<StaffModel> Search(Expression<Func<Staff, bool>> expression)
        {
            var staff = _staffRepository.Search(expression);
            var staffModel = _mapper.Map<IEnumerable<StaffModel>>(staff);
            return staffModel;
        }

        public IEnumerable<StaffModel> Search(Expression<Func<Staff, bool>> expression, int pageNumber, int pageSize)
        {
            var staffs = _staffRepository.Search(expression, pageNumber, pageSize);
            var staffsModel = _mapper.Map<IEnumerable<StaffModel>>(staffs);
            return staffsModel;
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
