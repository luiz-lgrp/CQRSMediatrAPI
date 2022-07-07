using CqrsMediatrProject.Models;
using MediatR;

namespace CqrsMediatrProject.Queries
{
    public record GetCustomersQuery : IRequest<IEnumerable<Customer>>;
    
    
}
