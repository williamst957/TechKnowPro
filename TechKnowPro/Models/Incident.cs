namespace TechKnowPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Incident")]
    public partial class Incident
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Incident()
        {
            Surveys = new HashSet<Survey>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string IncidentNo { get; set; }

        public int CustomerId { get; set; }

        public DateTime ReportTime { get; set; }

        public int? Description { get; set; }

        public string Comments { get; set; }

        public string ContactVia { get; set; }

        public virtual Register Register { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Survey> Surveys { get; set; }
    }
}
