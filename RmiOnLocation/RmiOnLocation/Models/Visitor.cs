//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RmiOnLocation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Visitor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string EmailAddress { get; set; }
        public string ReasonForVisit { get; set; }
        public System.DateTime SignIn { get; set; }
        public Nullable<System.DateTime> SignOut { get; set; }
        public Nullable<bool> IsEmailed { get; set; }
        public int EmployeeId { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}