using OrchardCore.Cms.Module1;
using OrchardCore.Cms.Module1.Models;
using OrchardCore.Cms.Module1.Indexing;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
using OrchardCore.ContentManagement.Metadata;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YesSql.Services;
using YesSql.Sql;
using static OrchardCore.Cms.Module1.Models.UrgencyPart;
namespace OrchardCore.Cms.Module1.Migrations
{
    public sealed class UrgencyPartMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public UrgencyPartMigrations(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinitionAsync("Note2", type => type
            .Creatable()
            .Listable()
            .WithPart(nameof(UrgencyPart)));

            _contentDefinitionManager.AlterPartDefinitionAsync("UrgencyPart", part => part
        .WithField("Description", field => field
        .OfType(nameof(TextField))
        .WithDisplayName("UrgencyPart")
        .WithEditor("TextArea")
        ));

            return 1;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterTypeDefinitionAsync("Note2", type => type
            .Creatable()
            .Listable()
            .WithPart(nameof(UrgencyPart)));

            return 2;
        }
        public int UpdateFrom2()
        {
            _contentDefinitionManager.AlterPartDefinitionAsync("UrgencyPart", part => part
        .WithField("Description", field => field
        .OfType(nameof(TextField))
        .WithDisplayName("Urgency")
        .WithEditor("TextArea")
        ));

            return 3;
        }
        public int UpdateFrom3()
        {

            _contentDefinitionManager.AlterTypeDefinitionAsync("Note2", type => type
            .Creatable()
            .Listable()
            .WithPart(nameof(UrgencyPart)));

            _contentDefinitionManager.AlterTypeDefinitionAsync("Urgency Widget", type => type
                .WithPart("UrgencyPart")
                .Stereotype("Widget")      
            );

            return 4;
        }

        public int UpdateFrom4()
        {

            _contentDefinitionManager.AlterPartDefinitionAsync(nameof(UrgencyPart), part => part
        .WithField("Description", field => field
        .OfType(nameof(TextField))
        .WithDisplayName("Urgency")
        .WithEditor("TextArea")
        ));
            return 5;
        }

        public int UpdateFrom5()
        {

            SchemaBuilder.CreateMapIndexTableAsync<UrgencyPartIndex>(table => table
                .Column<string>(nameof(UrgencyPartIndex.Title))
                .Column<int>(nameof(UrgencyPartIndex.UrgencyMeter))
                .Column<string>(nameof(UrgencyPartIndex.ContentItemId), column => column.WithLength(26))
            );

            SchemaBuilder.AlterTableAsync(nameof(UrgencyPartIndex), table => table
                .CreateIndex("IDX_UrgencyPartIndex_UrgencyMeter", "UrgencyMeter")
            );
            return 6;
        }
    }
}
