using customerDemoWebApiPart2_withEntityFramework.Data;
using Microsoft.EntityFrameworkCore;
using customerDemoWebApiPart2_withEntityFramework.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICustomerService, CustomerService>();
//we are using using ICustomerService service and which calls CustomerService

builder.Services.AddDbContext<CustomerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CustomerConnectionString")));


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
