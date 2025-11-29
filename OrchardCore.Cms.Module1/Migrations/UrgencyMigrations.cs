using OrchardCore.ContentManagement.Metadata;
using OrchardCore.Data.Migration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrchardCore.Cms.Module1;
using OrchardCore.ContentManagement.Metadata.Settings;
using OrchardCore.Cms.Module1.Models;
using OrchardCore.ContentFields.Fields;
using OrchardCore.ContentFields.Settings;
namespace OrchardCore.Cms.Module1.Migrations
{
    internal class UrgencyMigrations : DataMigration
    {
        private readonly IContentDefinitionManager _contentDefinitionManager;

        public UrgencyMigrations(IContentDefinitionManager contentDefinitionManager) => _contentDefinitionManager = contentDefinitionManager;

        public int Create()
        {
            _contentDefinitionManager.AlterTypeDefinitionAsync("Note2", type => type
            .Creatable()
            .Listable()
            .WithPart(nameof(Urgency)));


            _contentDefinitionManager.AlterPartDefinitionAsync("Urgency", part => part.Attachable()
            .WithField(nameof(Urgency.Description), field => field.OfType(nameof(TextField))
            .WithDisplayName("Urgency")
            .WithSettings(new TextFieldSettings
            {
                Hint = "Why is it urgent. XD"
            }
            ).WithEditor("TextArea")));

            return 1;
        }

        public int UpdateFrom1()
        {
            _contentDefinitionManager.AlterTypeDefinitionAsync("Note2", type => type
            .Creatable()
            .Listable()
            .WithPart(nameof(Urgency)));

            _contentDefinitionManager.AlterPartDefinitionAsync("Urgency", part => part
                .WithField("Description", field => field
                    .OfType(nameof(TextField))
                    .WithDisplayName("Urgency")
                    .WithSettings(new TextFieldSettings
                    {
                        Hint = "New hint text here"
                    })
                    .WithEditor("TextArea")
                ));

            return 2;
        }
    }
}
