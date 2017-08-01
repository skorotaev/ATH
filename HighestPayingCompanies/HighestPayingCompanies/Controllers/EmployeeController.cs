using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HighestPayingCompanies.Models;
using HighestPayingCompanies.Models.Repository;

namespace HighestPayingCompanies.Controllers
{
    public class EmployeeController : Controller
    {
        private Repository repo;

        public EmployeeController()
        {
            this.repo = new Repository();
        }

        // GET: Employee
        public ActionResult Index()
        {
            return View(repo.GetEmployees().ToList());
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee employee = repo.GetEmployeeByID(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(repo.GetCompanies(), "CompanyId", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,Name,Salary,CompanyId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                repo.InsertEmployee(employee);
                repo.Save();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(repo.GetCompanies(), "CompanyId", "Name", employee.CompanyId);
            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = repo.GetEmployeeByID(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(repo.GetCompanies(), "CompanyId", "Name", employee.CompanyId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,Name,Salary,CompanyId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                repo.UpdateEmployee(employee);
                repo.Save();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(repo.GetCompanies(), "CompanyId", "Name", employee.CompanyId);
            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            Employee employee = repo.GetEmployeeByID(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = repo.GetEmployeeByID(id);
            repo.DeleteEmployee(employee.EmployeeId);
            repo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
