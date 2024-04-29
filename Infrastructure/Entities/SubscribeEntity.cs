using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entities
{
    public class SubscribeEntity
    {
        [Key]
        public string Email { get; set; } = null!;
        public bool? DailyNewsLetter { get; set; }
        public bool? AdvertisingUpdates { get; set; }
        public bool? EventUpdates { get; set; }
        public bool? WeekInReview { get; set; }
        public bool? StartupsWeekly { get; set; }
        public bool? Podcasts { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }

    }
}
