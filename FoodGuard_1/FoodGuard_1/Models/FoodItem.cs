using System;
using System.Collections.Generic;
using System.Text;

namespace FoodGuard_1.Models
{
    public class FoodItem
    {
        public string Guid { get; set; }
        public string Name { get; set; }

        //public string Tags { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpiryDate { get; set; }


    }
}
