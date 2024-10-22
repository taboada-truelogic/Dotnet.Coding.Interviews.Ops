// Dotnet.Coding.Interviews.Ops.Api/Program.cs

using Dotnet.Coding.Interviews.Ops.Data;
using Dotnet.Coding.Interviews.Ops.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();

builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();

builder.Services.AddDbContext<OpsDbContext>(options =>
    options.UseSqlite("DataSource=:memory:")); // Using in-memory SQLite for simplicity

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Order Processing System (OPS) API", Version = "v1" });
});

var app = builder.Build();

// Initialize the database with some sample data
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<OpsDbContext>();
    dbContext.Database.EnsureCreated();

    // Here, you can seed some initial data if needed
    // e.g., dbContext.Orders.Add(new Order { ... });
    // dbContext.SaveChanges();
}

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger(); // Enable Swagger UI in development
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Order Processing API V1");
        c.RoutePrefix = string.Empty; // Serve Swagger UI at the app's root
    });
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseRouting();
app.MapControllers();

app.Run();
