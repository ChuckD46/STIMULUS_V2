using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class GroupeEtudiantService : IGroupeEtudiantService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public GroupeEtudiantService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<IEnumerable<Groupe_Etudiant>>> GetAllGroupForStudent(string id)
        {
            try
            {
                var itemList = await sTIMULUSContext.Groupe_Etudiant.Where(item => item.Etudiant.CodeDA == id).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<Groupe_Etudiant>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<Groupe_Etudiant>>(null, 404, $"{typeof(Groupe_Etudiant).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<Groupe_Etudiant>>(null, 500, $"Erreur lors de la récupération du model par son parent {typeof(Groupe_Etudiant).Name}. Message : {ex.Message}.");
            }
        }
    }
}
