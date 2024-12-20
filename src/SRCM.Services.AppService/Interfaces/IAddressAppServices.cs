using SRCM.Domain.Entities;
using SRCM.Domain.Shared.ViewModel;
using System.Linq.Expressions;

namespace SRCM.Services.AppService.Interfaces
{
    public interface IAddressAppServices
    {
        AddressViewModel GetById(Guid id);
        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression);
        IEnumerable<AddressViewModel> Search(Expression<Func<Address, bool>> expression, int pageNumber, int pageSize);
        AddressViewModel Add(AddressViewModel viewModel);
        AddressViewModel Update(AddressViewModel viewModel);
        void Remove(Guid id);
        void Remove(Expression<Func<Address, bool>> expression);
    }
}
