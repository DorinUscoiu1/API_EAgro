namespace API.Models
{
    public class Agency
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string County {  get; set; }
        public string Location {  get; set; }
        public string Address { get; set; }
        public string Type { get; set; }
        public List<Agent> Agents { get; set; }

    }
}
