using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.API.ViewModel;

namespace Server.API.Interfaces
{
    public interface IServerForcastServices
    {
        Task<ForecastVIewModel> GetForecastByAddress(string address);
    }
}
