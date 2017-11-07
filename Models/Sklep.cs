using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web.Mvc;

    public class Sklep
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }


        public Kontakt Kontakt { get; set; }

        public byte KontaktId { get; set; }

        public FormatSklepu FormatSklepu { get; set; }
        public byte FormatSklepuId { get; set; }

        public string Nip { get; set; }
    }
}