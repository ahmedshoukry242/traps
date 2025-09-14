using Core.Entities.Auth;
using Core.Interfaces.IRepositories;
using Core.Interfaces.IServices;
using Core.Interfaces.IServices.IAuth;
using Core.Interfaces.ISystemServices;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Service.Services;
using Service.Services.Auth;
using Service.SystemServices;
using System.Data;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers(options =>
{
    var pollicy = new AuthorizationPolicyBuilder()
    .RequireAuthenticatedUser()
    //.RequireClaim("", "")
    //.RequireRole("")
    .Build();
    options.Filters.Add(new AuthorizeFilter(pollicy));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("Auth", new OpenApiInfo { Title = "Auth", Version = "V01" });
    x.SwaggerDoc("General", new OpenApiInfo { Title = "General", Version = "V01" });

    // Swagger configurations to show lock icon and put token in it
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer", // this is a default scheme to not write bearer before the token manually
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter 'Bearer' [space] and then your token.",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    x.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    x.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddDbContext<TrapDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultCS")));
builder.Services.AddIdentity<User, IdentityRole<Guid>>(
    options =>
    {
        options.Password.RequireDigit = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequiredLength = 6;
        options.Password.RequiredUniqueChars = 1;
        options.SignIn.RequireConfirmedAccount = true;
        options.User.RequireUniqueEmail = true;
    }
    )
    .AddEntityFrameworkStores<TrapDbContext>();



builder.Services.AddScoped<Seeding>();
builder.Services.AddAutoMapper(typeof(Core.Helpers.Mapping.MappingProfile).Assembly);
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ITrapService, TrapService>();
builder.Services.AddScoped<ITrapReadService, TrapReadService>();
builder.Services.AddScoped<ILookupsService, LookupsService>();
builder.Services.AddScoped<ITrapEmergencyService, TrapEmergencyService>();
builder.Services.AddScoped<IUserBasicData, UserBasicData>();

// default configuration to authenticate the user and accept the token
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["JWT:SecretKey"]))
    };
});


builder.Services.AddCors(opt =>
{
    opt.AddPolicy("DevMode", policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.MapOpenApi();
    app.UseSwagger();

    app.UseSwaggerUI(c =>
    {

        c.SwaggerEndpoint("/swagger/Auth/swagger.json", "Auth V01");
        c.SwaggerEndpoint("/swagger/General/swagger.json", "General V01");

        //c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

        
        c.RoutePrefix = string.Empty;
        c.EnablePersistAuthorization();
    });
}


using(var scope = app.Services.CreateScope())
{
    var dataSeeder = scope.ServiceProvider.GetRequiredService<Seeding>();
    await dataSeeder.SeedRoles();
}

app.UseCors("DevMode");

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseHttpsRedirection();



app.Run();


