
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using empty;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMvc()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler=ReferenceHandler.Preserve);

string? db_username = builder.Configuration.GetValue<string>("db_user");
string? db_password = builder.Configuration.GetValue<string>("db_password");
string? db_host = builder.Configuration.GetValue<string>("db_host");
string? db_name = builder.Configuration.GetValue<string>("db_name");
string? db_port = builder.Configuration.GetValue<string>("db_port");

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?.Replace("{HOST}", db_host)
    .Replace("{USERNAME}", db_username)
    .Replace("{PASSWORD}", db_password)
    .Replace("{DATABASE}", db_name)
    .Replace("{PORT}", db_port);

builder.Services.AddDbContext<MovieDataContext>(optios =>
    optios.UseNpgsql(connectionString));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseRouting();
app.MapControllers();

app.Run();
