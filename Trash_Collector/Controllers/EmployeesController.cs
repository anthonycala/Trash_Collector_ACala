﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Trash_Collector.Models;

namespace Trash_Collector.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext db;
        public EmployeesController()
        {
            db = new ApplicationDbContext();
        }
        
        // GET: Employees
        //public ActionResult Index(string sortOrder)
        //{
        //    var employees = db.Employees.Include(s => s.ApplicationUser);
        //    ViewBag.zipCodeSortParm = String.IsNullOrEmpty(sortOrder) ? "zipCode_desc" : " ";
        //    switch (sortOrder)
        //    {
        //        case "zipCode_desc":
        //            employees = employees.OrderByDescending(s => s.zipCode);
        //            break;
                    
        //    }
        //    return View(employees.ToList());
        //}
        // GET: Employees
        public ActionResult Index()

        {

            var UserId = User.Identity.GetUserId();
            var Employee = db.Employees.Where(s => s.ApplicationId == UserId).FirstOrDefault();
            var CustomersInDb = db.Customers.Where(s => s.zipCode == Employee.zipCode).ToList();
            string thisDay = DateTime.Today.DayOfWeek.ToString();
            var CustomersDb  = CustomersInDb.Where(s => s.pickupDay == thisDay).ToList();

            return View(CustomersDb);
        }


        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,zipCode,firstName,lastName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ApplicationId = User.Identity.GetUserId();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
            Employee employee = db.Employees.Where(s => s.Id == id).FirstOrDefault();
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,zipCode,firstName,lastName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
            
            Employee employee = db.Employees.Where(s => s.Id == id).FirstOrDefault();
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, Employee employee)
        {
            try
            {
                employee = db.Employees.Find(id);
                db.Employees.Remove(employee);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View(id);
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
