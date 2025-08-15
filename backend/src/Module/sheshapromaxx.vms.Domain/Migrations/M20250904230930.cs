using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250904230930)]
    public class M20250904230930: OneWayMigration
    {
        public override void Up()
        {

      
            Alter.Table("vms_Applications")
                .AddForeignKeyColumn("ProgramId", "vms_Programs").Nullable();

   
            Alter.Table("vms_Vouchers")
                .AddForeignKeyColumn("OrderId", "vms_Vouchers").Nullable();

            
            Alter.Table("vms_Categories")
                .AddForeignKeyColumn("CommodityId", "vms_Commodities").Nullable();

       
           
            Alter.Table("vms_Suppliers")
                .AddForeignKeyColumn("VoucherId", "vms_Vouchers").Nullable();

            Alter.Table("vms_Orders").AddColumn("Quantity").AsInt64().Nullable();


        }

    public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}