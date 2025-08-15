using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250909230930)]
    public class M20250909230930 : OneWayMigration
    {
        public override void Up()
        {

            if (Schema.Table("vms_Vouchers").Column("OrderId").Exists())
            {
                // Drop any existing foreign key constraint first
                Execute.Sql(@"
            IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_vms_Vouchers_OrderId_vms_Vouchers_Id')
                ALTER TABLE vms_Vouchers DROP CONSTRAINT FK_vms_Vouchers_OrderId_vms_Vouchers_Id
        ");

                Delete.Column("OrderId").FromTable("vms_Vouchers");
            }

            // Add the correct OrderId foreign key column to reference Orders table
            Alter.Table("vms_Vouchers")
                .AddForeignKeyColumn("OrderId", "vms_Orders").Nullable();

            Alter.Table("vms_Vouchers").AddColumn("IsRedeem").AsBoolean().Nullable();

        }


    public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}