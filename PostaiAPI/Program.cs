using GrupineUzduotisPostai.Core.Contracts;
using GrupineUzduotisPostai.Core.Repositories;
using GrupineUzduotisPostai.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<IPostEfDbRepository, PostEfDbRepository>(_ => new PostEfDbRepository());
builder.Services.AddTransient<IUserEfDbRepository, UserEfDbRepository>(_ => new UserEfDbRepository());
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy =>
        {
            policy.WithOrigins("https://localhost:7075")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});



var app = builder.Build();

app.UseCors("AllowSpecificOrigin");

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
