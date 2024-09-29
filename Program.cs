using WebApiPatikaBootcampTask.Repositories;

var builder = WebApplication.CreateBuilder(args);


// ? For Dependency Injection added to services ?
builder.Services.AddScoped<IMusicianRepository, MusicianRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
