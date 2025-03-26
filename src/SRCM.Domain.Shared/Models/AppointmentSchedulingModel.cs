using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Domain.Shared.Models
{
    public class AppointmentSchedulingModel
    {
        public Guid AppointmentId { get; set; }
        public Guid SchedulingId { get; set; }
        public DateTime DateScheduling { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string Type { get; set; }
    }
}
