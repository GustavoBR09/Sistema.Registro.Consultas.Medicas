using SRCM.Domain.Shared.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRCM.Domain.Shared.ViewModel
{
    public class AppointmentViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Doutor é Obrigatório")]
        [DisplayName("Id Doutor")]
        public Guid IdDoctor { get; set; }
        [Required(ErrorMessage = "O Paciente é Obrigatório")]
        [DisplayName("Id Paciente")]
        public Guid IdPatient { get; set; }
        [Required(ErrorMessage = "O Tipo de Consulta é Obrigatório")]
        [DisplayName("Tipo")]
        public int Type { get; set; }
        [MaxLength(250, ErrorMessage = "A Observação Deve Ter No Máximo 250 Caracteres")]
        [DisplayName("Observação")]
        public string Observation { get; set; }
        [DisplayName("Doutor")]
        public DoctorViewModel Doctor { get; set; }
        [DisplayName("Paciente")]
        public PatientViewModel Patient { get; set; }
    }
}
