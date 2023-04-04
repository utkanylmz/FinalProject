using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IOC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.AutoFac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration; //Süre vermezsek default süre
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            //Servicetool'u kullarak hangi cacheManager'ı kullanacağımı bildiriyorum ileride cache sisteminde değişiklik yaparsam
            //burada işlem yapmama gerek yok çünkü Cache services'ım cache manager'den iplemente edilecek Ioc'ye gidip referansını 
            //almak istedğim cache managerini bildiresem yeterli 
        }

        // CacheManager Devreye girmeden intercepti araya sokuyoruz
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            // methodName'ini alıyor invocation.Method.ReflectedType= namespace+interfaceName . method ismi burada key oluşturyoruz.
            var arguments = invocation.Arguments.ToList();
            //metotdun parametlerini listeye çeviriyoruz
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //Keyi oluşturmak için yukarıda method name'i ve methodun argumentlerını birliştiryoruz eğer argument yoksa null geçiyoruz
            // ve key'i oluşturyoruz.
            if (_cacheManager.IsAdd(key))
            {
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);

            // Cache'de  key var mı
            // Eğer varsa metotdu hiç çalıştırmadan Cacheteki değeri döndür
            //Eğer yoksa metodu Çalıştır ve Cache ekle.
            
        }
    }
}
