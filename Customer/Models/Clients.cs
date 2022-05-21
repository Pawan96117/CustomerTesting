using System.ComponentModel.DataAnnotations;

namespace Customer.Models
{
    public class Clients
    {
        [Key]
        public int Clients_Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        public long Contact_No { get; set; }
    }
}
