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

        public int Id { get; set; }

        public Sklep Sklep { get; set; }

        public int SklepId { get; set; }

        [DisplayName("Data i godzina spotkania")]
        [DataType(DataType.Date)]
        public DateTime DataSpotkania { get; set; }

        public string FormaKontaktu { get; set; }

        public string Notatki { get; set; }
    }
}