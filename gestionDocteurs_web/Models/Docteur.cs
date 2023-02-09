using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gestionDocteurs_web.Models
{
    public class Docteur
    {
        public string Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Specialite { get; set; }
        public string HopitalId { get; set; }
        public Hopital hopital { get; set; }
    }
}
