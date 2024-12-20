using SRCM.Domain.Shared.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRCM.Domain.Shared.ViewModel
{
    public class AppointmentSchedulingViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A Data é Obrigatória")]
        [DisplayName("Data")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "A Consulta é Obrigatória")]
        [DisplayName("Id Consulta")]
        public Guid IdAppointment { get; set; }
        [EnumDataType(typeof(AppointmentStatus), ErrorMessage =  "Este Status É Inválido")]
        [DisplayName("Status")]
        public AppointmentStatus Status { get; set; }
        [DisplayName("Consulta")]
        public AppointmentViewModel Appointment { get; set; }
    }
}
