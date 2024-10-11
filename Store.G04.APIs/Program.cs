
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.G04.APIs.Error;
using Store.G04.APIs.Helper;
using Store.G04.APIs.MiddelWares;
using Store.G04.Core;
using Store.G04.Core.Mapping;
using Store.G04.Repository;
using Store.G04.Repository.Data.Context;
using Store.G04.Services.Services;


namespace Store.G04.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Sevices

            builder.Services.AddDepandency(builder.Configuration);

            var app = builder.Build();

            // Middleware

            await app.ConfigureMiddelwareAsync();

            app.Run();
        }
    }
}
