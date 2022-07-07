using CqrsMediatrProject.Models;
using MediatR;

namespace CqrsMediatrProject.Commands
{
    public record UpdateCustomerCommand(string cpf, Customer updateCustomer) : IRequest<Customer>;

}
