namespace SportsSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Athlete
    {
        public Athlete()
        {
            Results = new HashSet<Result>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Gender { get; set; }

        public int TID { get; set; }

        public virtual ICollection<Result> Results { get; set; }

        public virtual Team Team { get; set; }
    }
}
