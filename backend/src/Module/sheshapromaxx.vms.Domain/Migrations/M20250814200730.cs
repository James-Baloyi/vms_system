using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250814200730)]
    public class M20250814200730 : OneWayMigration
    {
        public override void Up()
        {
            Create.Table("vms_FarmInformations")
               .WithIdAsGuid()
               .WithFullAuditColumns()
               .WithDiscriminator()
               .WithColumn("FarmSize").AsDouble().Nullable()
               .WithColumn("ProductionSize").AsDouble().Nullable();

            // Add foreign key columns
            Alter.Table("vms_FarmInformations").AddForeignKeyColumn("CommodityId", "vms_Commodities").Nullable();
            Alter.Table("vms_FarmInformations").AddForeignKeyColumn("FarmerId", "Core_Persons").Nullable();
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}