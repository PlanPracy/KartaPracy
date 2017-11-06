using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Kontakt
    {
        [Key]
        public byte Id { get; set; }
        [Required]
        public string Nazwisko { get; set; }

        public string OsobaDoKontaktu { get; set; }

        public string Telefon { get; set; }

        public string Email { get; set; }

        public string Opis { get; set; }

    }
}