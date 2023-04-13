using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Basket.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

        services.AddControllers();
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Basket.API", Version = "v1" });
        });

        services.AddAutoMapper(typeof(Startup));

        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddScoped<IBasketService, BasketService>();

        services.AddGrpcClient<DiscountProtoService.DiscountProtoServiceClient>(opt =>
        {
            opt.Address = new Uri(Configuration.GetValue<string>("GrpcSettings:DiscountUrl"));
        });
        services.AddScoped<DiscountGrpcService>();

        services.AddStackExchangeRedisCache(opt =>
        {
            opt.Configuration = Configuration.GetValue<string>("CacheSettings:ConnectionString");
        });

        services.AddMassTransit(config =>
        {
            config.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.Host(Configuration["EventBusSettings:HostAddress"]);
            });
        });

        services.AddOptions<MassTransitHostOptions>()
            .Configure(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(30);
                options.StopTimeout = TimeSpan.FromMinutes(5);
            });

        services.AddHealthChecks()
                .AddRedis(Configuration["CacheSettings:ConnectionString"], "Redis Health", HealthStatus.Degraded);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Basket.API v1"));
        }

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapHealthChecks("/hc", new HealthCheckOptions()
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });
        });
    }
}
