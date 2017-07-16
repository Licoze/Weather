using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.BLL.DTO;

namespace Weather.BLL.Interfaces
{
    public interface IHistoryService
    {
        Task<int> SaveToHistory( ForecastDTO forecastDto,int userId=0);
        List<SearchHistoryDTO> GetHistory();

    }
}
