using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomsMgmtSystem.Models
{
    public class RoomDetails
    {
        public string ID { get; set; }         
        public string RoomType { get; set; }         
        public string RoomCopacity { get; set; }
        public string Image { get; set; }
        [Display(Name = "Rant ")]
        public string Rent { get; set; }
        [Display(Name = "Electricity Bill")]
        public string Electricity  { get; set; }
        [Display(Name = "Water Supply Bill")]
        public string WaterSupply  { get; set; }
        [Display(Name = "Total Rent")]
        public string Total  { get; set; }
    }
}