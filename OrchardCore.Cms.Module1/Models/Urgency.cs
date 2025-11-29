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
    public class Urgency : ContentPart
    {
        public string Title { get; set; }
        public TextField Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public UrgencyMeter urgencyMeter { get; set; }
        public enum UrgencyMeter
        {
            Low = 0, Medium = 1, High = 2
        }

    }
}
