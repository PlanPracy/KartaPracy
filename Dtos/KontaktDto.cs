using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KartaPracy.Dtos
{
    using System.ComponentModel.DataAnnotations;

    public class KontaktDto
    {
        [Key]
        public byte Id { get; set; }
        [Required]
        public string Nazwisko { get; set; }

        [Display(Name = "Osoba do kontaktu")]
        public string OsobaDoKontaktu { get; set; }

        [Required(ErrorMessage = "Proszę podać numer telefonu.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression("[0-9]{9}", ErrorMessage = "Numer telefonu musi składać się z 9 cyfr.")]
        public string Telefon { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string Opis { get; set; }
    }
}