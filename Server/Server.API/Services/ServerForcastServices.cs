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
            ForecastVIewModel result = foreCastResult;
            result.City = city;
            return result;
        }

        //private ForecastVIewModel ConvertModelToVIewModel(ForecastResponseDTO dto, string city)
        //{

        //    var listForecast = new List<Forecast>();
        //    var listOfDays = new List<ForecastByDay>();
        //    int count = 0;

        //    for (int i = 0; i < dto.properties.periods.Length; i++)
        //    {

        //        var period = dto.properties.periods[i];

        //        listForecast.Add(new Forecast(id: i,
        //            dayName: period.name,
        //            type: period.shortForecast,
        //            details: period.detailedForecast,
        //            iconUrl: period.icon,
        //            temperature: period.temperature,
        //            temperatureUnit: period.temperatureUnit));

        //        if(!period.name.Contains("Tonight")) count++;

        //        if (count == 2 || period.name.Contains("Tonight"))
        //        {
        //            listOfDays.Add(new ForecastByDay(listForecast));
        //            listForecast = new List<Forecast>();
        //            count = 0;
        //        }
        //    }

        //    return new ForecastVIewModel("", city, listOfDays);
        //}
    }
}
