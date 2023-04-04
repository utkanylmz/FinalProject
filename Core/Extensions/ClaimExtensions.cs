using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimExtensions
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
    //.Net'te var olan nesneye yeni metotlar eklenebilir buna Extensions(Genişletme) denir . Burada Claim nesnesine AddEmail,AddName,AddNameIdentifier,AddRoles metotları ekliyorum.
    //  public static void AddEmail(this ICollection<Claim> claims, string email) --> this ICollection<Claim> claims Bu Metot Claim Koleksiyonuna eklenecek ve bu metot parametre olarak string Email alıcak anlamına geliyor
}
