﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SRCM.Domain.Shared.ViewModel
{
    public class PatientViewModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "O Nome É Obrigatório")]
        [MaxLength(250, ErrorMessage = "O Nome Deve Ter No Máximo 250 Caracteres")]
        [DisplayName("Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O Aniversário É Obrigatório")]
        [DisplayName("Aniversário")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "O CPF É Obrigatório")]
        [MaxLength(11, ErrorMessage = "O CPF Deve Ter No Máximo 11 Caracteres")]
        [DisplayName("CPF")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O Email É Obrigatório")]
        [MaxLength(100, ErrorMessage = "O Email Deve Ter No Máximo 100 Caracteres")]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Endereço É Obrigatório")]
        [DisplayName("Id Endereço")]
        public Guid AddressId { get; set; }
        [DisplayName("Endereço")]

        public AddressViewModel? Address { get; set; }
    }
}