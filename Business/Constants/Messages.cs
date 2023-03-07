using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi Geçersiz";
        public static string MaintenanceTime = "Bakım zamanı";
        public static string ProductListed = "Üürnler Listelendi";
        public static string ProductCountOfCategoryError = "Kategorideki Ürün sayısını aştınız";
        public static string ProductNameIsSame = "Ürün isimleri aynı olamaz";
        public static string CategoryCountIsMax = "Category sayısı maximum değerine ulaştı";

        public static string AuthorizationDenied = "Yetkiniz Yok";
        internal static string UserRegistered = "Kayıt Olundu";
        internal static string UserNotFound = "Kullanıcı Bulunamadı";
        internal static string PasswordError = "Şifre Hatalı";
        internal static string SuccessfulLogin = "Başarılı Giriş";
        internal static string UserAlreadyExists = "Kullanıcı Mevcut";
        internal static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
