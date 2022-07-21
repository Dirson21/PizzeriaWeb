using Microsoft.EntityFrameworkCore;
using PizzeriaWeb.Infrastructure.Data;
using PizzeriaWeb.Services;
using PizzeriaWeb.Infrastructure.Data.Model;
using PizzeriaWeb.Infrastructure.UoW;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<PizzeriaDbContext>(c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        c.UseSqlServer(connectionString);
    }
    catch(Exception)
    {

    }
    
});
/*builder.Services.AddDbContext<ProductContext>(c =>
{
    try
    {
        string connectionString = builder.Configuration.GetValue<string>("DefaultConnection");
        c.UseSqlServer(connectionString);
    }
    catch (Exception)
    {

    }
});
*/
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerAccountRepository, CustomerAccountRepository>();
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();



/*builder.Services.AddScoped<ICustomerAccountRepository>(s
    => new CustomerAccountRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<ICustomerAccountService, CustomerAccountService>();*/


/*
builder.Services.AddScoped<IProductRepository>(s
    => new ProductRepository(builder.Configuration.GetValue<string>("DefaultConnection")));
builder.Services.AddScoped<IProductService, ProducService>();*/
    

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();


