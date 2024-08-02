using ACMESchool.Persistence.Contract;
using ACMESchool.Persistence.Implementation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ACMESchool.Persistence
{

    public static class PersistenceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddTransient<IStudentRepository, StudentRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();


            return services;
        }
    }
}
