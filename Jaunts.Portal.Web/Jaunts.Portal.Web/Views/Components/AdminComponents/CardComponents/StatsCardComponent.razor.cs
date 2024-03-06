using Microsoft.AspNetCore.Components;
using Newtonsoft.Json.Linq;

namespace Jaunts.Portal.Web.Views.Components.AdminComponents.CardComponents
{
    public partial class StatsCardComponent : ComponentBase
    {

        public List<CardInfo> Info { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            Info = new List<CardInfo> 
            {
                new CardInfo
                {
                    Title = "Total Customer",
                    Percentage = "+2.40%",
                    Value = "1,234",
                    Status = "up",
                    Icon = "r",
                },
                new CardInfo
                {
                    Title = "Total Dish Ordered",
                    Percentage = "-12.40%",
                    Value = "23,456",
                    Status = "down",
                    Icon = "r",
                },
                new CardInfo
                {
                    Title = "Total Revenue",
                    Percentage = "+32.40%",
                    Value = "$10,243.00",
                    Status = "up",
                    Icon = "r",
                },
                new CardInfo
                {
                    Title = "Total Investment",
                    Percentage = "+42.40%",
                    Value = "$20,243.00",
                    Status = "up",
                    Icon = "r",
                }
            };
        }



        public class CardInfo
        {
            public string Title { get; set; }
            public string Percentage { get; set; }
            public string Value { get; set; }
            public string Status { get; set; }
            public string Icon { get; set; }
        }
    }
}
