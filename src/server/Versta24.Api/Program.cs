using Versta24.Api;
using Versta24.Api.AutoMapperConfig;
using Versta24.Api.Extensions;
using Versta24.Application;
using Versta24.Infrastructure;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

//Add Layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

//Add automapper
builder.Services.AddAutoMapper(typeof(AutoMapProfile));

//Add middleware
builder.Services.AddTransient<ExceptionHandlingMiddleware>();


var app = builder.Build();


app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

//Migrate db
DatabaseExtensions.MigrateDatabase(app);

app.Run();