using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250814200630)]
    public class M20250814200630 : OneWayMigration
    {
        public override void Up()
        {
            Create.Table("vms_Commodities")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithDiscriminator()
                .WithColumn("CommodityName").AsString().Nullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}