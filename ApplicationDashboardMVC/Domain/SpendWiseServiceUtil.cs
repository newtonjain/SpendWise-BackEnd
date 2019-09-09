using ApplicationDashboardMVC.Models;
using ResourceModel;
using System;
using System.Collections.Generic;

namespace SpendWise.Domain
{
    public static class SpendWiseServiceUtil
    {
        public static List<ResourceModel.PredictiveItem> GetPredictiveItem()
        {
            return SpendWiseServices.Utils.ServiceUtils.GetPredictiveItem("abcd");
        }

        public static List<ResourceModel.PredictiveForecast> GetPredictiveForecast()
        {
            return SpendWiseServices.Utils.ServiceUtils.GetPredictiveForecast("1");
        }

        public static string GetPredictiveSavings()
        {
            return SpendWiseServices.Utils.ServiceUtils.GetPredictiveSavings("1");
        }

        public static List<DailyPredictiveViewModel> GetDailyPredictiveItems()
        {
            var model = new List<DailyPredictiveViewModel>();

            var responseDailyPredictiveItem =  SpendWiseServices.Utils.ServiceUtils.GetDailyPredictiveItems("1");


            foreach(PredictiveItem item in responseDailyPredictiveItem)
            {
                model.Add(new DailyPredictiveViewModel
                    {
                    AmountSpend = item.ItemAmount,
                    ItemCategory = item.ItemCategory,
                    ItemID = item.ItemID,
                    ItemName = item.ItemName,
                    ItemImage = GetItemImage(item)
                    
                });
            }
            return model;
        }

        private static string GetItemImage(PredictiveItem item)
        {
            var imageNumber = string.Empty;
            switch (item.ItemCategory)
            { 
                case "Meals":
                    imageNumber = "1";
                    break;
                case "Transportation":
                    imageNumber = "2";
                    break;
                case "Shopping":
                    imageNumber ="3";
                    break;
                case "Entertainment":
                    imageNumber = "4";
                    break;
                default:
                    imageNumber = "5";
                    break;
            }

            return imageNumber;
        }
    }
}