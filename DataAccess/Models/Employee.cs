namespace DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
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
        public string PersonalID { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string UserName { get; set; }

        [Key]
        [Column(Order = 4)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
