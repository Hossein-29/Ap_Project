namespace DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string SSN { get; set; }

        [Key]
        [Column(Order = 3)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string Phone { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Password { get; set; }

        [Key]
        [Column(Order = 7)]
        public double AccountBalance { get; set; }
    }
}
