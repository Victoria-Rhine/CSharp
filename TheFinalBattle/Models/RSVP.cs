namespace TheFinalBattle.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RSVP")]
    public partial class RSVP
    {
        public int ID { get; set; }

        public DateTime Timestamp { get; set; }

        public int EventID { get; set; }

        public int PersonID { get; set; }

        public virtual Event Event { get; set; }

        public virtual Person Person { get; set; }
    }
}
