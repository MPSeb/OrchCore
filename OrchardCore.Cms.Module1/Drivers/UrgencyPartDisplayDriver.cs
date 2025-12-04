using Microsoft.AspNetCore.Identity;
using OrchardCore.Cms.Module1.Models;
using OrchardCore.Cms.Module1.ViewModels;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement.Display.ContentDisplay;
using OrchardCore.ContentManagement.Display.Models;
using OrchardCore.DisplayManagement.ModelBinding;
using OrchardCore.DisplayManagement.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCore.Cms.Module1.Drivers
{
    public class UrgencyPartDisplayDriver : ContentPartDisplayDriver<UrgencyPart>
    {
        public override IDisplayResult Display(UrgencyPart part, BuildPartDisplayContext context)
        {
            return Initialize<UrgencyPartViewModel>(GetDisplayShapeType(context), viewModel => PopulateViewModel(part, viewModel))
                .Location("Detail", "Content:5")
                .Location("Summary", "Content:5");
        }

        public override IDisplayResult Edit(UrgencyPart part, BuildPartEditorContext context)
        {
            return Initialize<UrgencyPartViewModel>(GetEditorShapeType(context), viewModel => PopulateViewModel(part, viewModel));
        }

        public override async Task<IDisplayResult> UpdateAsync(UrgencyPart part, UpdatePartEditorContext context)
        {
            var model = new UrgencyPartViewModel();

            if (await context.Updater.TryUpdateModelAsync(model, Prefix))
            {
                part.Title = model.Title;
                part.Description = model.Description;
                part.UrgencyMeter = model.UrgencyMeter;
                part.UpdatedAt = model.UpdatedAt;
            }

            return Edit(part, context);
        }

        private static void PopulateViewModel(UrgencyPart urgency, UrgencyPartViewModel viewModel)
        {
            viewModel.UrgencyMeter = urgency.UrgencyMeter;
            viewModel.Title = urgency.Title;
            viewModel.Description = urgency.Description;
            viewModel.UpdatedAt = urgency.UpdatedAt;
        }
    }
}
