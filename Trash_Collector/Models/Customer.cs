using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipCode { get; set; }
        public string pickupDay { get; set; }
        public int balance { get; set; }
        public int monthlyCharge { get; set; }
        public bool pickupConfirmed { get; set; }
        public bool start { get; set; }
        public int startDate { get; set; }
        public bool end { get; set; }
        public int endDate { get; set; }
        public bool extraPickUp { get; set; }
        public int extraPickUpDate { get; set; }












    }
}