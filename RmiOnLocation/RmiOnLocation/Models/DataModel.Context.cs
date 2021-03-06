﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
    
        public virtual int sp_CreateVisitor(Nullable<int> id, string firstName, string lastName, string company, string emailAddress, string reasonForVisit, Nullable<System.DateTime> signIn, Nullable<System.DateTime> signOut, Nullable<bool> isEmailed, Nullable<int> employeeId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var companyParameter = company != null ?
                new ObjectParameter("Company", company) :
                new ObjectParameter("Company", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            var reasonForVisitParameter = reasonForVisit != null ?
                new ObjectParameter("ReasonForVisit", reasonForVisit) :
                new ObjectParameter("ReasonForVisit", typeof(string));
    
            var signInParameter = signIn.HasValue ?
                new ObjectParameter("SignIn", signIn) :
                new ObjectParameter("SignIn", typeof(System.DateTime));
    
            var signOutParameter = signOut.HasValue ?
                new ObjectParameter("SignOut", signOut) :
                new ObjectParameter("SignOut", typeof(System.DateTime));
    
            var isEmailedParameter = isEmailed.HasValue ?
                new ObjectParameter("IsEmailed", isEmailed) :
                new ObjectParameter("IsEmailed", typeof(bool));
    
            var employeeIdParameter = employeeId.HasValue ?
                new ObjectParameter("EmployeeId", employeeId) :
                new ObjectParameter("EmployeeId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_CreateVisitor", idParameter, firstNameParameter, lastNameParameter, companyParameter, emailAddressParameter, reasonForVisitParameter, signInParameter, signOutParameter, isEmailedParameter, employeeIdParameter);
        }
    
        public virtual ObjectResult<sp_FindEmployee_Result> sp_FindEmployee(Nullable<int> id, string firstName, string lastName, string emailAddress)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailAddressParameter = emailAddress != null ?
                new ObjectParameter("EmailAddress", emailAddress) :
                new ObjectParameter("EmailAddress", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_FindEmployee_Result>("sp_FindEmployee", idParameter, firstNameParameter, lastNameParameter, emailAddressParameter);
        }
    
        public virtual int sp_SignOut(Nullable<int> id, Nullable<System.DateTime> signOut)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            var signOutParameter = signOut.HasValue ?
                new ObjectParameter("SignOut", signOut) :
                new ObjectParameter("SignOut", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_SignOut", idParameter, signOutParameter);
        }
    }
}
