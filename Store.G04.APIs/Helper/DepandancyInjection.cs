using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using Store.G04.APIs.Error;
using Store.G04.Core;
using Store.G04.Core.Mapping;
using Store.G04.Core.Repository.Contract;
using Store.G04.Core.Services.Contract;
using Store.G04.Repository;
using Store.G04.Repository.Data.Context;
using Store.G04.Repository.Repositores;
using Store.G04.Services.Services;

namespace Store.G04.APIs.Helper
{
    public static class DepandancyInjection
    {
        public static IServiceCollection AddDepandency(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddBuildInServices();
            services.AddSwaggerServices();
            services.AddDbContextServices(configuration);
            services.AddUserDefinedServices();
            services.AddAutoMapperServices(configuration);
            services.ConfogurationModelStateResponseServices();
            services.AddRedisServices(configuration);

            return services;
        }

        private static IServiceCollection AddBuildInServices(this IServiceCollection services)
        {

            // Add services to the container.

            services.AddControllers();

            return services;
        }
        private static IServiceCollection AddSwaggerServices(this IServiceCollection services)
        {

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
        private static IServiceCollection AddDbContextServices(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddDbContext<StoreDbContext>(option =>
           option.UseSqlServer(configuration.GetConnectionString("ConnectionDefault"))
           );

            return services;
        }
        private static IServiceCollection AddUserDefinedServices(this IServiceCollection services)
        {

            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IBasketServices, basketServices>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBasketRepository, BasketRepository>();

            return services;
        }
        private static IServiceCollection AddAutoMapperServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAutoMapper(m => m.AddProfile(new ProductProfile(configuration)));
            services.AddAutoMapper(m => m.AddProfile(new BasketProfile()));


            return services;
        }
        private static IServiceCollection ConfogurationModelStateResponseServices(this IServiceCollection services)
        {

            // to handel Validation Error

            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = (actioncontext) =>
                {
                    var errors = actioncontext.ModelState.Where(P => P.Value.Errors.Count() > 0)
                                                        .SelectMany(P => P.Value.Errors)
                                                        .Select(E => E.ErrorMessage)
                                                        .ToArray();

                    var response = new ApiValdiationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(response);
                };
            });

            return services;
        }
        private static IServiceCollection AddRedisServices(this IServiceCollection services , IConfiguration configuration)
        {

            services.AddSingleton<IConnectionMultiplexer>((servicesprovider =>
            {
                var connection = configuration.GetConnectionString("Redis");

                return ConnectionMultiplexer.Connect(connection);
            }));

            return services;
        }
    }
}
