using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace Weather.DAL.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public virtual IList<Forecast> Results { get; set; }
        public SearchHistory()
        {
            Results=new List<Forecast>();
            

        }
    }
}