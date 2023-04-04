using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.IOC
{
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }// .Net' services'lerini al ve build et Web Api veya Autofac te oluşturduğum
     // Injection oluşturabilmeme yarıyor Herhangi bi interfacenin servisteki karşılığını alabilmemi sağlıyor

}
