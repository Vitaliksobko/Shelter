using System.Reflection;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Shelter.Application.Abstractions;
using Shelter.Application.Models;
using Shelter.Application.Services;
using Shelter.Core.Abstraction;
using Shelter.Core.Models;
using Shelter.infrastructure;
using Shelter.infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



builder.Services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();




builder.Services.AddScoped<IAuthorizationService, AuthorizationService>();
builder.Services.AddScoped<IAnimalService, AnimalService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<INewsService, NewsService>();
builder.Services.AddScoped<IQuestionService, QuestionService>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(Lazy<>), typeof(LazyInstance<>));

builder.Services.AddDbContext<ShelterDbContext>(
    options => options.UseNpgsql(builder.Configuration.GetConnectionString("Default"))
);

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<ShelterDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication();

var app = builder.Build();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Images")),
    RequestPath = new PathString("/Images")
});


app.UseAuthorization();

app.MapControllers();

app.Run();