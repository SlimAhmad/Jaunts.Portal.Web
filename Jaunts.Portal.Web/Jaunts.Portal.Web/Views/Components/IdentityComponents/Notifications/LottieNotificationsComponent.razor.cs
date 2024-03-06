using Jaunts.Portal.Web.Client.Services.Views.IdentityViews;
using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Views.Components.IdentityComponents.Notifications
{
    public partial class LottieNotificationsComponent
    {
        [Inject]
        public IIdentityViewService IdentityViewService { get; set; }

        [Parameter]
        public string Source { get; set; }

        [Parameter]
        public string Text { get; set; }

        [Parameter]
        public string NavigationUrl { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await Task.Delay(4000);
            NavigateToLoginPage();
        }

        private void NavigateToLoginPage() =>
            IdentityViewService.NavigateTo(NavigationUrl);
    }
}
