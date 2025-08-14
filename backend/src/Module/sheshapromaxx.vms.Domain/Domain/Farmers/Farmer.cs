using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using Abp.Auditing;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System.ComponentModel;


namespace sheshapromaxx.vms.Domain.Farmers
{
    /// <summary>
    /// Represents a farmer in the system
    /// </summary>
    [Discriminator]
    public class Farmer : Person
    {
        [Display(Name = "SA ID")]
        [Description("South African Identity Number")]
        public virtual string SAId { get; set; }

        /// <summary>
        /// Passport identification number
        /// </summary>
        [Display(Name = "Passport ID")]
        [Description("Passport identification number")]
        public virtual string PassportId { get; set; }

        /// <summary>
        /// Indicates if the farmer has a disability
        /// </summary>
        [Display(Name = "Has Disability")]
        [Description("Indicates if the farmer has a disability")]
        public virtual bool Disability { get; set; }

        /// <summary>
        /// Indicates if the farmer is a government employee
        /// </summary>
        [Display(Name = "Government Employee")]
        [Description("Indicates if the farmer is a government employee")]
        public virtual bool GovernmentEmployee { get; set; }

        /// <summary>
        /// Indicates if the farmer is a dweller
        /// </summary>
        [Display(Name = "Is Dweller")]
        [Description("Indicates if the farmer is a dweller")]
        public virtual bool Dweller { get; set; }

        /// <summary>
        /// Indicates if the farmer is a veteran
        /// </summary>
        [Display(Name = "Is Veteran")]
        [Description("Indicates if the farmer is a veteran")]
        public virtual bool Veteran { get; set; }
    }
}