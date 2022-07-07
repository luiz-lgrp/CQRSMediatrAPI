using CqrsMediatrProject.Models;
using MediatR;

namespace CqrsMediatrProject.Commands
{
    public record AddCustomersCommand(Customer Customer) : IRequest<Customer>;
}
