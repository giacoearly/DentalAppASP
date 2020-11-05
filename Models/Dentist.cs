using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace DentalApp.Models
{
    public class Dentist
    {
        public int Id { get; set; }

        [Display(Name ="Last Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
             ErrorMessage = "Characters are not allowed."), Required]
        public string Nume { get; set; }
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
             ErrorMessage = "Characters are not allowed."), Required]
        public string Prenume { get; set; }
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^[0-9]{1,10}$",
             ErrorMessage = "It must contain ten numbers.")]
        public string Telefon { get; set; }
        [Display(Name = "Observations")]
        public string Observatii { get; set; }
    }
}
