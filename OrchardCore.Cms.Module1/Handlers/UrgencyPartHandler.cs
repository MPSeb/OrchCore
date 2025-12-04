using OrchardCore.Cms.Module1.Drivers;
using OrchardCore.Cms.Module1.Models;
using OrchardCore.ContentManagement.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCore.Cms.Module1.Handlers
{
    public class UrgencyPartHandler : ContentPartHandler<UrgencyPart>
    {

        public override Task LoadedAsync(LoadContentContext context, UrgencyPart part)
        {
            part.UpdatedAt = DateTime.UtcNow;
            return Task.CompletedTask;
        }
    }
}
