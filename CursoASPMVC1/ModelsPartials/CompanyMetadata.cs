namespace CursoASPMVC1.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;

    public class CompanyMetadata
    {

        [Required(ErrorMessage = "Atención!! Title es obligatorio!!.")]
        [CustomValidation(typeof(CompanyValidation), "ValidateTitleMayorQueCinco", ErrorMessage = "El Title debe ser superior o igual a 5 caracteres")]
        [CustomValidation(typeof(CompanyValidation), "ValidateTitleMenorQueDiez", ErrorMessage = "El Title debe ser inferior o igual a 10 caracteres")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Atención!! Address es obligatorio!!.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Atención!! CreationDate es obligatorio!!.")]
        public Nullable<System.DateTime> CreationDate { get; set; }
    }
}
