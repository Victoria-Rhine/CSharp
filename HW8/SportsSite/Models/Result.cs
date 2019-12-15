namespace SportsSite.Models
{
    using System.ComponentModel.DataAnnotations;

    public partial class Result
    {
        public int ID { get; set; }

        [Required]
        public float RaceTime { get; set; }

        public int AID { get; set; }

        public int EID { get; set; }

        public int LID { get; set; }

        public virtual Athlete Athlete { get; set; }

        public virtual Event Event { get; set; }

        public virtual LocationDetail LocationDetail { get; set; }
    }
}
