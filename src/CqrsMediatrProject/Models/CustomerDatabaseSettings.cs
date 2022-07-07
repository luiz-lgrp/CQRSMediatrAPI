namespace CqrsMediatrProject.Models
{
    public class CustomerDatabaseSettings
    {
        public string ConnectionString { get; set; } = string.Empty; //string de conexão
        public string DatabaseName { get; set; } = string.Empty; //Nome do BD
        public string CustomerCollectionName { get; set; } = string.Empty; //Nome da "tabela"
    }
}
