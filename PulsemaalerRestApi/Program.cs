using Microsoft.EntityFrameworkCore;
using PulsemaalerRestApi.Model;


var builder = WebApplication.CreateBuilder(args);
// Add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowAll",
                              policy =>
                              {
                                  policy.AllowAnyOrigin()
                                  .AllowAnyMethod()
                                  .AllowAnyHeader();
                              });
});



builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Add DbContext
builder.Services.AddDbContext<PersonDbContext>(options =>
    options.UseSqlServer(Connection._connectionString));
builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<PulsHistoryRepository>();


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
// Enable CORS
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
