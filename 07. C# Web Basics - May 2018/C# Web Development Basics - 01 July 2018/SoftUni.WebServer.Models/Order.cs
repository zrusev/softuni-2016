namespace SoftUni.WebServer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Order
    {        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Product Product { get; set; }

        public User Client { get; set; }

        public DateTime OrderedOn { get; set; }

        public ICollection<ProductOrder> ProductNavigation { get; set; }
    }
}
