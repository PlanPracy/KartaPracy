using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class KartaKontaktu
    {
        public KartaKontaktu()

        {
           var date= DateTime.Now.ToLocalTime();

           DataSpotkania = date; 
        }

        [Display(Name = "Nr zdarzenia")]
        public int Id { get; set; }

        public Sklep Sklep { get; set; }

        [Display(Name = "Sklep")]
        public int SklepId { get; set; }

        [Display(Name = "Data i godzina spotkania")]
        [DataType((DataType) DataType.DateTime)]
        public DateTime DataSpotkania { get; set; }


        [Display(Name = "Forma kontaktu")]
        public string FormaKontaktu { get; set; }

        [Display(Name = "Notatki")]
        public string Notatki { get; set; }
    }
}