// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Client.Brokers.Navigations
{
    public class NavigationBroker : INavigationBroker
    {
        private readonly NavigationManager navigationManager;

        public NavigationBroker(NavigationManager navigationManager) =>
            this.navigationManager = navigationManager;

        public void NavigateTo(string route) =>
            this.navigationManager.NavigateTo(route);
    }
}
