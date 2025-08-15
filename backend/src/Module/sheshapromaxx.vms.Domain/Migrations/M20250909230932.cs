using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250909230932)]
    public class M20250909230932 : OneWayMigration
    {
        public override void Up()
        {
            // Just ensure the foreign key constraint is correct
            // Simply delete the OrderId column - this will automatically drop any constraints
            //Delete.Column("OrderId").FromTable("vms_Vouchers");
            Alter.Table("vms_Vouchers")
               .AddForeignKeyColumn("OrderId", "vms_Orders").Nullable();

        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}