using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NewGridSystem.Models;
using System.Data.Entity;

namespace NewGridSystem.Controllers
{
    public class JqgridController : Controller
    {
        // GET: Jqgrid
        public ActionResult Index()
        {
            return View();
        }
        ContextClass db = new ContextClass();
        public JsonResult GetValues(string sidx, string sord, int page, int rows) //Gets the todo Lists.  
        {
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;
            var Results = db.NewCustomers.Select(
                a => new
                {
                    a.Id,
                    a.Name,
                    a.Address,
                    a.Gender,
                    a.Phone,
                    a.Email,
                });
            int totalRecords = Results.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sord.ToUpper() == "DESC")
            {
                Results = Results.OrderByDescending(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                Results = Results.OrderBy(s => s.Id);
                Results = Results.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = Results
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        // TODO:insert a new row to the grid logic here  
        [HttpPost]
        public string Create([Bind(Exclude = "Id")] NewCustomer obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    obj.Id = Guid.NewGuid().ToString();
                    db.NewCustomers.Add(obj);
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Edit(NewCustomer obj)
        {
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Saved Successfully";
                }
                else
                {
                    msg = "Validation data not successfull";
                }
            }
            catch (Exception ex)
            {
                msg = "Error occured:" + ex.Message;
            }
            return msg;
        }
        public string Delete(string Id)
        {
            NewCustomer list = db.NewCustomers.Find(Id);
            db.NewCustomers.Remove(list);
            db.SaveChanges();
            return "Deleted successfully";


        }
    }
}