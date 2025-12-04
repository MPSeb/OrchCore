using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using OrchardCore.Cms.Module1.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrchardCore.Cms.Module1.Models.UrgencyPart;

namespace OrchardCore.Cms.Module1.ViewModels
{
    public class UrgencyPartViewModel
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UrgencyMeter { get; set; } 

    }
}
