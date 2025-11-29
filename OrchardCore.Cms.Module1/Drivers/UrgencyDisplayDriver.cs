using Microsoft.AspNetCore.Identity;
using OrchardCore.Cms.Module1.Models;
using OrchardCore.Cms.Module1.ViewModels;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCore.Cms.Module1.Drivers
{
    public class UrgencyDisplayDriver : ContentPartDisplayDriver<Urgency>
    {
        public override IDisplayResult Display(Urgency part, BuildPartDisplayContext context) => Initialize<UrgencyViewModel>(
            GetDisplayShapeType(context), viewModel => PopulateViewModel(part, viewModel))
            .Location("Detail", "Content: 5")
            .Location("Summary", "Content: 5");

        public override IDisplayResult Edit(Urgency part, BuildPartEditorContext context) => Initialize<UrgencyViewModel>(
            GetEditorShapeType(context), viewModel => PopulateViewModel(part, viewModel))
            .Location("Content: 5");
        //public override async Task<IDisplayResult> UpdateAsync(Urgency urgency, IUpdateModel updater, UpdatePartEditorContext part)
        //{
        //    var viewModel = new UrgencyViewModel();
        //    await updater.TryUpdateModelAsync(viewModel, Prefix);
        //    urgency.urgencyMeter = viewModel.urgencyMeter;
        //    urgency.Title = viewModel.Title;

        //    return await EditAsync(urgency, part);
        //}

        private static void PopulateViewModel(Urgency urgency, UrgencyViewModel viewModel)
        {
            viewModel.urgencyMeter = urgency.urgencyMeter;
            viewModel.Title = urgency.Title;

        }
    }
}
