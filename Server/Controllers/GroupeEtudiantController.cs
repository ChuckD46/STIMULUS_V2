using Microsoft.AspNetCore.Mvc;
using STIMULUS_V2.Shared.Interface.ChildInterface;

namespace STIMULUS_V2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupeEtudiantController : Controller
    {
        private readonly IGroupeEtudiantService groupeEtudiantService;

        public GroupeEtudiantController(IGroupeEtudiantService groupeEtudiantService)
        {
            this.groupeEtudiantService = groupeEtudiantService;
        }

        [HttpGet("Fetch/All/GroupForStudent/{id}")]
        public async Task<IActionResult> GetAllGroupForStudent(string id)
        {
            var response = await groupeEtudiantService.GetAllGroupForStudent(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}
