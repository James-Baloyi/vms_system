using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250902220930)]
    public class M20250902220930: OneWayMigration
    {
        public override void Up()
        {
            // 1. Add DisabilityDescription column to Core_Persons table (where Farmer data is stored)
            Alter.Table("Core_Persons")
                .AddColumn("vms_DisabilityDescription").AsString(500).Nullable();

            // 2. Add FarmInformationId foreign key to Core_Persons for Farmer → FarmInformation relationship
            Alter.Table("Core_Persons")
                .AddForeignKeyColumn("vms_FarmInformationId", "vms_FarmInformations").Nullable(); // Changed to plural

            // 3. Drop the old FarmerId foreign key from vms_FarmInformations table
            // First drop the index if it exists
            if (Schema.Table("vms_FarmInformations").Index("IX_vms_FarmInformations_FarmerId").Exists())
            {
                Delete.Index("IX_vms_FarmInformations_FarmerId").OnTable("vms_FarmInformations");
            }

            // Drop the foreign key constraint
            Delete.ForeignKey("FK_vms_FarmInformations_FarmerId_Core_Persons_Id")
                .OnTable("vms_FarmInformations");

            // Drop the FarmerId column
            Delete.Column("FarmerId").FromTable("vms_FarmInformations");

        

        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}