using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CatWool.Models
{
    public class Order
    { 
        public byte Id { get; set; }
        public byte CustomerId { get; set; }
        public DateTime DateTime { get; set; }
    }
}