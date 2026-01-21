using SignalRWebUI.Services.Abstract;
using SignalRWebUI.Services.Concrete;

namespace SignalRWebUI.Extensions
{
    public static class ApiServiceExtensions
    {
        public static IServiceCollection AddApiServices(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var baseUrl = configuration.GetValue<string>("ApiSettings:BaseUrl");

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                throw new InvalidOperationException("ApiSettings:BaseUrl appsettings.json içinde bulunamadı.");
            }
            services.AddHttpClient<ICategoryApiService, CategoryApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddHttpClient<IProductApiService, ProductApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddHttpClient<IAboutApiService, AboutApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddHttpClient<IBookingApiService, BookingApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddHttpClient<IContactApiService, ContactApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddHttpClient<IDiscountApiService, DiscountApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddHttpClient<IFeatureApiService, FeatureApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddHttpClient<ISocialMediaApiService, SocialMediaApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            services.AddHttpClient<ITestimonialApiService, TestimonialApiService>(client =>
            {
                client.BaseAddress = new Uri(baseUrl);
            });

            return services;
        }


    }
}
