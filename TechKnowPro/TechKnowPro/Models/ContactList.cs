namespace TechKnowPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContactList")]
    public partial class ContactList
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int UserId { get; set; }

        public virtual Register Register { get; set; }
    }
}
