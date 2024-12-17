using OrderManagementSystem.Application.Repositories;
using OrderManagementSystem.Application.UseCases.OrderUseCase;
using OrderManagementSystem.Infrastructure;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Application.UseCases.ProductsUseCase;
using OrderManagementSystem.Application.UseCases.ProductUseCase;
using OrderManagementSystem.API.Filters;


namespace OrderManagementSystem.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IClientRepository, ClientRepository>();

            //Pedidos
            builder.Services.AddScoped<GetOrderUseCase>();
            builder.Services.AddScoped<CreateOrderUseCase>();
            builder.Services.AddScoped<GetOrdersUseCase>();
            builder.Services.AddScoped<UpdateOrderStatusUseCase>();
            //Productos
            builder.Services.AddScoped<GetProductsUseCase>();
            builder.Services.AddScoped<GetProductUseCase>();


            var connectionString = builder.Configuration.GetConnectionString("Database");


            builder.Services.AddControllersWithViews().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
            });

            builder.Services.AddDbContext<OrderManagementSystemContext>(option => option.UseSqlServer(connectionString, options =>
            {
                options.CommandTimeout(120); // Define o tempo limite para 120 segundos (2 minutos)
            }));

            builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRouting(options => options.LowercaseUrls = true);


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
