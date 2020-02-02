using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoA.Entity
{
    public class Customer
    {
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(500)]
        public string AddressLine1 { get; set; }

        [MaxLength(500)]
        public virtual string AddressLine2 { get; set; }
        
        [MaxLength(100)]
        public virtual string City { get; set; }

        [MaxLength(100)]
        public virtual string Country { get; set; }

        [MaxLength(100)]
        public virtual string State { get; set; }
        
        [MaxLength(10)]
        public virtual string PostalCode { get; set; }
    }
}
