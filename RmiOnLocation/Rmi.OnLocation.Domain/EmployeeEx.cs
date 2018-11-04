using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Rmi.OnLocation.Domain {
	public class Employee : v_Employees {
		private Employee(v_Employees e) {
			base.EmployeeId = e.EmployeeId;
			base.Department = e.Department;
			base.Division = e.Department;
			base.Email = e.Email;
			base.Enabled = e.Enabled;
			base.FirstName = e.FirstName;
			base.LastName = e.LastName;
			base.UpdatedTime = e.UpdatedTime;
			base.UserId = e.UserId;
			base.Title = e.Title;
			base.MemberOf = e.MemberOf;
		}

		public static List<Employee> Employees {
			get {
				using (Entities context = new Entities()) {
					return context.v_Employees.OrderBy(e => e.LastName).AsEnumerable().Select(e => new Employee(e)).ToList();
				}
			}
		}

		public static Employee Find(int employeeId) {
			return Employee.Employees.FirstOrDefault(e => e.EmployeeId == employeeId);
		}

		public static IEnumerable<SelectListItem> EmployeeDropDown {
			get {
				IList<SelectListItem> _dropdown = new List<SelectListItem>();
				_dropdown.Add(new SelectListItem() {
					Value = null,
					Text = "Who are you visiting?",
					Selected = true
				});

				List<Employee> list = Employee.Employees;
				foreach (var emp in list) {
					_dropdown.Add(new SelectListItem() {
						Value = emp.EmployeeId.ToString(),
						Text = string.Format("{0}, {1}", emp.LastName, emp.FirstName)
					});
				}
				return _dropdown;
			}
		}
	}
}
