using SRCM.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Domain.Shared.Models
{
    public class StaffModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string CarteiraTrabalho { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
    }
}
