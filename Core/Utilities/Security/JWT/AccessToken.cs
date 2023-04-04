using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
    //AccessToken : Kullanıcı sisteme istekte bulunurken eğer yetki gerektiren bir işlem yapıcaksa paketin içine Tokenı koyar ve gönderir 
    //Buna Tokena AccessToken(Erişim Anahtarı) Denir Bu classta bulunması gerekn özellikleri veriyoruz ACCESS TOKEN'IN metni(string) ve Kullanım Süresi vardır .
}
