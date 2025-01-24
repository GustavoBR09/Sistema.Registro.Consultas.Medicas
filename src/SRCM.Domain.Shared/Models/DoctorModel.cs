namespace SRCM.Domain.Shared
{
    public class DoctorModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Crm { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public string Specialty { get; set; }
        public string Address { get; set; }
    }
}