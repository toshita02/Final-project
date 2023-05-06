using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomsMgmtSystem.Models
{
    public class BillPayment
    {
        [Display(Name = "Bill Month :")]
        public string Month { get; set; }

        [Display(Name = "Bill Year :")]
        public string Year { get; set; }

        [Display(Name = "Bill Amount :")] 
        public string Amount { get; set; }

        [Display(Name = "End Date :")]
        public DateTime EndDate { get; set; }

    }
}