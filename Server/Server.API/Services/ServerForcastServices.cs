using Server.API.DTO;
using Server.API.Interfaces;
using Server.API.Utils;
using Server.API.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Services
{
    public class ServerForcastServices : IServerForcastServices
    {
        private readonly IGeocodingServices _geocodingServices;
        private readonly IForecastService _forecastService;

        public ServerForcastServices(IGeocodingServices geocodingServices, IForecastService forecastService)
        {
            _forecastService = forecastService;
            _geocodingServices = geocodingServices;
        }


        public async Task<ForecastVIewModel> GetForecastByAddress(string address)
        {
            try
            {
                var (coordinates, city) = await GetCoordinates(address);

                var result = await GetForeCastInfo(coordinates, city);

                result.address = address;

                return result;
            }
            catch (Exception ex)
            {
                throw new ArgumentNullException(nameof(GetForecastByAddress), ex);
            }
        }

        private async Task<(Model.Coordinates, string)> GetCoordinates(string address)
        {
            var geoRequest = new GeocodeRequestDTO() { address = address };
            var geoResult = await _geocodingServices.GetCoordinates(geoRequest);
            if (geoResult is null || geoResult.result is null || !geoResult.result.addressMatches.Any())
                return (null, null);

            return (geoResult.result.addressMatches.FirstOrDefault().coordinates, geoResult.result.addressMatches.FirstOrDefault().addressComponents.city);
        }

        private async Task<ForecastVIewModel> GetForeCastInfo(Model.Coordinates coordinates, string city)
        {
            var headers = new ForecastGridsRequestDTO();
            var gridsResult = await _forecastService.GetGrids(coordinates.y, coordinates.x, headers.Headers);
            var foreCastResult = await _forecastService.GetByGrids(gridsResult.properties.gridY, gridsResult.properties.gridX, headers.Headers);

            return ConvertModelToVIewModel(foreCastResult, city);
        }

        private ForecastVIewModel ConvertModelToVIewModel(ForecastResponseDTO dto, string city)
        {
            var viewModel = new ForecastVIewModel("", city, new List<Forecast>());
            List<Forecast> list = new List<Forecast>();
            for (int i = 0; i < dto.properties.periods.Length; i++)
            {
                var period = dto.properties.periods[i];

                list.Add(new Forecast()
                {
                    id = i,
                    DayName = period.name,
                    Type = period.name.Contains("Night")? "night": "day",
                    Details = period.detailedForecast,
                    IconUrl = period.icon,
                    Temperature = period.temperature,
                    TemperatureUnit = period.temperatureUnit
                });
            }

            viewModel.ListForecast = list;

            return viewModel;

        }

    }
}
