using AutoMapper;
using SRCM.Domain.Entities;
using SRCM.Domain.Shared.ViewModel;

namespace SRCM.Services.AppService.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Address, AddressViewModel>().ReverseMap();
            CreateMap<AppointmentScheduling, AppointmentSchedulingViewModel>().ReverseMap();
            CreateMap<Appointment, AppointmentViewModel>().ReverseMap();
            CreateMap<Doctor, DoctorViewModel>().ReverseMap();
            CreateMap<Patient, PatientViewModel>().ReverseMap();
            CreateMap<Staff, StaffViewModel>().ReverseMap();
        }
    }
}
