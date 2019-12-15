/* This model gathers all the information needs for Requirement #3 */

using System;
using System.ComponentModel.DataAnnotations;

namespace SportsSite.Models.ViewModels
{
    public class IndResultsModel
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime EventDate { get; set; }
        public string EventName { get; set; }
        public string EventLocation { get; set; }
        public float AthleteResult { get; set; }
    }
}