using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SubTrack.Domain.Entities
{
    public class SubscriptionCategory
    {
        [Key]
        public Guid Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Subscription> Subscriptions { get; set; }
    }
} 