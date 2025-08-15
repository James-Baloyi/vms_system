using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250909230931)]
    public class M20250909230931 : OneWayMigration
    {
        public override void Up()
        {
            // Use a much simpler approach - drop everything by name
            Execute.Sql(@"
        -- Drop the specific index
        IF EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_vms_Vouchers_OrderId')
            DROP INDEX IX_vms_Vouchers_OrderId ON vms_Vouchers;
        
        -- Drop known foreign key constraints (adjust names as needed)
        IF EXISTS (SELECT * FROM sys.foreign_keys WHERE name = 'FK_vms_Vouchers_OrderId_vms_Vouchers_Id')
            ALTER TABLE vms_Vouchers DROP CONSTRAINT FK_vms_Vouchers_OrderId_vms_Vouchers_Id;
            
        -- Drop the column directly
        IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'vms_Vouchers' AND COLUMN_NAME = 'OrderId')
        BEGIN
            -- Drop any default constraint first
            DECLARE @sql NVARCHAR(MAX) = '';
            SELECT @sql = 'ALTER TABLE vms_Vouchers DROP CONSTRAINT ' + dc.name
            FROM sys.default_constraints dc
            INNER JOIN sys.columns c ON dc.parent_column_id = c.column_id
            INNER JOIN sys.objects o ON dc.parent_object_id = o.object_id
            WHERE o.name = 'vms_Vouchers' AND c.name = 'OrderId';
            
            IF @sql != ''
                EXEC sp_executesql @sql;
                
            -- Now drop the column
            ALTER TABLE vms_Vouchers DROP COLUMN OrderId;
        END
    ");

            // Add the correct columns
            if (!Schema.Table("vms_Vouchers").Column("OrderId").Exists())
            {
                Alter.Table("vms_Vouchers")
                    .AddForeignKeyColumn("OrderId", "vms_Orders").Nullable();
            }

            if (!Schema.Table("vms_Vouchers").Column("IsRedeem").Exists())
            {
                Alter.Table("vms_Vouchers").AddColumn("IsRedeem").AsBoolean().Nullable();
            }
        }

        public override void Down()
        {
            if (Schema.Table("vms_Vouchers").Column("IsRedeem").Exists())
                Delete.Column("IsRedeem").FromTable("vms_Vouchers");

            if (Schema.Table("vms_Vouchers").Column("OrderId").Exists())
                Delete.Column("OrderId").FromTable("vms_Vouchers");
        }
    }
}