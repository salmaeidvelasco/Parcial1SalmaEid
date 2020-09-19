using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial1SalmaEid.Models
{
    public class Language
    {

        public string iso639_1 { get; set; }

        public string iso639_2 { get; set; }

        public string name { get; set; }

        public string nativeName { get; set; }

    }
    public class Country
    {
        
        [Key]
        [StringLength(3,ErrorMessage ="Ingrese 3 caracteres ")]
        [Required]
        public string alpha3code { get; set; }


        [StringLength(30,MinimumLength =3)]
        public string region { get; set; }


        [Required]
        [Display(Name= "Nombre del país")]
        public string name { get; set; }

        [Range(100,9999999)]
        public double area { get; set; }


        [Range (1,6)]
        public int callingCodes { get; set; }


        [Required]
        public List <Language> lenguage { get; set; }


        [Url]
        public string flag { get; set; }





    }
}