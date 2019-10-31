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
    public class CustomersController : Controller
    {
        ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }


        // GET: Customers
        public ActionResult Index(string sortOrder)
        {
            var customers = db.Customers.Include(s => s.ApplicationUser);
            ViewBag.zipCodeSortParm = String.IsNullOrEmpty(sortOrder) ? "zipCode_desc" : " ";
            ViewBag.pickupDaySortPam = sortOrder == "pickupDay" ? "pickupDay_desc" : "pickupDay";
            switch (sortOrder)
            {
                case "zipCode_desc":
                    customers = customers.OrderByDescending(s => s.zipCode);
                    break;
                case "pickupDay_desc":
                    customers = customers.OrderByDescending(s => s.pickupDay);
                    break;
                
            }
            
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int id)
        {
            var customers = db.Customers.Include(s => s.ApplicationUser).SingleOrDefault(s => s.Id == id);
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer customer)
        {
            try
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            catch
            {
                return View();

            }

        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = db.Customers.Where(s => s.Id == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Customer customer)
        {
            try
            {
                var dbcustomer = db.Customers.Single(s => s.Id == customer.Id);
                dbcustomer.firstName = customer.firstName;
                dbcustomer.lastName = customer.lastName;
                dbcustomer.streetAddress = customer.streetAddress;
                dbcustomer.city = customer.city;
                dbcustomer.state = customer.state;
                dbcustomer.zipCode = customer.zipCode;
                dbcustomer.pickupDay = customer.pickupDay;
                dbcustomer.balance = customer.balance;
                dbcustomer.monthlyCharge = customer.monthlyCharge;
                dbcustomer.pickupConfirmed = customer.pickupConfirmed;
                dbcustomer.start = customer.start;
                dbcustomer.startDate = customer.startDate;
                dbcustomer.end = customer.end;
                dbcustomer.endDate = customer.endDate;
                dbcustomer.extraPickUp = customer.extraPickUp;
                dbcustomer.extraPickUpDate = customer.extraPickUpDate;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int id)
        {
            Customer customer =  db.Customers.Where(s => s.Id == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Customer customer)
        {
            try
            {
                customer = db.Customers.Where(s => s.Id == id).FirstOrDefault();
                db.Customers.Remove(customer);
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
