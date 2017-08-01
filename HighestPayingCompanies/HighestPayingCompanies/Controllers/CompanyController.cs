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
    public class CompanyController : Controller
    {
        private Repository repo;

        public CompanyController()
        {
            this.repo = new Repository();
        }

        // GET: Company
        public ActionResult Index()
        {
            return View(repo.GetCompanies());
        }

        // GET: Company/Details/5
        public ActionResult Details(int id)
        {
            Company company = repo.GetCompanyByID(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyId,Name")] Company company)
        {
            if (ModelState.IsValid)
            {
                repo.InsertCompany(company);
                repo.Save();
                return RedirectToAction("Index");
            }

            return View(company);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int id)
        {
            Company company = repo.GetCompanyByID(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyId,Name")] Company company)
        {
            try {
                if (ModelState.IsValid)
                {
                    repo.UpdateCompany(company);
                    repo.Save();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name after DataException and add a line here to write a log.
                ModelState.AddModelError(string.Empty, "Unable to save changes. Try again, and if the problem persists contact your system administrator.");
            }
            return View(company);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int id)
        {
            Company company = repo.GetCompanyByID(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = repo.GetCompanyByID(id);
            repo.DeleteCompany(company.CompanyId);
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