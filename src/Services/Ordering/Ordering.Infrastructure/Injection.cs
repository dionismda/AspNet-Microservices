namespace Ordering.Infrastructure;

public static class Injection
{
    public static IServiceCollection InfrastructureInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<OrderContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("OrderingConnectionString")));

        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        services.AddScoped<IOrderRepository, OrderRepository>();

        services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailService, EmailService>();

        return services;
    }
}
