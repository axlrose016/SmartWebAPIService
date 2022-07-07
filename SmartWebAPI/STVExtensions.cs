using EmailService.Core.Models;
using EmailService.Core.Repositories;
using EmailService.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwilioService.Core.Models;
using TwilioService.Core.Repositories;
using TwilioService.Persistence.Repositories;

namespace SmartWebAPI
{
    public static class STVExtensions
    {
        public static void TwilioServiceCentre(this IServiceCollection services, IConfiguration configuration)
        {
            var twilioConfig = configuration
                .GetSection("TwilioConfiguration")
                .Get<TwilioConfiguration>();
            services.AddSingleton(twilioConfig);
            services.AddScoped<ITwilioCentreRepo, TwilioCentreRepo>();
        }

        public static void EmailServiceCentre(this IServiceCollection services, IConfiguration configuration)
        {
            var emailConfig = configuration
                .GetSection("EmailConfiguration")
                .Get<MailConfig>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailCentreRepo, EmailCentreRepo>();
        }
    }
}
