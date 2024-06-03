using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class GetAllStatisticsDto
    {
        public int count { get; set; }
        public decimal price { get; set; }
        public string name { get; set; }
        public string brandAndModel { get; set; }
        public string title { get; set; }
    }
}
