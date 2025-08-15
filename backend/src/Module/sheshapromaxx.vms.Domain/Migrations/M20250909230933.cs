using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250909230933)]
    public class M20250909230933 : OneWayMigration
    {
        public override void Up()
        {
           
    
            // Rename Status to StatusLkp
            Rename.Column("Status").OnTable("vms_Vouchers").To("StatusLkp");
            // Rename PaymentStatusRef to PaymentStatusRefLkp  
            Rename.Column("PaymentStatusRef").OnTable("vms_Vouchers").To("PaymentStatusRefLkp");
        

    }

    public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}