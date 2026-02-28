using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using IBS.Models.Integrated;

namespace IBS.Models
{
    public class SalesLockedRecordsQueue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateOnly LockedDate { get; set; }

        public int DeliveryReceiptId { get; set; }

        [ForeignKey(nameof(DeliveryReceiptId))]
        public DeliveryReceipt DeliveryReceipt { get; set; }

        [Column(TypeName = "numeric(18,4)")]
        public decimal Quantity { get; set; }

        [Column(TypeName = "numeric(18,4)")]
        public decimal Price { get; set; }

    }
}
