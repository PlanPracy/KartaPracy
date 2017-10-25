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

        
        [Display(Name = "Jaki format sklepu")]
        public string FormatSklep { get; set; }

        public IEnumerable<SelectListItem> FormatSklepu { get; set; } 
    }
}