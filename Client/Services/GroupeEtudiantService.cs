using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Net.Http.Json;

namespace STIMULUS_V2.Client.Services
{
    public class GroupeEtudiantService : IGroupeEtudiantService
    {
        private readonly HttpClient _httpClient;

        public GroupeEtudiantService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllGroupForStudent(string item)
        {
            var result = await _httpClient.GetFromJsonAsync<APIResponse<IEnumerable<Groupe_Etudiant>>>($"api/GroupeEtudiant/Fetch/GroupsForStudent/{item}");
            return result; ;
        }
    }
}
