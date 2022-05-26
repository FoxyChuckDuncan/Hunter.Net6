using System.ComponentModel.DataAnnotations.Schema;

namespace Hunter.API.Data
{
    public class Ghost : EntityBase
    {
        public Ghost()
        {

        }
        public int Era { get; set; }
        public bool isActive { get; set; }
        public string initialEra { get; set; }


        // ONE project can have MANY ghosts
        [ForeignKey(nameof(Project))]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }

        // ONE Ghost MAY have Zero or ONE Population
        [ForeignKey(nameof(PopulationId))]
        public int? PopulationId { get; set; }
        public virtual Population Population { get; set; }
    }
}
