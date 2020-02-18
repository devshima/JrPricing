using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JrPricingWebApplication.Models
{
    public class PricingParameter
    {
        [Display(Name ="出発")]
        public string departure { get; set; }
        [Display(Name = "到着")]
        public string destination { get; set; }
        [Display(Name = "車種")]
        public string superExpressName { get; set; }
        [Display(Name = "座席")]
        public string seatName { get; set; }
        [Display(Name = "券種")]
        public string fareName { get; set; }
        [Display(Name = "片道/往復")]
        public string tripName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "乗車日")]
        public DateTime boardingDate { get; set; }
        [Display(Name = "旅行人数")]
        public int numberOfPeopleValue { get; set; };
    }
}
