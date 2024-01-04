using System.ComponentModel.DataAnnotations;
using System.Collections.Specialized;

namespace BarberBooking.Models
{
    public class Barber
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Numele trebuie să înceapă cu majusculă (ex: Pop) și să fie minim de 3 litere")]
        [StringLength(30, MinimumLength = 3)]
        public string Nume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Prenumele trebuie să înceapă cu majusculă (ex: Mihai) și să fie minim de 3 litere. Dacă te cheamă Le, Jo, ... ghinion :)")]
        [StringLength(30, MinimumLength = 3)]
        public string Prenume { get; set; }

        [Display(Name = "Nume complet")]
        public string NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        [Range(1, 5, ErrorMessage = "Ratingul trebuie să fie între 1 și 5.")]
        public int Rateing { get; set; }
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
