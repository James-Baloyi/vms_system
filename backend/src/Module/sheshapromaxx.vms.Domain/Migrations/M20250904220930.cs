using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250904220930)]
    public class M20250904220930 : OneWayMigration
    {
        public override void Up()
        {

            // This links Application to Farmer (Core_Persons table where Farmer data is stored)
            Alter.Table("vms_Applications")
                .AddForeignKeyColumn("FarmerId", "Core_Persons").Nullable();


        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}