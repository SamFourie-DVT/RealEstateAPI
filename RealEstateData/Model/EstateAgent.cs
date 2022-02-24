using System.ComponentModel.DataAnnotations;

namespace RealEstateAPI.Model
{
    //this class is to define the agents details
    public class EstateAgent
    {
        [Key]
        public int AgentId { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required, StringLength(10), MinLength(10)]
        public string CellPhone { get; set; } = string.Empty;
        [Required, StringLength(5)]
        public string CountryCode { get; set; } = string.Empty;
    }
}
