using CqrsMediatrProject.Models;
using CqrsMediatrProject.Queries;
using CqrsMediatrProject.Service;
using MediatR;

namespace CqrsMediatrProject.Handlers
{
    public class GetCustomerCpfHandler : IRequestHandler<GetCustomerCpfQuerys, Customer>
    {
        private readonly CustomerService _customerService;
        public GetCustomerCpfHandler(CustomerService customerService) 
            => _customerService = customerService;

        public async Task<Customer> Handle(GetCustomerCpfQuerys request, CancellationToken cancellationToken)
            => await _customerService.GetByCpf(request.cpf);
      
    }
}
