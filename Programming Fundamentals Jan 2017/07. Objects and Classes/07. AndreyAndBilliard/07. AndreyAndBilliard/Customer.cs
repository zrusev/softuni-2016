namespace _07.AndreyAndBilliard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Customer
    {
        public string CustomerName { get; set; }
        public SortedDictionary<string, decimal> ProductQuantity { get; set; }
        //public List<SortedDictionary<string, decimal>> ListOfOrders { get; set; }
    }
}
