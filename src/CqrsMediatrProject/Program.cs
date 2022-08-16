using CqrsMediatrProject.Models;
using CqrsMediatrProject.Service;
using CqrsMediatrProject.Validations;
using FluentValidation.AspNetCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMediatR(typeof(Program));


// configurando para pegar a string de conexão e demais dados
builder.Services.Configure<CustomerDatabaseSettings>
    (builder.Configuration.GetSection("DevNetStoreDatabase"));


builder.Services.AddSingleton<CustomerService>();



builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining
       <AddCustomerValidator>());


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
