using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.ViewModels
{
    using Models;

    public class KartaKontaktuViewModel
    {
        public IEnumerable<Sklep> Skleps { get; set; }
        public KartaKontaktu KartaKontaktu { get; set; }

        public IEnumerable<Kontakt> Kontakts { get; set; } 

        public string Tytul
        {
            get
            {
                if (KartaKontaktu != null && KartaKontaktu.Id != 0)
                    return "Edytuj dane o zdarzeniu";
                return "Dodaj nowe zdarzenie";
            }
        }
    }
}