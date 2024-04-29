using Infrastructure.Entities;
using Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Factories
{
    public class SubscribeFactory
    {
        public static SubscribeEntity Create(SubscribeModel model)
        {
            try
            {
                return new SubscribeEntity
                {
                    Email = model.Email,
                    DailyNewsLetter = model.DailyNewsLetter,
                    EventUpdates = model.EventUpdates,
                    AdvertisingUpdates = model.AdvertisingUpdates,
                    Podcasts = model.Podcasts,
                    StartupsWeekly = model.StartupsWeekly,
                    WeekInReview = model.WeekInReview,
                    Created = DateTime.Now,
                    Updated = DateTime.Now,

                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
        public static SubscribeEntity Update(SubscribeEntity entity, SubscribeModel model)
        {
            try
            {
                entity.DailyNewsLetter = model.DailyNewsLetter;
                entity.EventUpdates = model.EventUpdates;
                entity.AdvertisingUpdates = model.AdvertisingUpdates;
                entity.Podcasts = model.Podcasts;
                entity.StartupsWeekly = model.StartupsWeekly;
                entity.WeekInReview = model.WeekInReview;
                entity.Updated = DateTime.Now;
                return entity;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
        public static SubscribeModel Create(SubscribeEntity model)
        {
            try
            {
                return new SubscribeModel
                {
                    Email = model.Email,
                    DailyNewsLetter = model.DailyNewsLetter ?? false,
                    EventUpdates = model.EventUpdates ?? false,
                    AdvertisingUpdates = model.AdvertisingUpdates ?? false,
                    Podcasts = model.Podcasts ?? false,
                    StartupsWeekly = model.StartupsWeekly ?? false,
                    WeekInReview = model.WeekInReview ?? false,

                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
        public static IEnumerable<SubscribeEntity> CreateList(IEnumerable<SubscribeModel> models)
        {
            var result = models.Select(x => Create(x)).ToList();
            return result;
        }
    }
}
