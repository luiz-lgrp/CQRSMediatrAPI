using CqrsMediatrProject.Commands;
using CqrsMediatrProject.Models;
using CqrsMediatrProject.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediatrProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ISender _sender;

        public CustomersController(ISender sender) => _sender = sender;


        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var customers = await _sender.Send(new GetCustomersQuery());

            return Ok(customers);
        }

        [HttpGet("{cpf}", Name = "GetByCpf")]
        public async Task<ActionResult> GetByCpf(string cpf)
        {
            var customer = await _sender.Send(new GetCustomerCpfQuerys(cpf));

            if (customer is null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCustomer([FromBody]Customer newCustomer)
        {
            var customerToReturn = await _sender.Send(new AddCustomersCommand(newCustomer));

            return CreatedAtRoute("GetByCpf", new { cpf = customerToReturn.Cpf }, customerToReturn);
        }

        [HttpPut("{cpf}")]
        public async Task<ActionResult> UpdateCustomer(string cpf, Customer updatedCustomer)
        {
            var customer = await _sender.Send(new GetCustomerCpfQuerys(cpf));

            if (customer is null)
            {
                return NotFound();
            }

            updatedCustomer.Cpf = customer.Cpf;

            await _sender.Send(new UpdateCustomerCommand(cpf, updatedCustomer));

            return NoContent();
        }

        [HttpDelete("{cpf}")]
        public async Task<ActionResult> DeleteCustomer(string cpf)
        {
            var customer = await _sender.Send(new GetCustomerCpfQuerys(cpf));

            if (customer is null)
            {
                return NotFound();
            }

            await _sender.Send(new DeleteCustomerCommand(cpf));

            return NoContent();

        }
    }
}
