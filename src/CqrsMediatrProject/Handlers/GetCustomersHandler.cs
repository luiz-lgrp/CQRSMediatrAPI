using CqrsMediatrProject.Models;
using CqrsMediatrProject.Queries;
using CqrsMediatrProject.Service;
using MediatR;

namespace CqrsMediatrProject.Handlers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IEnumerable<Customer>>
    {
        private readonly CustomerService _customerService;
        public  GetCustomersHandler(CustomerService customerService) => _customerService = customerService;

        public async Task<IEnumerable<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            => await _customerService.GetAllCustomers();
       
    }
}
