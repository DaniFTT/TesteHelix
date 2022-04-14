using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using HelixIntegrationApi;
using HelixIntegrationApi.Model.Entities;

namespace TesteHelix.Controllers
{

    [ApiController]
    [Route("api/[controller]/")]
    [Produces("application/json")]
    public class HelixController : ControllerBase
    {
        private readonly IntegrationHelix _integrationHelix;
        public HelixController()
        {
            var api = new HelixApi();
            _integrationHelix = new IntegrationHelix(api);
        }

        [HttpPost("CreateEntity")]
        public async Task<IActionResult> CreateEntity(PontoDeSensoriamento pontoDeSensoriamentoModel)
        {
            var response = await _integrationHelix.CreateEntity(pontoDeSensoriamentoModel);

            return Ok(response);
        }

        [HttpGet("GetEntityById/{entityId}")]
        public async Task<IActionResult> GetEntityById(string entityId)
        {
            var response = await _integrationHelix.GetEntityById<PontoDeSensoriamento>(entityId);
            if (response != null)
                return Ok(response);

            return NotFound();
        }

        [HttpGet("List")]
        public async Task<IActionResult> List()
        {
            return Ok(await _integrationHelix.ListEntities<PontoDeSensoriamento>());
        }
    }
}
