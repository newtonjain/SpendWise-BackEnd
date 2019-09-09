using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationDashboardMVC.DataAccess.Entitites
{
    public class DailyPredictiveItem : IEntity
    {
        //public DailyPredictiveItem()
        //{
        //    OrderDetails = new List<OrderDetails>();
        //}
        public int ID { get; set; }
        public string ItemName { get; set; }
        public decimal AmountSpend { get; set; }
        public string Suggestion { get; set; }
        public string ItemImage { get; internal set; }
        public string ItemCategory { get; internal set; }
        
        //public virtual ICollection<OrderDetails> OrderDetails { get; set; }

    }
}