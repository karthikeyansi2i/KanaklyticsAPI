using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy =>
        {
            policy
                .WithOrigins("http://localhost:8080", "https://kanaklytics-ui.vercel.app") // your UI origins http://localhost:8080/
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials(); // if sending cookies/auth headers
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Kanaklytics.API.Data.KanaklyticsDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Register repositories
        builder.Services.AddScoped<Kanaklytics.API.Repositories.IProductRepository, Kanaklytics.API.Repositories.ProductRepository>();
        builder.Services.AddScoped<Kanaklytics.API.Repositories.IInventoryRepository, Kanaklytics.API.Repositories.InventoryRepository>();
        builder.Services.AddScoped<Kanaklytics.API.Repositories.IWarehouseRepository, Kanaklytics.API.Repositories.WarehouseRepository>();
        builder.Services.AddScoped<Kanaklytics.API.Repositories.IPurchaseOrderRepository, Kanaklytics.API.Repositories.PurchaseOrderRepository>();
        builder.Services.AddScoped<Kanaklytics.API.Repositories.IStockAlertRepository, Kanaklytics.API.Repositories.StockAlertRepository>();
        builder.Services.AddScoped<Kanaklytics.API.Repositories.IUserRepository, Kanaklytics.API.Repositories.UserRepository>();

        // Register services
        builder.Services.AddScoped<Kanaklytics.API.Services.IProductService, Kanaklytics.API.Services.ProductService>();
        builder.Services.AddScoped<Kanaklytics.API.Services.IInventoryService, Kanaklytics.API.Services.InventoryService>();
        builder.Services.AddScoped<Kanaklytics.API.Services.IWarehouseService, Kanaklytics.API.Services.WarehouseService>();
        builder.Services.AddScoped<Kanaklytics.API.Services.IPurchaseOrderService, Kanaklytics.API.Services.PurchaseOrderService>();
        builder.Services.AddScoped<Kanaklytics.API.Services.IStockAlertService, Kanaklytics.API.Services.StockAlertService>();
        builder.Services.AddScoped<Kanaklytics.API.Services.IReportService, Kanaklytics.API.Services.ReportService>();
        builder.Services.AddScoped<Kanaklytics.API.Services.IUserService, Kanaklytics.API.Services.UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


    if (!app.Environment.IsDevelopment())
    {
        app.UseHttpsRedirection();
    }
        app.UseCors("AllowFrontend");
        app.UseAuthorization();
        app.MapControllers();

app.Run();

