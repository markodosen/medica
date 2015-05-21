using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace Medica.Models
{
    public class RadnoVrijeme
    {
        [Key]
        public int RadnoVrijemeID { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [Range(0,6)]
        public int Dan { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [Range(0,24,ErrorMessage="Vrijeme mora biti izmedju 00,00 i 24,00")]
        public double SatiOd { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [Range(0, 24, ErrorMessage = "Vrijeme mora biti izmedju 00,00 i 24,00")]
        public double SatiDo { get; set; }

        public virtual ICollection<Zaposleni> Zaposlenis { get; set; }
    }
}