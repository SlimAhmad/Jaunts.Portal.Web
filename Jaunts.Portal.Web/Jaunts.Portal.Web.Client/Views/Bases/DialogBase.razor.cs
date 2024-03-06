﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE TO CONNECT THE WORLD
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Popups;

namespace Jaunts.Portal.Web.Client.Views.Bases
{
    public partial class DialogBase : ComponentBase
    {        
        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public bool IsVisible { get; set; }

        [Parameter]
        public string Width { get; set; }

        [Parameter]
        public RenderFragment Content { get; set; }

        [Parameter]
        public string ButtonTitle { get; set; }

        [Parameter]
        public Delegation OnClick { get; set; }

        public DialogButton DialogButton {get; set;}
        public bool IsDialogButtonDisabled { get; set; }
        public delegate ValueTask Delegation();

        public void Click() => OnClick?.Invoke();

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

        public void EnableButton()
        {
            IsDialogButtonDisabled = false;
            InvokeAsync(StateHasChanged);
        }

        public void DisableButton()
        {
            IsDialogButtonDisabled = true;
            InvokeAsync(StateHasChanged);
        }
    }
}
