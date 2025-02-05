using AutoMapper;
using SRCM.Domain.Entities;
using SRCM.Domain.Shared;
using SRCM.Domain.Shared.Models;
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

            CreateMap<Doctor, DoctorModel>()
                .ForMember(x => x.Address, m => m.MapFrom(a => a.Address != null ?
                $"{a.Address.Street}, {a.Address.Complement}, " +
                $"{a.Address.Number}, {a.Address.Neighborhood}, {a.Address.City}, {a.Address.State}"
                : ""))
                .ForMember(x => x.Specialty, m => m.MapFrom(a => a.Specialty.ToString()))
                .ForMember(x => x.Birthday, m => m.MapFrom(a => a.Birthday.ToString("dd/MM/yyyy")));

            CreateMap<Staff, StaffModel>()
                .ForMember(x => x.Address, m => m.MapFrom(a => a.Address != null ?
                $"{a.Address.Street}, {a.Address.Complement}, " +
                $"{a.Address.Number}, {a.Address.Neighborhood}, {a.Address.City}, {a.Address.State}"
                : ""))
                .ForMember(x => x.Position, m => m.MapFrom(a => a.Position.ToString()))
                .ForMember(x => x.Birthday, m => m.MapFrom(a => a.Birthday.ToString("dd/MM/yyyy")));

            CreateMap<Patient, PatientModel>()
                .ForMember(x => x.Address, m => m.MapFrom(a => a.Address != null ?
                $"{a.Address.Street}, {a.Address.Complement}, " +
                $"{a.Address.Number}, {a.Address.Neighborhood}, {a.Address.City}, {a.Address.State}"
                : ""))
                .ForMember(x => x.Birthday, m => m.MapFrom(a => a.Birthday.ToString("dd/MM/yyyy")));
        }
    }
}
