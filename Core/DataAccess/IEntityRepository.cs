using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Generic Constraint --> Generic kısıt 
    //Class :Referans tip Anlamına geliyor
    //IEntity : IEntity olabilir ya da IEntity İplemente eden bir nesne olabilir.
    //new :Newlenebilir olmalı
    //Burada IEntityRepository İnterfacesi oluşturdum ve bu interfaceyi Generic bir interface yaptım interfaceyi kullanıcagım yerde Hangi tipte çalışacağını belirtiyorum
    //bunu yapma sebebim Bu 5 Metotu birden çok yerde kullanacağımdan dolayı bu 5 metodu direkt  kullancağım yerde tipini belirterek iplemente ediyorum 
    //Ama genericte her türlü parametre verilebiliyor bunu engellemek için t:class diyerek genericteki t nin sadace referans tip olması gerektiğini söylüyorum
    //IEntity diyerek sadace veri tabanı nesnelerimde  iplemente ettiğim IEntity veya Ientity türünde olması gerekteğini belirtiyorum
    //Ve en son new() yazarak bu generice verilecek parametrenin newlenmesi gerektiğini söylüyorum böylece sadace veri tabanı tablolarım generic interfaceme parametre verilebilir oluyor. 
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);


    }
}
