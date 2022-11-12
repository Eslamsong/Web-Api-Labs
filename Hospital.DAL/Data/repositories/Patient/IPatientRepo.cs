namespace Hospital.DAL
{
    public interface IPatientRepo :IGenericRepo<Patient>
    {

        List<Patient> GetPatientsWithIssues();

    }
}
