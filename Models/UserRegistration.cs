using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RoomsMgmtSystem.Models
{
    public class RegistrationDetails
    {
        [Display(Name = "Customer ID")]
        [Required(ErrorMessage = "Please Enter Customer ID.")]
        public string ID { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Please Enter User Name.")]
        public string Name { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "Please Enter First Name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please Enter Last Name.")]
        public string LastName { get; set; } 

        [Display(Name = "City")]
        [Required(ErrorMessage = "Please Enter City.")] 
        public string City { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Please Enter Address.")] 
        public string Address { get; set; }  

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email Id.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Phone no.")]
        [Required(ErrorMessage = "Please Enter Phone no.")]
        public string Phone { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Please Enter Confirm Password.")]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string CPassword { get; set; }

        [Display(Name = "Role")] 
        public String Roles { get; set; } 
    } 
}