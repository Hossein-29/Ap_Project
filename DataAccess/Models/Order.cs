namespace DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Required]
        public string SenderAddress { get; set; }

        [Required]
        public string ReceiverAddress { get; set; }

        public int PackageType { get; set; }

        public double Weight { get; set; }

        public int PostType { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerSSN { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        public int ShippingStatus { get; set; }

        public string Comment { get; set; }
    }
}
