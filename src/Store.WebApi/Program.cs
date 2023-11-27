using Common.Services.Mediatr;
using MediatR;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
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

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
.AddOpenIdConnect(options =>
{
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.Authority = "https://localhost:5001/";
    options.ClientId = "store.api";
    options.ClientSecret = "secret";
    options.ResponseType = "code";

    // options.CallbackPath = new PathString("signin-oidc"); default

    options.SaveTokens = true;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
