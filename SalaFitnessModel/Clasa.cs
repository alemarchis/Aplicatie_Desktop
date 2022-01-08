namespace SalaFitnessModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Clasa")]
    public partial class Clasa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clasa()
        {
            Antrenors = new HashSet<Antrenor>();
        }

        public int ClasaId { get; set; }

        [StringLength(50)]
        public string Nume { get; set; }

        public string Ora_incepere { get; set; }

        public string Durata { get; set; }

        [StringLength(50)]
        public string Program { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Antrenor> Antrenors { get; set; }
    }
}
