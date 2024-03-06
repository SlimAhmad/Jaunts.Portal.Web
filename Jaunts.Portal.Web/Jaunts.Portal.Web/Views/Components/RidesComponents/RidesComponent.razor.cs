// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.RideViews;
using Jaunts.Portal.Web.Client.Models.Views.Components.RidesComponents;
using Jaunts.Portal.Web.Client.Services.Views.RideViews;
using Jaunts.Portal.Web.Client.Views.Bases;
using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Views.Components.RidesComponents
{
    public partial class RidesComponent : ComponentBase
    {
        [Inject]
        public IRideViewService RideViewService { get; set; }

        public RidesComponentState State { get; set; }
        public List<RideView> RideViews { get; set; }
        public GridBase<RideView> Grid { get; set; }
        public string ErrorMessage { get; set; }
        public LabelBase ErrorLabel { get; set; }

        protected async override Task OnInitializedAsync()
        {
            try
            {
                this.RideViews =
                    await this.RideViewService.RetrieveAllRideViewsAsync();

                this.State = RidesComponentState.Content;
            }
            catch (Exception exception)
            {
                this.ErrorMessage = exception.Message;
                this.State = RidesComponentState.Error;
            }
        }
    }
}
