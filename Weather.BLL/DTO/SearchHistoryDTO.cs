using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Weather.BLL.DTO
{
    public class SearchHistoryDTO
    {
        public int Id { get; set; }
        public List<ForecastDTO> Results { get; set; }
    }
}
