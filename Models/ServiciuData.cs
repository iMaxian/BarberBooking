namespace BarberBooking.Models
{
    public class ServiciuData
    {
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<Stil> Stiluri { get; set; }
        public IEnumerable<ServiciuStil> ServiciuStiluri { get; set; }
    }
}
