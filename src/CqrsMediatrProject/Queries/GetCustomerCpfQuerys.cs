using CqrsMediatrProject.Models;
using MediatR;

namespace CqrsMediatrProject.Queries
{
    public record GetCustomerCpfQuerys(string cpf) : IRequest<Customer>;
}
