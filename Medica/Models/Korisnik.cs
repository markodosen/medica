using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Medica.Models
{
    public class Korisnik
    {
        [Key]
        public int KorisnikID { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(15)]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(15)]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [RegularExpression("^[0-9]{13}$",ErrorMessage="JMBG mora da ima tacno 13 cifara")]
        public String JMBG { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [MinLength(8,ErrorMessage="Sifra mora da ima 8 ili vise slova")]
        public string Sifra { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [RegularExpression("^[0-9]{8,15}$", ErrorMessage = "Telefon mora da ima tacno 8 do 15 cifara")]
        public String Telefon { get; set; }

        [Required]
        [Range(0,1)]
        public int Status { get; set; }

        public virtual ICollection<Pregled> Pregleds { get; set; }
    }
}