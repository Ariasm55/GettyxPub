using Getty.Core.Interfaces;
using Getty.Infrastructure.Data;
using Getty.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Getty.Infrastructure.Filters;
using FluentValidation.AspNetCore;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

 string MyCors = "MyCors";



//Add Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Add services to the container, addin json settings for timezone, null values and reference looping.
builder.Services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    options.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                    options.UseCamelCasing(false);
                });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<GettyContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("GettyX")));


//
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddTransient<IScheduleRepository, ScheduleRepository>();
builder.Services.AddTransient<IUsersRepository, UsersRepository>();


builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization using Bearer scheme (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//setting up Jwt On program.cs
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(jwtBearerOptions =>

    {
        jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Authentication:SecretKey"]))
        };
    });

builder.Services.AddCors(opts =>
{
    opts.AddPolicy(name: MyCors,
                    builder =>
                    {
                        builder.WithOrigins("*");
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
});

//Appliying model validation globally.
builder.Services.AddMvc(options =>
{
    options.Filters.Add<ValidatonFilter>();

}).AddFluentValidation(options => {

    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

});

var app = builder.Build();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//using cors

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(MyCors);


app.MapControllers();

app.Run();
