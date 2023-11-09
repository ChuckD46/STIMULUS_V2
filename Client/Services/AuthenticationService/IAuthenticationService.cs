using STIMULUS_V2.Shared.Models.Authentication;

namespace STIMULUS_V2.Client.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        // Public Interfaces
        Task<object> RegisterAccountAsync(InscriptionVerification model);
        Task<SessionUtilisateur> LoginAsync(ConnexionVerification model);


        //Protected Interfaces
        Task<int> GetUserCount();
        Task<string> GetMyInfo(string email);
    }
}
