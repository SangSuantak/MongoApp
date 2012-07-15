using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoApp.Models;

namespace MongoApp.Controllers
{
    public class HomeController : Controller
    {
        DataAccess da;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDepartment(Department objDept) {
            try {
                da = new DataAccess();
                da.CreateDepartment(objDept);
                return Json(new { IsDataInserted = true }, JsonRequestBehavior.AllowGet);
            } 
            catch (Exception ex) {
                return Json(new { IsDataInserted = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult CreateEmployee(Employee objEmp) {
            try {
                da = new DataAccess();
                da.CreateEmployee(objEmp);
                return Json(new { IsDataInserted = true }, JsonRequestBehavior.AllowGet);
            } 
            catch (Exception ex) {
                return Json(new { IsDataInserted = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult FetchDepartments(){
            try {
                da = new DataAccess();
                List<Department> lstDept = da.GetDepartments();
                return Json(new { IsDataFetched = true, obj = lstDept }, JsonRequestBehavior.AllowGet);
            } 
            catch (Exception ex) {
                return Json(new { IsDataFetched = false, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
                
    }
}
