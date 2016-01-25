namespace CursoASPMVC2.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;

    public class CompanyValidation
    {
        public static ValidationResult ValidateTitleMayorQueCinco(string Title)
        {
            if (Title.Length < 5)
            {
                return new ValidationResult("Debe ser mayor o igual que 5");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

        public static ValidationResult ValidateTitleMenorQueDiez(string Title)
        {
            if (Title.Length > 10)
            {
                return new ValidationResult("Debe ser menor o igual que 10");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
