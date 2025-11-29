using OrchardCore.ContentFields.Fields;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrchardCore.Cms.Module1.Models.Urgency;

namespace OrchardCore.Cms.Module1.ViewModels
{
    internal class UrgencyViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public UrgencyMeter urgencyMeter { get; set; }
    }
}
