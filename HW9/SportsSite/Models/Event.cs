namespace SportsSite.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Event
    {
        public Event()
        {
            Results = new HashSet<Result>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        public virtual ICollection<Result> Results { get; set; }
    }
}
