namespace TechKnowPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Survey")]
    public partial class Survey
    {
        public int Id { get; set; }

        public int IncidentId { get; set; }

        public int? CustomerId { get; set; }

        public string ResponseTime { get; set; }

        public string Technician { get; set; }

        public string ProblemRes { get; set; }

        public string Comments { get; set; }

        public string ContactVia { get; set; }

        public int QusetionId { get; set; }

        [StringLength(50)]
        public string Answer { get; set; }

        public virtual Incident Incident { get; set; }
    }
}
