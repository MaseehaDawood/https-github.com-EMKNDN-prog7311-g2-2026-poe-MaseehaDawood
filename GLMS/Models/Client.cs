using System.Diagnostics.Contracts;
using System.ComponentModel.DataAnnotations;

namespace GLMS.Models
{


    public class Client
    {
        public int ClientId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ContactDetails { get; set; }

        [Required]
        public string Region { get; set; }

        public List<Contract>? Contracts { get; set; }
    }
}
