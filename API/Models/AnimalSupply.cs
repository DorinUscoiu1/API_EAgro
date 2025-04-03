namespace API.Models
{
    public class AnimalSupply
    {
        public int AnimalId { get; set; }
        public Animal Animal { get; set; }

        public int SupplyId { get; set; }
        public Supply Supply { get; set; }

        public int Quantity { get; set; }  // CÂT trebuie să cumpăr pentru acel animal
    }

}
