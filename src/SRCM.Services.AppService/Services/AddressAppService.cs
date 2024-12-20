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
    public class AddressAppService : BaseService, IAddressAppServices
    {
        protected readonly IAddressRepository _addressRepositoy;
        protected readonly IMapper _mapper;

        public AddressAppService(IAddressRepository addressRepositoy,
            IMapper mapper, 
            IUnitOfWork unitOfWork,
            IMediator bus) : base(unitOfWork, bus)
        {
            _addressRepositoy = addressRepositoy;
            _mapper = mapper;
        }

        public AddressViewModel Add(AddressViewModel viewModel)
        {
            Address address = _mapper.Map<Address>(viewModel);
            address = _addressRepositoy.Add(address);
            Commit();
            AddressViewModel addressViewModel = _mapper.Map<AddressViewModel>(address);
            return addressViewModel;
        }

        public AddressViewModel GetById(Guid id)
        {
            Address address = _addressRepositoy.GetById(id);
            AddressViewModel addressViewModel = _mapper.Map<AddressViewModel>(address);
            return addressViewModel;

        }

        public void Remove(Guid id)
        {
            _addressRepositoy.Remove(id);
            Commit();
        }

        public void Remove(Expression<Func<Address, bool>> expression)
        {
            _addressRepositoy.Remove(expression);
            Commit();
        }

        public IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression)
        {
            var addresses = _addressRepositoy.Search(expression);
            var addressesViewModel = _mapper.Map<IEnumerable<AddressViewModel>>(addresses);
            return addressesViewModel;
        }

        public IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression, int pageNumber, int pageSize)
        {
            var addresses = _addressRepositoy.Search(expression, pageNumber, pageSize);
            var addressesViewModel = _mapper.Map<IEnumerable<AddressViewModel>>(addresses);
            return addressesViewModel;
        }

        public AddressViewModel Update(AddressViewModel viewModel)
        {
            var address = _mapper.Map<Address>(viewModel);
            address = _addressRepositoy.Update(address);
            Commit();
            var addressViewModel = _mapper.Map<AddressViewModel>(address);
            return addressViewModel;
        }
    }
}
