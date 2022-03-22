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

        //public static implicit operator ForecastVIewModel(ForecastResponseDTO dto)
        //{
        //    return new ForecastVIewModel("","", )
        //}
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

        public Forecast(int id, string type, float temperature, string temperatureUnit, string dayName, string iconUrl, string details)
        {
            this.id = id;
            Type = type;
            Temperature = temperature;
            TemperatureUnit = temperatureUnit;
            DayName = dayName;
            IconUrl = iconUrl;
            Details = details;
        }
    }
}
