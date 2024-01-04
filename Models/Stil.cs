namespace BarberBooking.Models
{
    public class Stil
    {
        public int ID { get; set; }
        public string DenumireStil { get; set; }
        public ICollection<ServiciuStil>? ServiciuStiluri {  get; set; }
        
    }
}
