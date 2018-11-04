using Rmi.OnLocation.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace RmiOnLocation.Models {
    public class FormModel {
        [Required(ErrorMessage = "First Name is a required field")]
        [DataType(DataType.Text)]
        [Display(Order = 1, Name = "First Name")]
        [RegularExpression("^((?!^First Name$)[a-zA-Z /.'])+$", ErrorMessage = "First name is required and must be properly formatted.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is a required field")]
        [DataType(DataType.Text)]
        [Display(Order = 2, Name = "Last Name")]
        [RegularExpression("^((?!^First Name$)[a-zA-Z /.'])+$", ErrorMessage = "First name is required and must be properly formatted.")]
        public string LastName { get; set; }

        [DataType(DataType.Text)]
        [Display(Order = 3, Name = "Company")]
        public string Company { get; set; }

        [DataType(DataType.Text)]
        [Display(Order = 4, Name = "Email Address")]
        [RegularExpression("^[A-Za-z0-9._%+-]*@[A-Za-z0-9.-]*\\.[A-Za-z0-9-]{2,}$")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Reason for Visit is a required field")]
        [DataType(DataType.Text)]
        [Display(Order = 5, Name = "Reason for Visit")]
        public string ReasonForVisit { get; set; }

        public DateTime SignIn { get; set; }
        public DateTime SignOut { get; set; }
        public int IsEmailed { get; set; }
        public int EmployeeId { get; set; }
    }
}