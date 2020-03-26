namespace TechKnowPro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Register")]
    public partial class Register
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Register()
        {
            ContactLists = new HashSet<ContactList>();
            Incidents = new HashSet<Incident>();
        }

        public int Id { get; set; }

        [StringLength(100)]
        public string ProfileName { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public DateTime? JoinDate { get; set; }

        [StringLength(256)]
        public string Email { get; set; }

        public string Password { get; set; }

        [StringLength(50)]
        public string Position { get; set; }

        public string PhoneNumber { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        public int? UserLevel { get; set; }

        [StringLength(50)]
        public string Image { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(50)]
        public string Answer { get; set; }

        public int? SecurityQuestionId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactList> ContactLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Incident> Incidents { get; set; }

        public virtual SecurityQuestion SecurityQuestion { get; set; }
    }
}
