using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250901220930)]
    public class M20250901220930 : OneWayMigration
    {
        public override void Up()
        {
            // Step 1: Drop the index first
            Delete.Index("IX_vms_ProgramBridges_CategoryId").OnTable("vms_ProgramBridges");

            // Step 2: Drop the foreign key constraint
            Delete.ForeignKey("FK_vms_ProgramBridges_CategoryId_vms_Categories_Id").OnTable("vms_ProgramBridges");

            // Step 3: Drop the unique constraint if it exists
            if (Schema.Table("vms_ProgramBridges").Constraint("UQ_vms_ProgramBridges_CategoryId_ProgramId").Exists())
            {
                Delete.UniqueConstraint("UQ_vms_ProgramBridges_CategoryId_ProgramId")
                    .FromTable("vms_ProgramBridges");
            }

            // Step 4: Now we can safely drop the column
            Delete.Column("CategoryId").FromTable("vms_ProgramBridges");

            // Step 5: Add the new ApplicationId foreign key column
            Alter.Table("vms_ProgramBridges").AddForeignKeyColumn("ApplicationId", "vms_Applications").Nullable();

            // Step 6: Add unique constraint for the new relationship
            Create.UniqueConstraint("UQ_vms_ProgramBridges_ApplicationId_ProgramId")
                .OnTable("vms_ProgramBridges")
                .Columns("ApplicationId", "ProgramId");
        

    }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}