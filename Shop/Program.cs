using DataAccessLayer;
using DataAccessLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BusinessLogicLayer.Mappings;
using BusinessLogicLayer.Services;
using System.Globalization;
using BusinessAccessLayer.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Добавление конфигурации строки подключения
builder.Services.AddDbContext<ApplicationContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<ApplicationContext>();



builder.Services.AddAutoMapper(typeof(AutoMapperCategoriesProfile));
builder.Services.AddAutoMapper(typeof(AutoMapperProductsProfile));
builder.Services.AddAutoMapper(typeof(AutoMapperOrdersProfile));
builder.Services.AddAutoMapper(typeof(AutoMapperOrderItemsProfile));
builder.Services.AddAutoMapper(typeof(AutoMapperUsersProfile));


// Регистрация репозиториев
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();


// Регистрация сервисов
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IUserService, UserService>();

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
