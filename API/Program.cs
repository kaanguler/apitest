using API.Core.Interface;
using API.Extentions;
using API.Helpers;
using API.Infrastructure.DataContext;
using API.Infrastructure.Implements;
using API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<IProductRepository, ProductRepository>();
//builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));

builder.Services.AddApplicationServices();
builder.Services.AddSwaggerDocumentation();
builder.Services.AddAutoMapper(typeof(MappingProfiles));


builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("DefaultConnection")));




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwaggerDocumenatation();


app.UseMiddleware<ExceptionMiddleware>();
app.UseStatusCodePagesWithReExecute("/error/{0}");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
