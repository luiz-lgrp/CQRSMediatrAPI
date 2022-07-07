using CqrsMediatrProject.Commands;
using CqrsMediatrProject.Models;
using CqrsMediatrProject.Service;
using MediatR;

namespace CqrsMediatrProject.Handlers
{
    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly CustomerService _customerService;
        public DeleteCustomerHandler(CustomerService customerService)
            => _customerService = customerService;

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerService.DeleteCustomer(request.cpf);
            return Unit.Value;
        }
         

    }
}
