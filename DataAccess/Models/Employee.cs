namespace DataAccess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Net.Http.Headers;

    [Table("Employee")]
    public partial class Employee
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Key]
        [StringLength(50)]
        public string PersonalID { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
