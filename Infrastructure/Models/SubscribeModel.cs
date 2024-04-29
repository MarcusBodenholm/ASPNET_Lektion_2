using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Models
{
    public class SubscribeModel
    {
        public string Email { get; set; } = null!;
        public bool? DailyNewsLetter { get; set; }
        public bool? AdvertisingUpdates { get; set; }
        public bool? EventUpdates { get; set; }
        public bool? WeekInReview { get; set; }
        public bool? StartupsWeekly { get; set; }
        public bool? Podcasts { get; set; }

    }
}
