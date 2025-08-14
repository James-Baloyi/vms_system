using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250814200930)]
    public class M20250814200930 : OneWayMigration
    {
        public override void Up()
        {

            // 1. Create base tables first (no dependencies)

            // Categories table
            Create.Table("vms_Categories")
              .WithIdAsGuid()
              .WithFullAuditColumns()
              .WithDiscriminator()
              .WithColumn("Name").AsString(255).NotNullable()
              .WithColumn("Description").AsString(int.MaxValue).Nullable();

            // Programs table
            Create.Table("vms_Programs")
              .WithIdAsGuid()
              .WithFullAuditColumns()
              .WithDiscriminator()
             .WithColumn("Name").AsString(255).NotNullable()
             .WithColumn("Description").AsString(int.MaxValue).Nullable();

            // Applications table
            Create.Table("vms_Applications")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithDiscriminator()
                .WithColumn("StatusLkp").AsInt64().Nullable()
                .WithColumn("StartDate").AsDateTime().Nullable()
                .WithColumn("EndDate").AsDateTime().Nullable()
                .WithColumn("IsFraud").AsBoolean().WithDefaultValue(false);

            // Add foreign key to StoredFiles (assuming Frwk_StoredFiles already exists)
            Alter.Table("vms_Applications").AddForeignKeyColumn("StoredFileId", "Frwk_StoredFiles").Nullable();

            // 2. Create bridge tables after base tables exist

            // CommodityCategory bridge
            Create.Table("vms_CommodityCategoryBridges")
               .WithIdAsGuid()
               .WithFullAuditColumns()
               .WithDiscriminator();

            // Add foreign key columns for CommodityCategory bridge
            Alter.Table("vms_CommodityCategoryBridges").AddForeignKeyColumn("CommodityId", "vms_Commodities").Nullable();
            Alter.Table("vms_CommodityCategoryBridges").AddForeignKeyColumn("CategoryId", "vms_Categories").Nullable();

            // Application bridge
            Create.Table("vms_ApplicationBridges")
              .WithIdAsGuid()
              .WithFullAuditColumns()
              .WithDiscriminator();

            // Add foreign key columns for Application bridge
            Alter.Table("vms_ApplicationBridges").AddForeignKeyColumn("ApplicationId", "vms_Applications").Nullable();
            Alter.Table("vms_ApplicationBridges").AddForeignKeyColumn("ProgramId", "vms_Programs").Nullable();

            // Program bridge
            Create.Table("vms_ProgramBridges")
              .WithIdAsGuid()
              .WithFullAuditColumns()
              .WithDiscriminator();

            // Add foreign key columns for Program bridge
            Alter.Table("vms_ProgramBridges").AddForeignKeyColumn("CategoryId", "vms_Categories").Nullable();
            Alter.Table("vms_ProgramBridges").AddForeignKeyColumn("ProgramId", "vms_Programs").Nullable();

            // 3. Optional: Add unique constraints to prevent duplicate relationships
            Create.UniqueConstraint("UQ_vms_CommodityCategoryBridges_CommodityId_CategoryId")
                .OnTable("vms_CommodityCategoryBridges")
                .Columns("CommodityId", "CategoryId");

            Create.UniqueConstraint("UQ_vms_ApplicationBridges_ApplicationId_ProgramId")
                .OnTable("vms_ApplicationBridges")
                .Columns("ApplicationId", "ProgramId");

            Create.UniqueConstraint("UQ_vms_ProgramBridges_CategoryId_ProgramId")
                .OnTable("vms_ProgramBridges")
                .Columns("CategoryId", "ProgramId");

        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}