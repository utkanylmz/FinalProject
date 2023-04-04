using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        T GetT<T>(string key);
        object Get(string key); //T Get<T> ile aynı ama bunda tip cast'i yapmak zorundasın
        bool IsAdd(string key);//cache'te var mı
        void Remove(string key);//Cache'ten sil
        void RemoveByPattern(string pattern);//RegEx'e göre sil
    }
}
