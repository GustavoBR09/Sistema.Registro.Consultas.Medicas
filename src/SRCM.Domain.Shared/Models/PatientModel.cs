using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Domain.Shared.Models
{
    public class PatientModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
