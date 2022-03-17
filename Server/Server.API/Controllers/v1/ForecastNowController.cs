using Microsoft.AspNetCore.Mvc;
using Server.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.API.ViewModel;

namespace Server.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastNowController : BaseApiController
    {
        private readonly IServerForcastServices _serverForcastServices;
        public ForecastNowController(IServerForcastServices serverForcastServices)
        {
            _serverForcastServices = serverForcastServices;
        }

        [HttpPost("/forecast")]
        public async Task<ActionResult<ForecastVIewModel>> Get([FromBody]RequestViewModel obj)
        {
            try
            {
                if (obj is null || string.IsNullOrEmpty(obj.address)) return BadRequest("The Object cannot be null");

                var result = await _serverForcastServices.GetForecastByAddress(obj.address);
                if(result is null) return NotFound();

                return Ok(result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
