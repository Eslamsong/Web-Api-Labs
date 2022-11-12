using API_LAB_1.Validation;

namespace API_LAB_1.Model
{
    public class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        [ProductionDateValidation]
        public DateTime ProductionDate { get; set; }

        public string cartype { get; set; } = "Gas";

    }
}
