namespace SalaFitnessModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Antrenor")]
    public partial class Antrenor
    {
        public int AntrenorId { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        [Column("Numar_telefon")]
        public string Numar_telefon { get; set; }

        public int? ClasaId { get; set; }

        public virtual Clasa Clasa { get; set; }
    }
}
