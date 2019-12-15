namespace SportsSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Coach
    {
        public Coach()
        {
            Teams = new HashSet<Team>();
        }
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
