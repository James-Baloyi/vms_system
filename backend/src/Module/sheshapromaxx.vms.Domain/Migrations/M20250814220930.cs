using System;
using FluentMigrator;
using Shesha.FluentMigrator;
using Shesha.Domain;

namespace sheshapromaxx.vms.Domain.Migrations
{
    [Migration(20250814220930)]
    public class M20250814220930 : OneWayMigration
    {
        public override void Up()
        {

            // Create Products table
            Create.Table("vms_Products")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithDiscriminator()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Price").AsDouble().Nullable();

            // Add foreign key to Category (using AddForeignKeyColumn pattern)
            Alter.Table("vms_Products").AddForeignKeyColumn("CategoryId", "vms_Categories").Nullable();

            // Create Vouchers table
            Create.Table("vms_Vouchers")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithDiscriminator()
                .WithColumn("VoucherRef").AsString(100).Nullable()
                .WithColumn("Status").AsInt64().Nullable()
                .WithColumn("ExpiryDate").AsDateTime().Nullable()
                .WithColumn("Amount").AsDouble().Nullable()
                .WithColumn("PaymentStatusRef").AsInt64().Nullable()
                .WithColumn("CurrentAmount").AsDouble().Nullable();

            // Add foreign key columns for Voucher (using AddForeignKeyColumn pattern)
            Alter.Table("vms_Vouchers").AddForeignKeyColumn("ApplicationId", "vms_Applications").Nullable();



            // Create Suppliers table
            Create.Table("vms_Suppliers")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithDiscriminator()
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Coordinates").AsString(100).Nullable()
                .WithColumn("Address").AsString(500).Nullable()
                .WithColumn("PhoneNumber").AsString(20).Nullable()
                .WithColumn("Email").AsString(255).Nullable();

            // Create SupplierProgramBridge table
            Create.Table("vms_SupplierProgramBridges")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithDiscriminator();

            // Add foreign key columns for SupplierProgramBridge (using AddForeignKeyColumn pattern)
            Alter.Table("vms_SupplierProgramBridges").AddForeignKeyColumn("SupplierId", "vms_Suppliers").Nullable();
            Alter.Table("vms_SupplierProgramBridges").AddForeignKeyColumn("ProgramId", "vms_Programs").Nullable();

            // Create unique constraint to prevent duplicate supplier-program relationships
            Create.UniqueConstraint("UQ_vms_SupplierProgramBridges_SupplierId_ProgramId")
                .OnTable("vms_SupplierProgramBridges")
                .Columns("SupplierId", "ProgramId");





            // Create VoucherSupplierBridge table
            Create.Table("vms_VoucherSupplierBridges")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithDiscriminator();

            // Add foreign key columns for VoucherSupplierBridge
            Alter.Table("vms_VoucherSupplierBridges").AddForeignKeyColumn("VoucherId", "vms_Vouchers").Nullable();
            Alter.Table("vms_VoucherSupplierBridges").AddForeignKeyColumn("SupplierId", "vms_Suppliers").Nullable();

            // Add after VoucherSupplierBridge creation:
            Create.UniqueConstraint("UQ_vms_VoucherSupplierBridges_VoucherId_SupplierId")
                .OnTable("vms_VoucherSupplierBridges")
                .Columns("VoucherId", "SupplierId");


            // Create Orders table
            Create.Table("vms_Orders")
                .WithIdAsGuid()
                .WithFullAuditColumns()
                .WithDiscriminator()
                .WithColumn("OrderTypeLkp").AsInt64().Nullable()
                .WithColumn("Cost").AsDouble().Nullable()
                .WithColumn("CreatedAt").AsDateTime().Nullable()
                .WithColumn("DeliveryDate").AsDateTime().Nullable()
                .WithColumn("TrackStatusLkp").AsInt64().Nullable()
                .WithColumn("OrderRef").AsString(100).Nullable()
                .WithColumn("DeliveryNotes").AsString(int.MaxValue).Nullable();

            // Add foreign key columns (using AddForeignKeyColumn pattern)
            Alter.Table("vms_Orders").AddForeignKeyColumn("ProductId", "vms_Products").Nullable();
            Alter.Table("vms_Orders").AddForeignKeyColumn("VoucherId", "vms_Vouchers").Nullable();
            Alter.Table("vms_Orders").AddForeignKeyColumn("ImplementorId", "Core_Persons").Nullable();


        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}