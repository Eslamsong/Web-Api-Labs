using System.ComponentModel.DataAnnotations;

namespace API_LAB_1.Validation
{
    public class ProductionDateValidationAttribute :ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value is DateTime ProductionDate && ProductionDate <= DateTime.Now;
        }
    }
}
