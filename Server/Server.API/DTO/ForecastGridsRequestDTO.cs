using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.DTO
{
    public class ForecastGridsRequestDTO
    {
        public Dictionary<string,string> Headers { get; private set; }

        public ForecastGridsRequestDTO()
        {
            setValues();
        }
        private void setValues()
        {
            string guid = Guid.NewGuid().ToString();
            this.Headers = new Dictionary<string, string>();
            this.Headers.Add("X-Correlation-Id", guid);
            this.Headers.Add("X-Request-Id", guid);
            this.Headers.Add("X-Server-Id", guid);
            this.Headers.Add("User-Agent", guid);
        }
    }
}
