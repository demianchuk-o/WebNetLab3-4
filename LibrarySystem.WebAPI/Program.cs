using System.Reflection;
using LibrarySystem.Bll.MappingProfiles;
using LibrarySystem.Bll.Security;
using LibrarySystem.Bll.Services;
using LibrarySystem.Bll.Services.Abstract;
using LibrarySystem.Common.Books;
using LibrarySystem.DAL.Context;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories;
using LibrarySystem.DAL.Repositories.Abstract;
using LibrarySystem.DAL.UnitOfWork;
using LibrarySystem.DAL.UnitOfWork.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"],
        opt => opt.MigrationsAssembly(typeof(LibraryDbContext).Assembly.FullName)));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ILoanRepository, LoansRepository>();
builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<JwtFactory>(provider => new JwtFactory(builder.Configuration));

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILoanService, LoanService>();

builder.Services.AddIdentity<User, LibraryRole>()
    .AddEntityFrameworkStores<LibraryDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<UserManager<User>>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(cfg =>
    {
        cfg.AddProfile<BookProfile>();
        cfg.AddProfile<LoanProfile>();
        cfg.AddProfile<UserProfile>();
    },
    Assembly.GetExecutingAssembly());

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