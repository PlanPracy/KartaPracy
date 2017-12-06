using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.ViewModels
{
    using Models;
    using System.Web.Mvc;
    using Repozytorium.Models;

    public class SklepViewModel
    {
        

        public IEnumerable<Kontakt> Kontakts { get; set; }
        public IEnumerable<FormatSklepu> FormatSklepus { get; set; } 
     
        public Sklep Sklep { get; set; }

        public string Tytul
        {
            get
            {
                if (Sklep != null && Sklep.SklepId != 0)
                    return "Edytuj dane o sklepie";
                return "Dodaj nowy sklep";
            }
        }

        
    }
}