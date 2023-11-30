using Microsoft.EntityFrameworkCore;
using STIMULUS_V2.Server.Data;
using STIMULUS_V2.Shared.Interface.ChildInterface;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;
using System.Linq;
using System.Net.Http;

namespace STIMULUS_V2.Server.Services
{
    public class FichierSauvegardeService : IFichierSauvegardeService
    {
        private readonly STIMULUSContext sTIMULUSContext;

        public FichierSauvegardeService(STIMULUSContext sTIMULUSContext)
        {
            this.sTIMULUSContext = sTIMULUSContext;
        }

        public async Task<APIResponse<FichierSauvegarde>> Create(FichierSauvegarde item)
        {
            try
            {
                sTIMULUSContext.FichierSauvegarde.Add(item);
                await sTIMULUSContext.SaveChangesAsync();

                if (sTIMULUSContext.FichierSauvegarde.Contains(item))
                {
                    return new APIResponse<FichierSauvegarde>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<FichierSauvegarde>(null, 500, "Erreur interne du serveur");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSauvegarde>(null, 500, $"Erreur lors de la création du model : {typeof(FichierSauvegarde).Name}. Message : {ex.Message}");
            }
        }
        public async Task<APIResponse<string>> PostExercice(string codeJson, int? idEtudiant)
        {
            var urlBuilder_ = new System.Text.StringBuilder();
            urlBuilder_.Append("api/Pages");

            var client_ = _httpClient;
            var disposeClient_ = false;
            try
            {
                using (var request_ = new System.Net.Http.HttpRequestMessage())
                {
                    request_.Content = new System.Net.Http.StringContent(string.Empty, System.Text.Encoding.UTF8, "text/plain");
                    request_.Method = new System.Net.Http.HttpMethod("POST");
                    request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("text/plain"));

                    PrepareRequest(client_, request_, urlBuilder_);

                    var url_ = urlBuilder_.ToString();
                    request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                    PrepareRequest(client_, request_, url_);

                    var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                    var disposeResponse_ = true;
                    try
                    {
                        var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                        if (response_.Content != null && response_.Content.Headers != null)
                        {
                            foreach (var item_ in response_.Content.Headers)
                                headers_[item_.Key] = item_.Value;
                        }

                        ProcessResponse(client_, response_);

                        var status_ = (int)response_.StatusCode;
                        if (status_ == 200)
                        {
                            var objectResponse_ = await ReadObjectResponseAsync<string>(response_, headers_, cancellationToken).ConfigureAwait(false);
                            if (objectResponse_.Object == null)
                            {
                                throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                            }
                            return objectResponse_.Object;
                        }
                        else
                        {
                            var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                            throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                        }
                    }
                    finally
                    {
                        if (disposeResponse_)
                            response_.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSauvegarde>(null, 500, $"Erreur lors de la création du model : {typeof(FichierSauvegarde).Name}. Message : {ex.Message}");
            }
        }

        public async Task<APIResponse<bool>> Delete(int id)
        {
            try
            {
                if (sTIMULUSContext.FichierSauvegarde.Where(item => item.FichierSauvegardeId == id).Count() > 0)
                {
                    var item = await sTIMULUSContext.FichierSauvegarde.FindAsync(id);
                    sTIMULUSContext.FichierSauvegarde.Remove(item);
                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<bool>(true, 200, "Succès");
                }
                else
                {
                    return new APIResponse<bool>(false, 404, $"{typeof(FichierSauvegarde).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    // Access the inner exception and its details
                    Exception innerException = ex.InnerException;
                    string innerExceptionMessage = innerException.Message;
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}. Inner Exception: {innerExceptionMessage}");
                }
                else
                {
                    return new APIResponse<bool>(false, 500, $"Erreur lors de la suppression du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}.");
                }
            }
        }

        public async Task<APIResponse<FichierSauvegarde>> Get(int id)
        {
            try
            {
                var item = await sTIMULUSContext.FichierSauvegarde.FindAsync(id);

                if (item != null)
                {
                    return new APIResponse<FichierSauvegarde>(item, 200, "Succès");
                }
                else
                {
                    return new APIResponse<FichierSauvegarde>(null, 404, $"{typeof(FichierSauvegarde).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSauvegarde>(null, 500, $"Erreur lors de la récupération du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetAll()
        {
            try
            {
                var itemList = await sTIMULUSContext.FichierSauvegarde.ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<FichierSauvegarde>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<FichierSauvegarde>>(null, 404, $"{typeof(FichierSauvegarde).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<FichierSauvegarde>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}.");
            }
        }

        public Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<APIResponse<IEnumerable<FichierSauvegarde>>> GetAllExercice(int exerciceId, string da)
        {
            try
            {
                var itemList = await sTIMULUSContext.FichierSauvegarde.Where(item => item.CodeDA == da && item.ExerciceId == exerciceId ).ToListAsync();

                if (itemList != null)
                {
                    return new APIResponse<IEnumerable<FichierSauvegarde>>(itemList, 200, "Succès");
                }
                else
                {
                    return new APIResponse<IEnumerable<FichierSauvegarde>>(null, 404, $"{typeof(FichierSauvegarde).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<IEnumerable<FichierSauvegarde>>(null, 500, $"Erreur lors de la récupération de la liste du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}.");
            }
        }

        public async Task<APIResponse<FichierSauvegarde>> Update(int id, FichierSauvegarde item)
        {
            try
            {
                var existingItem = await sTIMULUSContext.FichierSauvegarde.FindAsync(id);

                if (existingItem != null)
                {
                    sTIMULUSContext.Entry(existingItem).CurrentValues.SetValues(item);

                    await sTIMULUSContext.SaveChangesAsync();

                    return new APIResponse<FichierSauvegarde>(existingItem, 200, "Succès");
                }
                else
                {
                    return new APIResponse<FichierSauvegarde>(null, 404, $"{typeof(FichierSauvegarde).Name} non trouvé");
                }
            }
            catch (Exception ex)
            {
                return new APIResponse<FichierSauvegarde>(null, 500, $"Erreur lors de la mise à jour du model {typeof(FichierSauvegarde).Name}. Message : {ex.Message}.");
            }
        }
    }
}
