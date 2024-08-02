using ACMESchool.ExternalServices.Contract;
using ACMESchool.ExternalServices.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace ACMESchool.ExternalServices
{
    public static class ExternalServicesRegistration
    {
        public static IServiceCollection AddExternalServicesServices(this IServiceCollection services)
        {
            services.AddTransient<IPaymentGateway, PaymentGateway>();
            return services;
        }
    }
}
