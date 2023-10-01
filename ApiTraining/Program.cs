using ApiTraining.Data;
using ApiTraining.Mapper;
using ApiTraining.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*builder.Services.AddDbContext<ApiDBContext>(options => options.UseSqlServer(conxString));*/
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddDbContext<ApiDbContext>(options =>
               options.UseSqlite(builder.Configuration.GetConnectionString("ApiSqliteConnection")));
builder.Services.AddControllers();
builder.Services.AddScoped<IPlaceServices, PlaceServices>();

builder.Services.AddSwaggerGen();

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
