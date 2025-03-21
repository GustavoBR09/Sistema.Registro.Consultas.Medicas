using SRCM.Domain.Shared.ViewModel;
using Refit;
using SRCM.Domain.Shared;
using SRCM.Domain.Shared.Models;

namespace SRCM.Desktop.Interfaces
{
    public interface IAPIService
    {
        #region Address
        [Get("/api/address")]
        Task<IEnumerable<AddressViewModel>> GetAddresses();

        [Get("/api/address/{id}")]
        Task<IEnumerable<AddressViewModel>> GetAddresseById(Guid id);

        [Post("/api/address")]
        Task<AddressViewModel> AddAddress([Body] AddressViewModel address);

        [Put("/api/address")]
        Task<AddressViewModel> UpdateAdress([Body] AddressViewModel address);

        [Delete("/api/address/{id}")]
        Task DeleteAddress(Guid id);
        #endregion

        #region Appointment
        [Get("/api/appointment")]
        Task<IEnumerable<AppointmentViewModel>> GetAppointments();

        [Get("/api/appointment/{id}")]
        Task<IEnumerable<AppointmentViewModel>> GetAppointmentById(Guid id);

        [Post("/api/appointment")]
        Task<AppointmentViewModel> AddAppointment([Body] AppointmentViewModel appointment);

        [Put("/api/appointment")]
        Task<AppointmentViewModel> UpdateAppointment([Body] AppointmentViewModel appointment);

        [Delete("/api/appointment/{id}")]
        Task DeleteAppointment(Guid id);
        #endregion

        #region AppointmentScheduling
        [Get("/api/appointment-scheduling")]
        Task<IEnumerable<AppointmentSchedulingViewModel>> GetAppointmentScheduling();

        [Get("/api/appointment-scheduling/{id}")]
        Task<IEnumerable<AppointmentSchedulingViewModel>> GetAppointmentSchedulingById(Guid id);

        [Post("/api/appointment-scheduling")]
        Task<AppointmentSchedulingViewModel> AddAppointmentScheduling([Body] AppointmentSchedulingViewModel appointmentScheduling);

        [Put("/api/appointment-scheduling")]
        Task<AppointmentSchedulingViewModel> UpdateAppointmentScheduling([Body] AppointmentSchedulingViewModel appointmentScheduling);

        [Delete("/api/appointment-scheduling/{id}")]
        Task DeleteAppointmentScheduling(Guid id);
        #endregion

        #region Doctor
        [Get("/api/doctor")]
        Task<IEnumerable<DoctorModel>> GetDoctors();

        [Get("/api/doctor/{id}")]
        Task<DoctorViewModel> GetDoctorById(Guid id);

        [Get("/api/doctor/search/{filter}")]
        Task<IEnumerable<DoctorModel>> GetDoctorUsingFilter(string filter);

        [Post("/api/doctor")]
        Task<DoctorViewModel> AddDoctor([Body] DoctorViewModel doctor);

        [Put("/api/doctor")]
        Task<DoctorViewModel> UpdateDoctor([Body] DoctorViewModel doctor);

        [Delete("/api/doctor/{id}")]
        Task DeleteDoctor(Guid id);
        #endregion

        #region Patient
        [Get("/api/patient")]
        Task<IEnumerable<PatientModel>> GetPatients();

        [Get("/api/patient/{id}")]
        Task<PatientViewModel> GetPatientById(Guid id);

        [Get("/api/patient/search/{filter}")]
        Task<IEnumerable<PatientModel>> GetPatientUsingFilter(string filter);

        [Post("/api/patient")]
        Task<PatientViewModel> AddPatient([Body] PatientViewModel patient);

        [Put("/api/patient")]
        Task<PatientViewModel> UpdatePatient([Body] PatientViewModel patient);

        [Delete("/api/patient/{id}")]
        Task DeletePatient(Guid id);
        #endregion

        #region Staff
        [Get("/api/staff")]
        Task<IEnumerable<StaffModel>> GetStaffs();

        [Get("/api/staff/{id}")]
        Task<StaffViewModel> GetStaffById(Guid id);

        [Get("/api/staff/search/{filter}")]
        Task<IEnumerable<StaffModel>> GetStaffUsingFilter(string filter);

        [Post("/api/staff")]
        Task<StaffViewModel> AddStaff([Body] StaffViewModel staff);

        [Put("/api/staff")]
        Task<StaffViewModel> UpdateStaff([Body] StaffViewModel staff);

        [Delete("/api/staff/{id}")]
        Task DeleteStaff(Guid id);
        #endregion
    }
}
