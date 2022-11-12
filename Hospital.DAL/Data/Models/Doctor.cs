namespace Hospital.DAL 
{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";

        public string Specialization { get; set; } = "";

        public double Salary { get; set; }

        public int PerformanceRate { get; set; }

        public ICollection<Patient>Patients { get; set; }= new HashSet<Patient>();
    }
}
