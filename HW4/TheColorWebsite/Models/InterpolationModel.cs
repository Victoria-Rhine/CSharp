using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System;

namespace TheColorWebsite.Models
{
    public class InterpolationModel
    {
        [Required(ErrorMessage = "color is required")]
        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "hex format required")]
        [StringLength(7, MinimumLength = 7)]
        public string firstColor { get; set; }

        [RegularExpression("^#([A-Fa-f0-9]{6}|[A-Fa-f0-9]{3})$", ErrorMessage = "hex format required")]
        [Required(ErrorMessage = "color is required")]
        [StringLength(7, MinimumLength = 7)]
        public string secondColor { get; set; }

        [Required(ErrorMessage = "number is required")]
        [Range(1, 100)]
        public int numColors { get; set; }
    }
}
