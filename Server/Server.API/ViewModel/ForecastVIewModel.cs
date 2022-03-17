using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.API.DTO;

namespace Server.API.ViewModel
{
    public class ForecastVIewModel
    {
        public ForecastVIewModel(string address, string city, IEnumerable<Forecast> listForecast)
        {
            this.address = address;
            City = city;
            ListForecast = listForecast;
        }
        public string address { get; set; }
        public string City { get; set; }
        public IEnumerable<Forecast> ListForecast { get; set; }

        //public static implicit operator ForecastVIewModel(ForecastResponseDTO dto)
        //{
        //    return new ForecastVIewModel("","", )
        //}
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
    }
}
