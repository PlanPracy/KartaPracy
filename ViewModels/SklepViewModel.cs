using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.ViewModels
{
    using Models;

    public class SklepViewModel
    {
        public IEnumerable<Kontakt> Kontakts { get; set; }
       
        
        public Sklep Sklep { get; set; }

        public string Tytul
        {
            get
            {
                if (Sklep != null && Sklep.Id != 0)
                    return "Edytuj dane o sklepie";
                return "Dodaj nowy sklep";
            }
        }
    }
}