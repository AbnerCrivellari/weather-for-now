using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.API.DTO;

namespace Server.API.ViewModel
{
    public class ForecastVIewModel
    {
        public ForecastVIewModel(string address, string city, IEnumerable<ForecastByDay> listForecastByDay)
        {
            this.address = address;
            City = city;
            ListForecastByDay = listForecastByDay;
        }
        public string address { get; set; }
        public string City { get; set; }
        public IEnumerable<ForecastByDay> ListForecastByDay { get; set; }

        public static implicit operator ForecastVIewModel(ForecastResponseDTO dto)
        {
            var listForecast = new List<Forecast>();
            var listOfDays = new List<ForecastByDay>();
            int count = 0;

            for (int i = 0; i < dto.properties.periods.Length; i++)
            {

                var period = dto.properties.periods[i];

                listForecast.Add(new Forecast(id: i,
                    dayName: period.name,
                    type: period.shortForecast,
                    details: period.detailedForecast,
                    iconUrl: period.icon,
                    temperature: period.temperature,
                    temperatureUnit: period.temperatureUnit, isDay: period.isDaytime));

                if (!period.name.Contains("Tonight")) count++;

                if (count == 2 || period.name.Contains("Tonight"))
                {
                    listOfDays.Add(new ForecastByDay(listForecast));
                    listForecast = new List<Forecast>();
                    count = 0;
                }
            }

            return new ForecastVIewModel("", "", listOfDays);
        }
    }

    public class ForecastByDay
    {
        public ForecastByDay(IEnumerable<Forecast> forecast)
        {
            Forecast = forecast;
        }
        public IEnumerable<Forecast> Forecast { get; set; }
    }

    public class Forecast
    {
        public int id { get; set; }
        public string Type { get; set; }
        public float Temperature { get; set; }
        public string TemperatureUnit { get; set; }
        public string DayName { get; set; }
        public string IconUrl { get; set; }
        public string Details { get; set; }
        public bool IsDay { get; set; }

        public Forecast(int id, string type, float temperature, string temperatureUnit, string dayName, string iconUrl, string details,bool isDay)
        {
            this.id = id;
            Type = type;
            Temperature = temperature;
            TemperatureUnit = temperatureUnit;
            DayName = dayName;
            IconUrl = iconUrl;
            Details = details;
            IsDay = isDay;
        }
    }
}
