using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


    namespace DentalApp.Models
{
    public class Pacient
    {
        public int Id { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
             ErrorMessage = "Characters are not allowed."), Required]
        public string Nume { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
             ErrorMessage = "Characters are not allowed."), Required]
        public string Prenume { get; set; }
        [RegularExpression(@"^[1-9][0-9]*$",
          ErrorMessage = "It must contain only numbers.")]
        public string NumarFisa { get; set; }
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,80}$",
             ErrorMessage = "Characters are not allowed."), Required]
        public string Medic { get; set; }
        [Display(Name = "CI Series")]
        [RegularExpression(@"^[a-zA-Z]{1,2}$")]
        public string SerieCi { get; set; }
        [Display(Name = "CI Number")]
        [RegularExpression(@"^[0-9]{1,6}$",
             ErrorMessage = "It must contain six numbers.")]
        public string NumarCi { get; set; }
        [Display(Name = "CNP Number")]
        [RegularExpression(@"^[1-8][0-9]{1,12}$",
                ErrorMessage ="It must contain 13 numbers not starting with 0.")]    
        public string Cnp { get; set; }
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]{1,10}$",
            ErrorMessage = "It must contain ten numbers.")]
        public string Telefon { get; set; }
        [Display(Name = "Observations")]
        public string Observatii { get; set; }
    }
}
