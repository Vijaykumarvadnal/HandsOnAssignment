using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HoA.Entity
{
    public class Order
    {
        [Key]
        [Column(Order = 1)]
        public int ID { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public string CustomerId { get; set; }
    }
}
