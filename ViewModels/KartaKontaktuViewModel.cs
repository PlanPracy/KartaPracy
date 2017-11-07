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
    }
}