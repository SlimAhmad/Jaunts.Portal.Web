// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;

namespace Jaunts.Portal.Web.Client.Views.Bases
{
    public partial class GridBase<T> : ComponentBase
    {
        [Parameter]
        public List<T> DataSource { get; set; }

        [Parameter]
        public RenderFragment Columns { get; set; }

        SfGrid<T>? Grid;

        [Parameter]
        public Syncfusion.Blazor.Grids.Action OnClick { get; set; }


        public void ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
        {
            if (args.Item.Id.Contains("excelexport"))
                this.Grid?.ExportToExcelAsync();
            else if (args.Item.Id.Contains($"delete"))
                this.Grid?.DeleteRecordAsync();
            else if (args.Item.Id.Contains($"add"))
                this.Grid?.AddRecordAsync();
        }
    }
}
