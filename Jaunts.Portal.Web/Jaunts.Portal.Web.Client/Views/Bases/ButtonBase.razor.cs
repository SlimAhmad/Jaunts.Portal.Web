// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Client.Views.Bases
{
    public partial class ButtonBase : ComponentBase
    {
        [Parameter]
        public string Label { get; set; }

		[Parameter]
		public bool IsVisible { get; set; }

		[Parameter]
        public string CssClass { get; set; }

        [Parameter]
        public Action OnClick { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        public void Click() => OnClick.Invoke();

        public void Disable()
        {
            this.IsDisabled = true;
            InvokeAsync(StateHasChanged);
        }

        public void Enable()
        {
            this.IsDisabled = false;
            InvokeAsync(StateHasChanged);
        }

		public void Show()
		{
			IsVisible = true;
			InvokeAsync(StateHasChanged);
		}

		public void Hide()
		{
			IsVisible = false;
			InvokeAsync(StateHasChanged);
		}
	}
}
