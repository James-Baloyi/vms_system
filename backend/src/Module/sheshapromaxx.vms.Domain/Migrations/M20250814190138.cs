using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250814190138)]
    public class M20250814190138 : OneWayMigration
    {
        public override void Up()
        {
            // Add columns for Farmer entity to Core_Persons table
            Alter.Table("Core_Persons")
                .AddColumn("vms_SAId").AsString().Nullable()
                .AddColumn("vms_PassportId").AsString().Nullable()
                .AddColumn("vms_Disability").AsBoolean().WithDefaultValue(false)
                .AddColumn("vms_GovernmentEmployee").AsBoolean().WithDefaultValue(false)
                .AddColumn("vms_Dweller").AsBoolean().WithDefaultValue(false)
                .AddColumn("vms_Veteran").AsBoolean().WithDefaultValue(false)
                .AddColumn("vms_ServiceFee").AsDouble().Nullable();
        }

    }

}