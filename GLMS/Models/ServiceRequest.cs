using System.ComponentModel.DataAnnotations;

namespace GLMS.Models
{


    public class ServiceRequest
    {
        public int ServiceRequestId { get; set; }

        [Required]
        public int ContractId { get; set; }

        public Contract? Contract { get; set; }  

        [Required]
        public required string Description { get; set; }

        [Required]
        public double CostUSD { get; set; }

        public double CostZAR { get; set; }

        public string? Status { get; set; }

    }
}
