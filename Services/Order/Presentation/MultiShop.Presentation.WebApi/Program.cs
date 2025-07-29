using MultiShop.Core.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Core.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Core.Application.Interfaces;
using MultiShop.Infrastructure.Persistence.Repository;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using MultiShop.Infrastructure.Persistence.Context;
using System.Reflection.Metadata;
using MediatR;
using MultiShop.Core.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//builder.Services.AddScoped(typeof(IOrderingRepository), typeof(OrderingRepository));
//builder.Services.AddApplicationService(builder.Configuration);

builder.Services.AddDbContext<OrderContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly));



#region
builder.Services.AddScoped<GetAddressQueryHandler>();
builder.Services.AddScoped<GetAddressByIdQueryHandler>();
builder.Services.AddScoped<CreateAddressCommandHandler>();
builder.Services.AddScoped<UpdateAddressCommandHandler>();
builder.Services.AddScoped<RemoveAddressCommandHandler>();

builder.Services.AddScoped<GetOrderDetailQueryHandler>();
builder.Services.AddScoped<GetByIdOrderDetailQueryHandler>();
builder.Services.AddScoped<CreateOrderDetailCommandHandler>();
builder.Services.AddScoped<UpdateOrderDetailCommandHandler>();
builder.Services.AddScoped<RemoveOrderDetailCommandHandler>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
