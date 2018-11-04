using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmi.OnLocation.Domain {
	public partial class Visitor {
		Visitor visitor;

		public static bool SetSignOutTime(int Id) {
			using (Entities context = new Entities()) {
				//DateTime endDate = new DateTime();
				//int Hour = 20;
				//if(DateTime.Now > endDate.P) {

				//}
				return context.sp_SignOut(Id) == 1;
			}
		}

		public void SaveVisitor() {
			using (Entities context = new Entities()) {
				visitor = context.sp_UpdateVisitor(this.Id, this.FirstName, this.LastName, this.Company, this.EmailAddress, this.ReasonForVisit, this.IsEmailed, this.EmployeeId).Single();
			}
			if (visitor.EmployeeId > 0 && visitor.SignOut == null) {
				Employee emp = Employee.Find(visitor.EmployeeId);
				if (emp != null) {
					Utilities.SendEmail(new EmialInfo() {
						From = Settings.VisitorFromEmail,
						To = emp.Email,
						Subject = "You have a visitor!",
						Body = visitor.Company != "Not Set" ?  string.Format(@"
Hello {0},<br/><br/>

{1} {2} from {3} is at the front lobby to meet with you.<br/><br/>

Their reason for visiting is to {4}.<br/><br/>

Thank you,<br/>
RMI Receptionist
", emp.FirstName, visitor.FirstName, visitor.LastName, visitor.Company, visitor.ReasonForVisit) :

 string.Format(@"
Hello {0},<br/><br/>

{1} {2} is at the front lobby to meet with you.<br/><br/>

Their reason for visiting is to {3}.<br/><br/>

Thank you,<br/>
RMI Receptionist
", emp.FirstName, visitor.FirstName, visitor.LastName, visitor.ReasonForVisit)
					});
				}
			}
			this.Id = visitor.Id;
			this.EmployeeId = visitor.EmployeeId;
			this.IsEmailed = visitor.IsEmailed;
			this.SignIn = visitor.SignIn;
			this.SignOut = visitor.SignOut;
		}

		public string ListText {
			get { return string.Format("{1}, {0} - {2}", this.FirstName, this.LastName, this.SignIn.ToString("M/d/yyyy h:mm tt")); }
		}

		//public string DialogName {
		//	get { return string.Format("{1}, {0}", this.FirstName, this.LastName }
		//}
		public static List<Visitor> SignedInVisitors {
			get {
				DateTime now = DateTime.Now.AddDays(-6);
				using (Entities db = new Entities()) {
					return db.Visitors.Where(v => DbFunctions.TruncateTime(v.SignIn).Value >= now.Date && v.SignOut == null).OrderByDescending(v => v.SignIn).ToList();
				}
			}

		}

		public static Visitor GetVisitorById(int visitorId) {
			using (Entities db = new Entities()) {
				return db.Visitors.SingleOrDefault(v => v.Id == visitorId);
			}
		}
	}
}
