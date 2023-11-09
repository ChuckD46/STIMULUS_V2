using Blazored.LocalStorage;
using Newtonsoft.Json;
using STIMULUS_V2.Shared.Models.Authentication;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        // Constructor with Local Storage and Token-Free HttpClient.
        private readonly ILocalStorageService localStorageService;
        private readonly HttpClient httpClient;
        public AuthenticationService(ILocalStorageService localStorageService, HttpClient httpClient)
        {
            this.localStorageService = localStorageService;
            this.httpClient = httpClient;
        }

        //Public Methods with no Token needed
        public async Task<SessionUtilisateur> LoginAsync(ConnexionVerification model)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync("api/Authentication/Connexion", model);
                var response = await result.Content.ReadFromJsonAsync<SessionUtilisateur>();
                return response!;
            }
            catch (Exception ex)
            {
                // Gérer l'exception ou enregistrer les détails de l'erreur
                Console.WriteLine($"Une erreur s'est produite lors de l'appel API : {ex.Message}");
                throw; // Vous pouvez choisir de traiter l'exception ici ou la propager vers le niveau supérieur.
            }

        }

        public async Task<object> RegisterAccountAsync(InscriptionVerification model)
        {
            var result = await httpClient.PostAsJsonAsync("api/Authentication/Inscription", model);
            var response = await result.Content.ReadAsStringAsync();
            return response;
        }



        // Protected Methods which need Token.
        public async Task<int> GetUserCount()
        {
            var securedClient = await SecuredClient();
            var result = await securedClient.GetAsync("api/Authentication/total-users");
            if (result.StatusCode != System.Net.HttpStatusCode.Unauthorized)
                return await result.Content.ReadFromJsonAsync<int>();

            await GetNewToken();
            int response = await GetUserCount();
            return response;
        }

        public async Task<string> GetMyInfo(string id)
        {
            var securedClient = await SecuredClient();
            var result = await securedClient.GetAsync($"api/Authentication/my-info/{id}");
            if (result.StatusCode != System.Net.HttpStatusCode.Unauthorized)
                return await result.Content.ReadAsStringAsync();

            await GetNewToken();
            var info = await GetMyInfo(id);
            return info;
        }



        // General & Frequent Call-up Methods
        private async Task<bool> GetNewToken()
        {
            var token = await localStorageService.GetItemAsync<string>("token");
            if (string.IsNullOrEmpty(token)) return false;

            var getNetTokenAndRefreshToken = await httpClient.PostAsJsonAsync("api/Authentication/GetNewToken", DeSerializedUserSession(token));
            var response = await getNetTokenAndRefreshToken.Content.ReadFromJsonAsync<SessionUtilisateur>();

            if (response is null) return false;

            var serializedUserSeeion = SerializedUserSession(response!);
            await localStorageService.RemoveItemAsync("token");
            await localStorageService.SetItemAsync("token", serializedUserSeeion);
            await SecuredClient();
            return true;
        }

        private async Task<HttpClient> SecuredClient()
        {
            var client = new HttpClient();
            var token = await localStorageService.GetItemAsync<string>("token");
            var userSession = DeSerializedUserSession(token);
            if (userSession is null) return client;

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", userSession.Token);
            return client;
        }

        private static SessionUtilisateur DeSerializedUserSession(string SerialisedString)
        {
            return JsonConvert.DeserializeObject<SessionUtilisateur>(SerialisedString)!;
        }

        private static string SerializedUserSession(SessionUtilisateur userSession)
        {
            return JsonConvert.SerializeObject(userSession);
        }
    }
}
