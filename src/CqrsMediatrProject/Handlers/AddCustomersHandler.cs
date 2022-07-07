using CqrsMediatrProject.Commands;
using CqrsMediatrProject.Models;
using CqrsMediatrProject.Service;
using MediatR;

namespace CqrsMediatrProject.Handlers
{
    public class AddCustomersHandler : IRequestHandler<AddCustomersCommand, Customer>
    {
        private readonly CustomerService _customerService;
        public AddCustomersHandler(CustomerService customerService) 
            => _customerService = customerService;

        public async Task<Customer> Handle(AddCustomersCommand request, CancellationToken cancellationToken)
        {
            await _customerService.AddCustomer(request.Customer);

            return request.Customer;
        }
    }
}
