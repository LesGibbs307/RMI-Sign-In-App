using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace ClassLibrary1 {
	public partial class Employee {
		public static Employee Find(int employeeId) {
			using (Entities context = new Entities()) {
				return context.Employees.Where(e => e.Id == employeeId).SingleOrDefault();
			}
		}

		public static IEnumerable<SelectListItem> EmployeeDropDown {
			get {
				IList<SelectListItem> _dropdown = new List<SelectListItem>();
				_dropdown.Add(new SelectListItem() {
					Value = null,
					Text = "Who are you visiting?",
					Selected = true
				});
				using (Entities context = new Entities()) {
					IList<Employee> list = (from e in context.Employees
											orderby e.LastName
											select e).ToList();

					foreach (var emp in list) {
						_dropdown.Add(new SelectListItem() {
							Value = emp.Id.ToString(),
							Text = string.Format("{0}, {1}", emp.LastName, emp.FirstName)
						});
					}
				}
				return _dropdown;
			}
		}
	}

    //class EmployeeEx: IList<Employee>
    //{
    //    public EmployeeEx getList(string FirstName, string LastName){
    //        Employee Employee;
    //        using (Entities context = new Entities())
    //        {
    //            Employee = context.sp_FindEmployee(this.Id, this.FirstName, this.LastName, this.EmailAddress).Single();
    //        }

    //    }
    //}
}
