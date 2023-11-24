using Common.Services.Mediatr;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Store.Common.Commands.Orders;
using Store.Common.Data;
using Store.Common.Data.Domain;
using Store.Common.Services.Handlers.Orders;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OrdersContext>(b => b.UseSqlServer(builder.Configuration.GetConnectionString("OrdersDb")));

builder.Services.AddScoped<IMediator, Mediator>();
builder.Services.ForScoped<GetOrders, Order[]>().AddHandler<GetOrdersHandler>();
builder.Services.ForScoped<CreateOrder, Order>().AddHandler<CreateOrderHandler>();

builder.Services.AddAuthentication().AddCookie("Store.Identity");

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    .AddAuthenticationSchemes("Store.Identity")
    .Build();
});

//builder.Services.AddAuthentication("Store.").AddIdentityServerAuthentication("Bearer", options =>
//{
//    options.ApiName = "store.api";
//    options.Authority = "https://localhost:7170";
//});

//builder.Services.AddAuthorization(options =>
//{
//    options.DefaultPolicy = new AuthorizationPolicyBuilder()
//    .RequireAuthenticatedUser()
//    .AddAuthenticationSchemes("Store.Identity", "Bearer")
//    .Build();
//});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
