using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.Models
{
    public class KartaKontaktu
    {
        public int Id { get; set; }

        public Sklep Sklep { get; set; }

        public int SklepId { get; set; }

        public DateTime DataSpotkania { get; set; }

        public string FormaKontaktu { get; set; }

        public string Notatki { get; set; }
    }
}