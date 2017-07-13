using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.BLL.DTO;

namespace Weather.BLL.Infrastructure
{
    public interface IWeatherService
    {
        Task<ForecastDTO> GetWeatherDaily(string city, int count = 1);
    }
}
