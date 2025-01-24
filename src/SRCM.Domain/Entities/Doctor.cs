using SRCM.Core.DomainObjects;
using SRCM.Domain.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SRCM.Domain.Entities
{
    public class Doctor : Entity
    {
        public Doctor(string name, string cpf, string crm, string email, DateTime birthday, Specialties specialty, Guid addressId)
        {
            Name = name;
            Cpf = cpf;
            Crm = crm;
            Email = email;

            Birthday = birthday;
            Specialty = specialty;
            AddressId = addressId;

        }

        public void SetAddress(Address address) { 
            Address = address;
        }
        protected Doctor() { }

        public string Name { get; private set; }
        public string Cpf { get; private set; }
        public string Crm { get; private set; }
        public string Email { get; private set; }
        public Guid AddressId { get; private set; }
        public DateTime Birthday { get; private set; }
        public Specialties Specialty { get; private set; }

        public Address Address { get; private set; }
    }
}
