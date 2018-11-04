using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class VisitorEx : Visitor {
		Visitor visitor;
		public void SaveVisitor() {
			using (Entities context = new Entities()) {
				visitor = context.sp_UpdateVisitor(this.Id, this.FirstName, this.LastName, this.Company, this.EmailAddress, this.ReasonForVisit, this.IsEmailed, this.EmployeeId).Single();
			}
			if (visitor.EmployeeId > 0 && visitor.SignOut == null) {
				Employee emp = Employee.Find(visitor.EmployeeId);
				if (emp != null) {
					Utilities.SendEmail(new EmialInfo() {
						From = Settings.VisitorFromEmail,
						To = emp.EmailAddress,
						Subject = "You have a visitor!",
						Body = string.Format(@"
Hello {0},<br/><br/>

{1} {2} from {3} is at the front lobby to meet with you.<br/><br/>

Their resaon for visiting is to {4}.<br/><br/>

Thank you,<br/>
RMI Receptionist
", emp.FirstName, visitor.FirstName, visitor.LastName, visitor.Company, visitor.ReasonForVisit)
					});
				}
			}
			this.Id = visitor.Id;
			this.EmployeeId = visitor.EmployeeId;
			this.IsEmailed = visitor.IsEmailed;
			this.SignIn = visitor.SignIn;
			this.SignOut = visitor.SignOut;
		}
		//public static IList<Visitor> GetUsers {
		//	get {
		//		//var _visitorList = context			
		//	}
		//}
    }
}
