using CqrsMediatrProject.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace CqrsMediatrProject.Service
{
    public class CustomerService
    {
        private readonly IMongoCollection<Customer> _customerCollection;


        //Configurações do meu BD
        public CustomerService(IOptions<CustomerDatabaseSettings> customerService)
        {
            var mongoClient = new MongoClient(customerService.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(customerService.Value.DatabaseName);

            
            _customerCollection = mongoDatabase.GetCollection<Customer>
                (customerService.Value.CustomerCollectionName);
        }

        //Metodos de serviço para se usar na API

        
        public async Task<List<Customer>> GetAllCustomers() =>
            await _customerCollection.Find(x => true).ToListAsync();

        
        public async Task<Customer> GetByCpf(string cpf) =>
            await _customerCollection.Find(x => x.Cpf == cpf).FirstOrDefaultAsync();

        
        public async Task AddCustomer(Customer newCustomer)
        {
            
            var dbCustomer = await _customerCollection
                .Find(f => f.Cpf == newCustomer.Cpf || f.Email == newCustomer.Email)
                .FirstOrDefaultAsync();

            if (dbCustomer != null)
                throw new Exception("Já possui um cliente com este cpf ou e-mail");

            await _customerCollection.InsertOneAsync(newCustomer);

        }

        
        public async Task UpdateCustomer(string cpf, Customer updateCustomer) =>
            await _customerCollection.ReplaceOneAsync(x => x.Cpf == cpf, updateCustomer);

        
        public async Task DeleteCustomer(string cpf) =>
            await _customerCollection.DeleteOneAsync(x => x.Cpf == cpf);
    }
}
