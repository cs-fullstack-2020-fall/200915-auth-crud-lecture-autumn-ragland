using System.ComponentModel.DataAnnotations;

namespace Lecture.Models
{
    public class BandModel 
    {
        [Key]
        public int id{get;set;}

        [Required(ErrorMessage = "You must provide a band name")]
        [Display(Name = "Name")]
        public string bandName{get;set;}

        [Range(1960,2020, ErrorMessage = "The band must be formed between 1960 and 2020")]
        [Display(Name = "Year Formed")]
        public int yearFormed{get;set;}

        [Range(1,15, ErrorMessage = "The band cannot have more than 15 members")]
        [Display(Name = "Number of Members")]
        public int numberOfMembers{get;set;}
    }
}