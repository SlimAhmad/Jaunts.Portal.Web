// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using Jaunts.Portal.Web.Client.Models.Colors;
using Microsoft.AspNetCore.Components;

namespace Jaunts.Portal.Web.Client.Views.Bases
{
    public partial class LabelBase : ComponentBase
    {
        [Parameter]
        public string Value { get; set; }

        [Parameter]
        public Color Color { get; set; }

        public void SetValue(string value)
        {
            this.Value = value;
            InvokeAsync(StateHasChanged);
        }

        public void SetColor(Color color) =>
            this.Color = color;
    }
}
