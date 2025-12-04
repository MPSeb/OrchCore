using OrchardCore.Cms.Module1.Models;
using OrchardCore.ContentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql.Indexes;

namespace OrchardCore.Cms.Module1.Indexing
{
    public class UrgencyPartIndex : MapIndex
    {
        public string ContentItemId { get; set; }

        public string Title { get; set; }
        public int UrgencyMeter { get; set; }


    }

    public class UrgencyPartIndexProvider : IndexProvider<ContentItem>
    {
        public override void Describe(DescribeContext<ContentItem> context) =>
            context.For<UrgencyPartIndex>()
                .When(contentItem => contentItem.Has<UrgencyPart>())
                .Map(contentItem =>
                {
                    var urgencyPart = contentItem.As<UrgencyPart>();

                    return new UrgencyPartIndex
                    {
                        ContentItemId = contentItem.ContentItemId,
                        Title = urgencyPart.Title,
                        UrgencyMeter = urgencyPart.UrgencyMeter
                    };
                });
    }

}
