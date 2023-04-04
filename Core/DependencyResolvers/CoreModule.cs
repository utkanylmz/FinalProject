using Autofac.Core;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection servicesCollection)
        {
            
            servicesCollection.AddMemoryCache();//.NetCore'dan geliyor Microsoft'un altyapısından
                                                //geldiği için instance direkt olusturuyor
            servicesCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            servicesCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            servicesCollection.AddSingleton<Stopwatch>();
            


            //Burada projemdeki bağımlıkları startup'a gönderip ekleme yaptığım yer.
        }
    }
}
