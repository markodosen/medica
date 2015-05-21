using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Medica.Models
{
    public class Zaposleni
    {
        [Key]
        public int ZaposleniID { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(15)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(15)]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(8,ErrorMessage="Sifra mora sadrzati barem 8 slova")]
        public string Sifra { get; set; }

        [Required]
        [Range(0,1)]
        public int Status { get; set; }

        [DisplayFormat(NullDisplayText = "Nema opisa")]
        public string Opis { get; set; }

        public int UlogaID { get; set; }

        public virtual ICollection<Usluga> Uslugas { get; set; }
        public virtual Uloga Uloga { get; set; }
        public virtual ICollection<RadnoVrijeme> RadnoVrijemes { get; set; }

        public string PunoIme { get { return Ime + " " + Prezime; } }
    }
}