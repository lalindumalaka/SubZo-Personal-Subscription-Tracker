using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SubTrack.Domain.Enums;

namespace SubTrack.Domain.Entities
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        [Required, MaxLength(10)]
        public string Currency { get; set; } = "LKR";

        [Required]
        public BillingCycle BillingCycle { get; set; }

        [Required]
        public DateTime FirstPaymentDate { get; set; }

        [Required]
        public DateTime NextBillingDate { get; set; }

        [Required]
        public Guid CategoryId { get; set; }
        public SubscriptionCategory Category { get; set; }

        [Required]
        public string UserId { get; set; }
        // Navigation property for Identity User (to be defined in Infrastructure)
    }
} 