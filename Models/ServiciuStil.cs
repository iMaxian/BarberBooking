namespace BarberBooking.Models
{
    public class ServiciuStil
    {
        public int ID { get; set; }
        public int ServiciuID { get; set; }
        public Serviciu Serviciu { get; set; }
        public int StilID { get; set; }
        public Stil Stil { get; set; }
    }
}
