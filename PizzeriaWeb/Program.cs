using PizzeriaWeb.Services;
using SQLHomeWork.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddScoped<ICustomerAccountRepository>(s
    => new CustomerAccountRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountService>();

builder.Services.AddScoped<IProductRepository>(s
    => new ProductRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IProductService, ProducService>();
    

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
