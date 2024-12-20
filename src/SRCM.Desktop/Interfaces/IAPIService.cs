using SRCM.Domain.Shared.ViewModel;
using Refit;

namespace SRCM.Desktop.Interfaces
{
    public interface IAPIService
    {
        #region Address
        [Get("/api/address")]
        Task<IEnumerable<AddressViewModel>> GetAddresses();

        [Get("/api/address/{id}")]
        Task<IEnumerable<AddressViewModel>> GetAddresseById(Guid Id);

        [Post("/api/address")]
        Task<AddressViewModel> AddAddress([Body] AddressViewModel Address);

        [Put("/api/address")]
        Task<AddressViewModel> UpdateAdress([Body] AddressViewModel Address);

        [Delete("/api/address/{id}")]
        Task DeleteAddress(Guid AddressId);
        #endregion

        #region Appointment

        #endregion
    }
}
