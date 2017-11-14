using System;

namespace KartaPracy.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using Models;

    public class SklepDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Nazwa { get; set; }


        [Display(Name = "Kontakt do sklepu ")]
        public Kontakt Kontakt { get; set; }

        [Display(Name = "Właściciel/osoba do kontaktu")]
        public byte KontaktId { get; set; }


        public FormatSklepu FormatSklepu { get; set; }
        [Display(Name = "Format sklepu")]
        public byte FormatSklepuId { get; set; }


        public string Nip { get; set; }

        [Required]
        [Display(Name = "Miejscowość")]
        public string Miejscowosc { get; set; }

        [Required]
        [Display(Name = "Adres")]
        public string Ulica { get; set; }

        [Display(Name = "Kod pocztowy")]
        public string Kod { get; set; }

        public string Uwagi { get; set; }

        [Display(Name = "Typ parkingu:")]
        public string TypParking { get; set; }

        [Display(Name = "Czy jest w sieci?")]
        public bool CzySieciowy { get; set; }
        public DateTime DataUtworzeniaSklepu { get; set; }
    }
}