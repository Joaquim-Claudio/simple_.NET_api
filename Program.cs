
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using empty;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvc()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.Preserve);

builder.Services.AddDbContext<MovieDataContext>(optios =>
    optios.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.MapControllers();

app.Run();
