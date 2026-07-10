using HotelBooking.Application;


namespace HotelBooking.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddApplicationDI();         
            return services;
        }
    }
}
