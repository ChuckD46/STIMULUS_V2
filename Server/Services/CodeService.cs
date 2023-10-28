using STIMULUS_V2.Server.Services.Interfaces;
using STIMULUS_V2.Shared.Models.DTOs;
using STIMULUS_V2.Shared.Models.Entities;

namespace STIMULUS_V2.Server.Services
{
    public class CodeService : IModelService<Code>
    {
        public Task<APIResponse<Code>> Create(Code item)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<bool>> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<Code>> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<IEnumerable<Code>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<IEnumerable<Code>>> GetFromParentId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<APIResponse<Code>> Update(int id, Code item)
        {
            throw new NotImplementedException();
        }
    }
}
