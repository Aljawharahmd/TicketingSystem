namespace Ticketing.Data.Models
{
    public class StorageFile 
    {
        public int Id { get; set; }
        public string Extension { get; set; }
        public string Name { get; set; }

        public Ticket Ticket { get; set; }
        public Reply Reply { get; set; }
 
    }
}
