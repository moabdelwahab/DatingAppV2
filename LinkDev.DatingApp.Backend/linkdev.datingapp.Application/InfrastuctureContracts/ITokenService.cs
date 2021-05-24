using LinkDev.DatingApp.Core;

namespace LinkDev.DatingApp.Application.InfrastuctureContracts
{
    public interface ITokenService
    {
         string CreateToken(AppUser user);
    }
}