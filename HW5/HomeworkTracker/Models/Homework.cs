using System;
using System.ComponentModel.DataAnnotations;

namespace HomeworkTracker.Models
{
    public class Homework
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "missing")]
        [Range(1, 4)]
        public int Priority { get; set; }

        [Required(ErrorMessage = "missing")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "missing")]
        [RegularExpression("\\b((1[0-2]|0?[1-9]):([0-5][0-9]) ([AaPp][Mm]))", ErrorMessage = "HH:MM AM/PM")]
        public string Time { get; set; }

        [Required(ErrorMessage = "missing")]
        [StringLength(5, MinimumLength = 1)]
        public string Department { get; set; }

        [Required(ErrorMessage = "missing")]
        [Range(1, 1000)]
        public int CourseID { get; set; }

        [Required(ErrorMessage = "missing")]
        public string Title { get; set; }

        [Required(ErrorMessage = "missing")]
        public string Notes { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {Priority} {Date} {Time} {Department} {CourseID} {Title} {Notes}";
        }
    }
}