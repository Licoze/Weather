using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Models
{
    public class SearchHistoryViewModel
{
    public int Id { get; set; }
    public List<ForecastViewModel> Results { get; set; }

}
}