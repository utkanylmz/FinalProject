using Core.Entities.Concrete;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
    //Token Üretecek Metot
    //User: Kullanıcının girdiği kullanıcı bilgileri doğruysa bu kullanıcın claimlerini Liste Şelinde tutacaz. 
    //List<Operation Claims> : Kullacının İşlem Yetkileri .
}
