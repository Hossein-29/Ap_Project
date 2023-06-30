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
        [Key]
        [Column(Order = 0)]
        public string SenderAaddress { get; set; }

        [Key]
        [Column(Order = 1)]
        public string ReceiverAddress { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PackageType { get; set; }

        [Key]
        [Column(Order = 3)]
        public double Weight { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PostType { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string CustomerSSN { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ShippingStatus { get; set; }

        public string Comment { get; set; }
    }
}
