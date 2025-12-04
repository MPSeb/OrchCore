using Microsoft.VisualBasic.FileIO;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrchardCore.Cms.Module1.Models
{
    public class UrgencyPart : ContentPart
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int UrgencyMeter { get; set; }

    }
}
