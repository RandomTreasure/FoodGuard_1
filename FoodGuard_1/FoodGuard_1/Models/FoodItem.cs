using System;

namespace FoodGuard_1.Models
{
    public class FoodItem
    {
        //[PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        //public string Tags { get; set; }

        public int Buy { get; set; }

      //  public DateTime ExpiryDate { get; set; }

        public int Exp { get; set; }


    }
}
