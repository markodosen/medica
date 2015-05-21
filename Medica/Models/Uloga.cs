using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Medica.Models
{
    public class Uloga
    {
        [Key]
        public int UlogaID { get; set; }

        [Required(ErrorMessage = "Ovo polje je obavezno")]
        [StringLength(50)]
        public string Ime { get; set; }

        [DisplayFormat(NullDisplayText = "Nema opisa")]
        public string Opis { get; set; }

        public virtual ICollection<Zaposleni> Zaposlenis { get; set; }
    }
}