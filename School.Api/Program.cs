using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.AutoMapper;
using School.Domain.Options;
using School.Repository.Cursos;
using School.Repository.Members;
using School.Service.Courses;
using School.Service.Members;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DBContext") ??
    throw new InvalidOperationException("Connection string 'DBContext' not found.")));

//Option Pattern (DBContext)
builder.Services.Configure<DBContextOptions>(builder.Configuration.GetSection(key: "ConnectionStrings"));

//AutoMapper
builder.Services.AddAutoMapper(typeof(MemberMapper));

//Dependency injection
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, CourseRepository>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IMemberRepository, MemberRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
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
