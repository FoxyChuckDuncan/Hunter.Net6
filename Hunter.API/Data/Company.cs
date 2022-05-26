namespace Hunter.API.Data
{
    public class Company : EntityBase
    {
        public Company()
        {

        }

        public string Name { get; set; }
        public string Billing { get; set; }
        public string Region { get; set;  }

        // ONE company with MANY projects
        public virtual IList<Project> Projects { get; set; }
    }
}
