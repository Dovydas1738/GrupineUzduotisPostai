using GrupineUzduotisPostai.Core.Contracts;
using GrupineUzduotisPostai.Core.Repositories;
using GrupineUzduotisPostai.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddTransient<IPostEfDbRepository, PostEfDbRepository>(_ => new PostEfDbRepository());
builder.Services.AddTransient<IUserEfDbRepository, UserEfDbRepository>(_ => new UserEfDbRepository());
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
