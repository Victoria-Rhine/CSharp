namespace SportsSite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class LocationDetail
    {
        public LocationDetail()
        {
            Results = new HashSet<Result>();
        }
        public int ID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Place { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
