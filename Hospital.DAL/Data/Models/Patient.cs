namespace Hospital.DAL;

public class Patient
{
    public Guid Id { get; set; }
    public string Name { get; set; } = "";

    public Guid   Doc_Id { get; set; }
    public ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
    
    public Doctor? doctor { get; set; }  
}
