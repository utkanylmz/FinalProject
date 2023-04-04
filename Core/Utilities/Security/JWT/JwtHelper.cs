using Core.Entities.Concrete;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Utilities.Security.JWT
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }
        private TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        // _tokenOptions --> IConfiguration configuration sınıfı ile appSettings.json dosyasından okuduğum değerleri atacağım nesne
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

        }

        // 23.satır Açıklama( _tokenOptions) appSettings.json dosyasına git "TokenOptions" alanını bul(GetSection) o verileri TokenOptions _tokenOptions'a ata  
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }
        // Bir tokenda neler olması gerekiyor 

        //1) bitiş süresi ilk satırda şuan ki zamana _tokenOptions.AccessTokenExpirationdan gelen süreyi ekle diyoruz 
        // _tokenOptions constractor'a Enjekte ettiğimiz IConfiguration configuration bizim Web Api'deki appsettings.json dosyamızı Okuyor 
        //Eklenecek süre Oradan geliyor

        //2)Security Key SecurityKeyHelper clasımdaki static  CreateSecurityKey metotumu kullanarak  appsettings.json dosyamdaki SecurityKey' byte formatına çeviriyorum 

        //3) SigningCredentialsHelper clasında static CreateSigningCredentials(securityKey) metotdunda Web apiye kullacağı SecurityKeyi veriyoruz .

        //4) CreateJwtSecurityToken metotduna parametrelerini vererek bir jwt oluşturuyoruz
      
        //  _tokenOptions --> appSettings.json dosyasından geliyor  -->User bilgisi Metota parametre olarak alıyoruz.
        // signingCredentials -->Metot içinde SigningCredentialsHelper clasında static CreateSigningCredentials metotdunu kullanrak elde ediyoruz
        // operationClaims --> Metota parametre olarak alıyouz
      
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user,
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        // Bir jwt oluşturmak için gerekli bütün bilgileri veriyorum geriye bir jwt döndürüyorum

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
        //Claimleri oluşturuyoruz 
        //  claims.AddRoles(operationClaims.Select(c => c.Name).ToArray()); --> Kullancını claimlerinin isimlerini veri tabanından çekip onları array'e basıp rollere ekleme işi
    }
}
