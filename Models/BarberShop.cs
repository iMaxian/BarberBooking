using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BarberBooking.Models
{
    public class BarberShop
    {
        public int ID { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public string NrTelefon { get; set; }

        [Range(1, 5, ErrorMessage = "Ratingul trebuie să fie între 1 și 5.")]
        public int Rateing { get; set; }
    }
}
