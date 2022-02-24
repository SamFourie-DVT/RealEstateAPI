using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateAPI.Model
{
    //this class is to define the estates details
    public class RealEstate
    {
        [Key]
        public int EstateId { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        [Required, StringLength(100)]
        public string Street { get; set; } = string.Empty;
        [Required, StringLength(100)]
        public string City { get; set; } = string.Empty;
        [Required]
        public int Price { get; set; }
        [Required]
        //setting the foreign key - this does not actually set it and I must add it in the migrations
        public int AgentId { get; set; }
        
        //this below was me trying to set the AgentId to be the FK through migrations 

        //public int? AgentId { get; set; }
        //[ForeignKey("AgentId")]
        //public virtual EstateAgent EstateAgent { get; set; }

    }
}
