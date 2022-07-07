using CqrsMediatrProject.Models;
using FluentValidation;

namespace CqrsMediatrProject.Validations
{
    public class AddCustomerValidator : AbstractValidator<Customer>
    {
        public AddCustomerValidator()
        {
            //Regras do Nome
            RuleFor(m => m.Name)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor, digite o seu nome")
                .MaximumLength(30)
                    .WithMessage("O campo nome não pode passar de 30 caracteres")
                .MinimumLength(2)
                    .WithMessage("O campo nome não pode ser menor que 02 caracteres");


            //Regras do Cpf 
            RuleFor(m => m.Cpf)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor, digite o seu Cpf")
                .MaximumLength(11)
                    .WithMessage("O campo Cpf não pode passar de 11 caracteres")
                .Matches("[0-9]{11}")
                    .WithMessage("Cpf inválido com pontos,traços ou letras");

            //Regras do Email
            RuleFor(m => m.Email)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor digite o seu e-mail")

                .EmailAddress()
                    .WithMessage("Formato de e-mail inválido");

            //Regras do Phone
            RuleFor(m => m.Phone)
                .NotEmpty().NotNull()
                    .WithMessage("Por favor digite um telefone")
                .Matches("^([1-9]{2})-(?:[2-8]|9[1-9])[0-9]{3}-[0-9]{4}$")
                    .WithMessage("Formato de telefone inválido xx-xxxxx-xxxx")
                .MaximumLength(14)
                    .WithMessage("telefone não pode ter mais de 11 dígitos contando com DDD");
        }
    }
}
