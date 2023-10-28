using STIMULUS_V2.Shared.Models.DTOs;

namespace STIMULUS_V2.Server.Services.Interfaces
{
    public interface IModelService<T>
    {
        Task<APIResponse<T>> Create(T item);

        Task<APIResponse<T>> Get(int id);

        Task<APIResponse<IEnumerable<T>>> GetAll();

        Task<APIResponse<IEnumerable<T>>> GetFromParentId(int id);

        Task<APIResponse<T>> Update(int id, T item);

        Task<APIResponse<bool>> Delete(int id);
    }
}
