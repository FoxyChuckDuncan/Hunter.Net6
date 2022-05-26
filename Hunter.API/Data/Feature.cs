namespace Hunter.API.Data
{
    public class Feature : EntityBase
    {
        public Feature()
        {
        }

        public int? IndividualId { get; set; }
        public Individual Individual { get; set; }

    }
}
