using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Kontakt
    {
        public byte Id { get; set; }
        [Required]
        public string Nazwisko { get; set; }
    }
}