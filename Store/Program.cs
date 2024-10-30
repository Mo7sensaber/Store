
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Store.Core;
using Store.Core.Mapping.Products;
using Store.Core.Services.Contract;
using Store.Error;
using Store.Helper;
using Store.Middlewares;
using Store.Repositorty;
using Store.Repositorty.Data;
using Store.Repositorty.Data.Contexts;
using Store.Service.Services.Products;

namespace Store
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDependancy(builder.Configuration);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



           
            var app = builder.Build();
            app.UseCors("AllowLocalhost");
            await app.ConfigureMiddlewareAsync();

            app.Run();
        }
    }
}
