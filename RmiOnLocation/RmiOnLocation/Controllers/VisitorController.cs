using RmiOnLocation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Net;
using System.Data.SqlClient;
using Rmi.OnLocation.Domain;
using System.Data;

namespace RmiOnLocation.Controllers
{
    public class VisitorController : Controller
    {
        // GET: Visitor
		[HttpGet]
		public ActionResult Index(int id = 0) {
			return View(new Visitor());
		}
        // GET: Thank You
        [HttpGet]
        public ActionResult ThankYou(Visitor visitor){
            return View();
        }


        [HttpGet]
		public PartialViewResult SignOutList(Visitor visitor) {
			return PartialView("_VisitorList", Visitor.SignedInVisitors);
		}

		[HttpPost]
		public JsonResult SignOut(int Id) {
			if (Visitor.SetSignOutTime(Id)) {
				return new JsonResult() {
					Data = new { Success = true }
				};
			}
			return new JsonResult() {
				Data = new { Success = false }
			};
		}
		
		[HttpPost]
		public ActionResult SubmitInfo(FormModel model, Visitor visitor) {
			if (visitor.FirstName != null && visitor.LastName != null && visitor.ReasonForVisit != null && visitor.SignIn != null && visitor.EmployeeId != 0) {
				visitor.SaveVisitor();
                Employee emp = Employee.Find(visitor.EmployeeId);
                Session["VisitorFirstName"] = visitor.FirstName;
                Session["EmployeeFirstName"] = emp.FirstName;
                return new JsonResult() {
					Data = model,
					MaxJsonLength = int.MaxValue,
				};
			}
			return View();
		}
    }
}