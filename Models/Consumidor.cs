using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MARKETPLACEAPI.Validations;

namespace API.Models
{
    public class Consumidor
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [StringLength(
            11,
            MinimumLength = 11,
            ErrorMessage = "O CPF deve conter 11 caracteres!"
        )]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório!")]
                [StringLength(
            2,
            MinimumLength = 2,
            ErrorMessage = "Idade incorreta!"
        )]
        public string Idade { get; set; }

        [EmailAddress(
            ErrorMessage = "E-mail inválido!"
        )]
        public string Email { get; set; }
    }
    
}