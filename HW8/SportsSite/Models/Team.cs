namespace SportsSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Team
    {
        public Team()
        {
            Athletes = new HashSet<Athlete>();
        }
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int CID { get; set; }

        public virtual ICollection<Athlete> Athletes { get; set; }

        public virtual Coach Coach { get; set; }
    }
}
