using AgencyTask.Business.MapperProfiles;
using AgencyTask.Business.Services.Implementation;
using AgencyTask.Business.Services.Interfaces;
using AgencyTask.Business.ViewModels.PortfolioVms;
using AgencyTask.Core.Entities;
using AgencyTask.DAL.Context;
using AgencyTask.DAL.Repositories.Implementation;
using AgencyTask.DAL.Repositories.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters =
    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._+";
}).AddEntityFrameworkStores<AppDbContext>()
  .AddDefaultTokenProviders();

builder.Services.AddScoped<IValidator<CreatePortfolioVm>, CreatePortfolioVmValidatior>();
builder.Services.AddScoped<IValidator<UpdatePortfolioVm>, UpdatePortfolioVmValidatior>();

builder.Services.AddDbContext<AppDbContext>(
	options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddAutoMapper(typeof(PortfolioMapperProfile).Assembly);

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
  name: "areas",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
