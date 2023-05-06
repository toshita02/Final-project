using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoomsMgmtSystem.Models
{
    public class PayDetail
    {
        [Display(Name = "ID")] 
        public string ID { get; set; }

        [Display(Name = "Customer ID")]
        public string CustID { get; set; }

        [Display(Name = "First Name")] 
        public string FirstName { get; set; }

        [Display(Name = "Last Name")] 
        public string LastName { get; set; }

        [Display(Name = "Email")] 
        public string Email { get; set; }

        [Display(Name = "Phone no.")] 
        public string Phone { get; set; }

        [Display(Name = "Paid Amount")] 
        public string PayAmount { get; set; }

        [Display(Name = "Due Amount")] 
        public string DueAmount { get; set; }
        [Display(Name = "Room Copacity")]
        public string RoomCopacity { get; set; }
        public string Total { get; set; }
    }
}