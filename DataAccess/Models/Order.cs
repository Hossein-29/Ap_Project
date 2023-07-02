namespace DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public class Order
    {
        [Required]
        public string SenderAddress { get; set; }

        [Required]
        public string ReceiverAddress { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int PackageType { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        public int PostType { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerSSN { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Required]
        public int ShippingStatus { get; set; }

        public string Comment { get; set; }

        [Required]
        public int FinalPrice { get; set; }

        [Required]
        public int HasExpensiveContent { get; set; }
    }
}
