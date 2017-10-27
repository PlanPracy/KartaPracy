using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.ViewModels
{
    using Models;

    public class KontaktViewModel
    {
        public Kontakt Kontakt { get; set; }

        public string Tytul
        {
            get
            {
                if (Kontakt != null && Kontakt.Id != 0)
                    return "Edytuj dane właściciela/osoby do kontaktu";
                return "Dodaj właścicela sklepu";
            }
        }
    }
}