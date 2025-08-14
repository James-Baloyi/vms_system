using Abp.Domain.Entities.Auditing;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sheshapromaxx.vms.Domain.Domain.Enums;
using sheshapromaxx.vms.Domain.Domain.Programs;

namespace sheshapromaxx.vms.Domain.Domain.Applications
{

    [Discriminator]
    public class Application: FullAuditedEntity<Guid>
    {
        // <summary>
        /// Stored file associated with the application
        /// </summary>
        [Display(Name = "Stored File")]
        [Description("File associated with the application")]
        public virtual StoredFile? StoredFile { get; set; }

        /// <summary>
        /// Status of the application
        /// </summary>
        [Display(Name = "Status")]
        [Description("Current status of the application")]
        [ReferenceList("sheshapromaxx.vms", "ApplicationStatus")]
        public virtual RefListApplicationStatus Status { get; set; }

        /// <summary>
        /// Start date of the application period
        /// </summary>
        [Display(Name = "Start Date")]
        [Description("Start date of the application period")]
        public virtual DateTime? StartDate { get; set; }

        /// <summary>
        /// End date of the application period
        /// </summary>
        [Display(Name = "End Date")]
        [Description("End date of the application period")]
        public virtual DateTime? EndDate { get; set; }

        /// <summary>
        /// Indicates if the application is flagged as fraudulent
        /// </summary>
        [Display(Name = "Is Fraud")]
        [Description("Indicates if the application is flagged as fraudulent")]
        public virtual bool IsFraud { get; set; }

        /// <summary>
        /// Navigation property to application-program relationships
        /// </summary>
        [Display(Name = "Program Links")]
        [Description("Bridge relationships linking this application to programs")]
        public virtual ICollection<ProgramBridge> ProgramBridges { get; set; }

        /// <summary>
        /// Helper property to get all programs for this application
        /// </summary>
        [Display(Name = "Programs")]
        [Description("All programs associated with this application")]
        public IEnumerable<Program> Programs =>
            ProgramBridges?.Select(pb => pb.Program) ?? new List<Program>();

    }
}
