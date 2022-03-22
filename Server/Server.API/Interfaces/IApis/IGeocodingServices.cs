using Refit;
using Server.API.DTO;
using Server.API.Model;
using System.Threading.Tasks;

namespace Server.API.Interfaces
{
    public interface IGeocodingServices
    {
        [Get("/geocoder/locations/onelineaddress")]
        Task<GeoCodeResponseDTO> GetCoordinates([Query]GeocodeRequestDTO param);
    }
}
