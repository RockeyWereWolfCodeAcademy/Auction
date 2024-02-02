using Auction.API;
using Auction.API.Helpers;
using Auction.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Auction;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AuctionContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MSSql"))
        );
        builder.Services.AddUserIdentity();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseSeedData();

        app.MapControllers();

        app.Run();
    }
}