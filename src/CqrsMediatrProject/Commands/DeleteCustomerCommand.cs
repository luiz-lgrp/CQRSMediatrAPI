using MediatR;

namespace CqrsMediatrProject.Commands
{
    public record DeleteCustomerCommand(string cpf) : IRequest;

}
