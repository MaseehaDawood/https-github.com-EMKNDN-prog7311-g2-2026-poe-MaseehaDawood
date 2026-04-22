using System.ComponentModel.DataAnnotations;


namespace GLMS.Models
{


    public class Contract
    {
        public int ContractId { get; set; }

        [Required]
        public int ClientId { get; set; }

        public Client? Client { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string Status { get; set; }

        public string? ServiceLevel { get; set; }

        public string? FilePath { get; set; }
    }
}
