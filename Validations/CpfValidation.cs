using System.ComponentModel.DataAnnotations;
using System.Linq;
using API.Models;

namespace MARKETPLACEAPI.Validations
{
    public class CpfEmUso : ValidationAttribute
    {
        // public CpfEmUso(string cpf) { }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string cpf = (string)value;

            DataContext context =
                (DataContext)validationContext.GetService(typeof(DataContext));

            Consumidor consumidor = context.Consumidores.FirstOrDefault
                (f => f.Cpf.Equals(cpf));
                
            if (consumidor == null)
            {
                //Caso de sucesso
                return ValidationResult.Success;
            }
            //Caso de erro
            return new ValidationResult("O CPF do cliebte já está em uso!");
        }
    }
}