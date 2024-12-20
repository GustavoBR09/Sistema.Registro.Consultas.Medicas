using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRCM.Domain.Shared.ViewModel
{
    public class AddressViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A Rua é Obrigatória")]
        [MaxLength(100, ErrorMessage = "A Rua Deve Ter No Máximo 100 Caracteres")]
        [DisplayName("Rua")]
        public string Street { get; set; }
        [MaxLength(5, ErrorMessage = "A Observação Deve Ter No Máximo 5 Caracteres")]
        [DisplayName("Número")]

        public string Number { get; set; }
        [Required(ErrorMessage = "A Cidade é Obrigatória")]
        [MaxLength(25, ErrorMessage = "A Cidadeo Deve Ter No Máximo 25 Caracteres")]
        [DisplayName("Cidade")]
        public string City { get; set; }
        [Required(ErrorMessage = "O Estado é Obrigatório")]
        [MaxLength(2, ErrorMessage = "O Estado Deve Ter No Máximo 2 Caracteres")]
        [DisplayName("Estado")]
        public string State { get; set; }
        [MaxLength(9, ErrorMessage = "O Código Postal Deve Ter No Máximo 9 Caracteres")]
        [DisplayName("Código Postal")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "O Bairro é Obrigatório")]
        [MaxLength(50, ErrorMessage = "O Bairro Deve Ter No Máximo 50 Caracteres")]
        [DisplayName("Bairro")]
        public string Neighborhood { get; set; }
        [MaxLength(150, ErrorMessage = "O Complemento Deve Ter No Máximo 150 Caracteres")]
        [DisplayName("Complemento")]
        public string Complement {  get; set; }
    }
}
