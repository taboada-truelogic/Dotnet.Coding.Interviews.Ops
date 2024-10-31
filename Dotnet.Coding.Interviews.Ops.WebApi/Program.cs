using System.Reflection;
using Dotnet.Coding.Interviews.Ops.Data;
using Dotnet.Coding.Interviews.Ops.Models;
using Dotnet.Coding.Interviews.Ops.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

/* -----------------------------------------------------------------------------
 * Data
 * -------------------------------------------------------------------------- */

var sqliteConnection = new SqliteConnection("DataSource=:memory:");
sqliteConnection.Open();

builder.Services.AddDbContext<OpsDbContext>(options =>
    options.UseSqlite(sqliteConnection));

/* -----------------------------------------------------------------------------
 * Services
 * -------------------------------------------------------------------------- */

builder.Services.AddControllers();

builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Processing System (OPS) API", Version = "v1" });
    var filePath = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, filePath));
});

var app = builder.Build();

/* -----------------------------------------------------------------------------
 * Data Seeding
 * -------------------------------------------------------------------------- */

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OpsDbContext>();
    dbContext.Database.EnsureCreated();

    if (!dbContext.Inventories.Any())
    {
        dbContext.Inventories.AddRange(
            new Inventory { Id = 1, Stock = 999 },
            new Inventory { Id = 2, Stock = 1337 }
        );
        dbContext.SaveChanges();
    }
}

/* -----------------------------------------------------------------------------
 * Middlewares
 * -------------------------------------------------------------------------- */

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.MapControllers();

await app.RunAsync();

sqliteConnection.Dispose();
