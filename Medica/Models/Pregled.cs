using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Medica.Controllers;

namespace Medica.Models
{
    public class Pregled
    {
        [Key]
        public int PregledID { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime Datum { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [Range(0,24,ErrorMessage="Vrijeme mora biti izmedju 00,00 i 24,00")]
        public double VrijemePocetka { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public double VrijemeZavrsetka { get; set; }

        [Required]
        [DefaultValue(0)]
        public int Status { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Usluga Usluga { get; set; }
    }

}