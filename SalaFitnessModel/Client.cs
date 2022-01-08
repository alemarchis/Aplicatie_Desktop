namespace SalaFitnessModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        public int ClientId { get; set; }

        public string Nume { get; set; }

        public string Prenume { get; set; }

        [Column("Numar_telefon")]
        public string Numar_telefon { get; set; }

        public int? AbonamentId { get; set; }

        public virtual Abonament Abonament { get; set; }
    }
}
