using Auction.API;
using Auction.API.Helpers;
using Auction.Business;
using Auction.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Twitter.API.Helpers;

namespace Auction;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var jwt = builder.Configuration.GetSection("Jwt").Get<Jwt>();

        // Add services to the container.

        builder.Services.AddControllers().AddNewtonsoftJson(opt=>
        {
            opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        });

        builder.Services.AddControllersWithViews();

        builder.Services.AddCors(opt =>
        {
            opt.AddDefaultPolicy(pol =>
            {
                pol.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod();
            });
        });

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
            opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Please enter token",
                Name = "Authorization",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT",
                Scheme = "bearer"
            });

            opt.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type=ReferenceType.SecurityScheme,
                            Id="Bearer"
                        }
                    },
                    new string[]{}
                }
            });
        }
        );

        builder.Services.AddDbContext<AuctionContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"))
        );
        builder.Services.AddUserIdentity();
        builder.Services.AddServices();
        builder.Services.AddRepositories();
        builder.Services.AddBusinessLayer();
        builder.Services.AddJwtAuthentication(jwt);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(options => {
                options.ConfigObject.AdditionalItems.Add("persistAuthorization", true);
            });
        }

        app.UseStaticFiles();

        app.UseHttpsRedirection();

        app.UseCors();

        app.UseSeedData();
        app.UseCustomExceptionHandler();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=AdminItem}/{action=Index}/{id?}"
        );

        app.Run();
    }
}