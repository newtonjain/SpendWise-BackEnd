using ApplicationDashboardMVC.DataAccess.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationDashboardMVC.DataAccess.Configurations
{
    public class DailyPredictiveItemConfiguration : EntityConfiguration<DailyPredictiveItem>
    {
        public DailyPredictiveItemConfiguration()
        {
            Property(p => p.ItemName).IsRequired().HasMaxLength(100);
            Property(p => p.AmountSpend).IsRequired();
            Property(p => p.ItemImage).IsRequired().HasMaxLength(100);
            Property(p => p.Suggestion).IsRequired();
            Property(p => p.ItemCategory).IsRequired();
        }
    }
}