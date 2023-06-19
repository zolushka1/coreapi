using Microsoft.EntityFrameworkCore;
using coreapi.DbConfig;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

ServicePointManager.Expect100Continue = true;
ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;


// Register the MSSQLDbContext service
builder.Services.AddDbContext<MSSQLDbContext>(options =>
    options.UseSqlServer("Data Source=192.82.95.103,1456;Initial Catalog=WebPos;User ID=sa;Password=0nTime@123;Encrypt=False"));

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

MigrateDatabase(app.Services);

app.Run();

static void MigrateDatabase(IServiceProvider serviceProvider)
{
    using (var scope = serviceProvider.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<MSSQLDbContext>();
        dbContext.Database.Migrate();
    }
}
