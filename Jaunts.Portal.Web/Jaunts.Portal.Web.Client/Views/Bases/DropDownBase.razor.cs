// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;

namespace Jaunts.Portal.Web.Client.Views.Bases
{
	public partial class DropDownBase<TEnum> : ComponentBase
    {
        [Parameter]
        public TEnum Value { get; set; }

		[Parameter]
		public string PlaceHolder { get; set; }

		[Parameter]
        public EventCallback<TEnum> ValueChanged { get; set; }

        [Parameter]
        public bool IsDisabled { get; set; }

        public bool IsEnabled => IsDisabled is false;

        public IReadOnlyList<string> EnumNames => Enum.GetNames(typeof(TEnum));

        public async Task SetValue(TEnum value)
        {
            this.Value = value;
            await ValueChanged.InvokeAsync(this.Value);
        }

        private async Task OnValueChanged(
            ChangeEventArgs<TEnum, string> changeEventArgs)
        {
            await SetValue(changeEventArgs.Value);
        }

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
    }
}
