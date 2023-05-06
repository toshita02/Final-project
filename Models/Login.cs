using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RoomsMgmtSystem.Models
{
    public class Login
    {
            [Display(Name = "User Name :")]
            [Required(ErrorMessage = "User Name is required.")]
            public string userName { get; set; }

            [Display(Name = "Password :")]
            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            public string password { get; set; }
    }
}