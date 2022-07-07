using CqrsMediatrProject.Commands;
using CqrsMediatrProject.Models;
using CqrsMediatrProject.Service;
using MediatR;

namespace CqrsMediatrProject.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly CustomerService _customerService;
        public UpdateCustomerHandler(CustomerService customerService) => _customerService = customerService;

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _customerService.UpdateCustomer(request.cpf, request.updateCustomer);

            return request.updateCustomer;

        }
    }
}
