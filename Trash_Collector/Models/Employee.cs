using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public int zipCode { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }


    }
}

