using Microsoft.AspNetCore.Mvc;
using Server.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.API.Utils;
using Server.API.ViewModel;

namespace Server.API.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForecastController : BaseApiController
    {
        private readonly IServerForcastServices _serverForcastServices;
        public ForecastController(IServerForcastServices serverForcastServices)
        {
            _serverForcastServices = serverForcastServices;
        }

        [HttpGet("/forecast")]
        public async Task<ActionResult<ForecastVIewModel>> Get([FromQuery]string address)
        {
            try
            {
                if (string.IsNullOrEmpty(address)) return BadRequest("The Object cannot be null");

                var result = await _serverForcastServices.GetForecastByAddress(address);
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
