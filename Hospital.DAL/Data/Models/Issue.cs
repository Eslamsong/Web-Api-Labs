using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.DAL
{
    public class Issue
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = ""; 
        
        public ICollection<Patient> patients { get; set; }

        public Issue()
        {
            patients= new HashSet<Patient>();   
        }

    }
}
