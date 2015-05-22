using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Medica.Models
{
    public class Usluga
    {
        [Key]
        public int UslugaID { get; set; }

        [Required(ErrorMessage="Ovo polje je obavezno")]
        [StringLength(100)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        public double Cijena { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [Range(0,4,ErrorMessage="Pregled ne moze da traje duze od 4 sata")]
        public double Trajanje { get; set; }

        [DisplayFormat(NullDisplayText = "Nema opisa")]
        public string Opis { get; set; }

        [Required]
        [Range(0, 1)]
        public int Status { get; set; }

        public int ZaposleniID { get; set; }

        public virtual ICollection<Pregled> Pregleds { get; set; }
        public virtual Zaposleni Zaposleni { get; set; }
    }
}