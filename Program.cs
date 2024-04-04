using Microsoft.EntityFrameworkCore;
using MVCAPI.Data;  // notice this was added automatically after adding <AppDbContext>

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// add this
builder.Services.AddControllers();

var app = builder.Build();  // this will append stuff

// add this
app.MapControllers();

// Configure the HTTP request pipeline.  this is our swagger which is our environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.Run();
