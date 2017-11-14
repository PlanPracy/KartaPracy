using System;

namespace KartaPracy.Dtos
{
    using System.ComponentModel.DataAnnotations;
    using Models;

    public class KartaKontaktuDto
    {
       [Display(Name = "Nr zdarzenia")]
        public int Id { get; set; }

        public Sklep Sklep { get; set; }

        [Display(Name = "Sklep")]
        public int SklepId { get; set; }

        [Required]
        [Display(Name = "Data i godzina spotkania")]
        [DataType((DataType)DataType.DateTime)]
        public DateTime DataSpotkania { get; set; }
        
        [Display(Name = "Forma kontaktu")]
        public string FormaKontaktu { get; set; }

        [Display(Name = "Notatki")]
        [StringLength(512, ErrorMessage = "Maksymalnie mozesz podac 512 znaków ")]
        public string Notatki { get; set; }
    }
}