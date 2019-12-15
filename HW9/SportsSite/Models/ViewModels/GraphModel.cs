/* This model gathers all the information needs for Requirement #3 */

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsSite.Models.ViewModels
{
    public class GraphModel
    {
        [Required]
        [StringLength(50)]
        public string EventName { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EventDate { get; set; }

        [Column("Result")]
        [Required]
        public float RaceResult { get; set; }
    }
}