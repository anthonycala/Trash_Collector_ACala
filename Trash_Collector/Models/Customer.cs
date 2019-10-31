using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Display (Name = "First Name")]
        public string firstName { get; set; }

        [Display(Name = "Last Name")]
        public string lastName { get; set; }

        [Display(Name = "Street Address")]
        public string streetAddress { get; set; }

        [Display(Name = "City")]
        public string city { get; set; }

        [Display(Name = "State")]
        public string state { get; set; }

        [Display(Name = "Zip Code")]
        public int zipCode { get; set; }

        [Display(Name = "Pickup Day")]
        public string pickupDay { get; set; }

        public enum DayOfTheWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday,
   
        }

        [Display(Name = "Balance Due")]
        public int balance { get; set; }

        [Display(Name = "Monthly Bill")]
        public int monthlyCharge { get; set; }

        [Display(Name = "Pickup Confirmed")]
        public bool pickupConfirmed { get; set; }

        [Display(Name = "Start Date Scheduled")]
        public bool start { get; set; }

        [Display(Name = "Start Date")]
        public DateTime startDate { get; set; }

        [Display(Name = "End Date Scheduled")]
        public bool end { get; set; }

        [Display(Name = "End Date")]
        public DateTime endDate { get; set; }

        [Display(Name = "Extra Pickup")]
        public bool extraPickUp { get; set; }

        [Display(Name = "Extra Pickup Date")]
        public DateTime extraPickUpDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        












    }
}