using CandidateTracker.Api.Configurations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddCorsPolicy()
    .AddDbContext(builder)
    .AddDependencies();


builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors("CORS");

app.Run();
