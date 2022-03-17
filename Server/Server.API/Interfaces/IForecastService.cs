using Refit;
using Server.API.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Interfaces
{
    public interface IForecastService
    {
        [Get("/gridpoints/AKQ/{x},{y}/forecast")]
        Task<ForecastResponseDTO> GetByGrids([AliasAs("x")] int x, [AliasAs("y")] int y, [HeaderCollection] IDictionary<string, string> headers);

        [Get("/points/{x},{y}")]
        Task<ForecastGridResponse> GetGrids([AliasAs("x")] float x, [AliasAs("y")] float y, [HeaderCollection] IDictionary<string, string> headers);
    }
}
