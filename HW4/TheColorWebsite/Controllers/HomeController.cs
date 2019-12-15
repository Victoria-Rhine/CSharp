using System.Collections.Generic;
using System.Drawing;
using System;
using System.Web.Mvc;

namespace TheColorWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RGBColor()
        {
            ViewBag.Red = Request["red"];
            ViewBag.Green = Request["green"];
            ViewBag.Blue = Request["blue"];

            return View();
        }

        public ActionResult Interpolator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Submit(Models.InterpolationModel im)
        {
            if (ModelState.IsValid)
            {
                IList<EndColor> ListofColors = new List<EndColor>();

                Color startColor = ColorTranslator.FromHtml(im.firstColor);
                Color endColor = ColorTranslator.FromHtml(im.secondColor);

                ColorToHSV(startColor, out double startH, out double startS, out double startV);
                ColorToHSV(endColor, out double endH, out double endS, out double endV);

                for (int i = 0; i < im.numColors; i++)
                {
                    double dh = (endH - startH) / (im.numColors - 1);
                    double newH = startH + (i * dh);

                    double dS = (endS - startS) / (im.numColors - 1);
                    double newS = startS + (i * dS);

                    double dV = (endV - startV) / (im.numColors - 1);
                    double newV = startV + (i * dV);

                    Color colorConversion = ColorFromHSV(newH, newS, newV);
                    string htmlColor = ColorTranslator.ToHtml(colorConversion);

                    ListofColors.Add(new EndColor { HTMLCol = htmlColor });

                    startColor = ColorTranslator.FromHtml(htmlColor);

                    ColorToHSV(startColor, out newH, out newS, out newV); 
                }

                ViewBag.ListColors = ListofColors;

                return View("Interpolator");
            }
            else
            {
                ViewBag.Message = "Oops something is wrong";
                return View("Interpolator");
            }

            // functions to handle conversions
            void ColorToHSV(Color color, out double hue, out double saturation, out double value)
            {
                int max = Math.Max(color.R, Math.Max(color.G, color.B));
                int min = Math.Min(color.R, Math.Min(color.G, color.B));

                hue = color.GetHue();
                saturation = (max == 0) ? 0 : 1d - (1d * min / max);
                value = max / 255d;
            }

            Color ColorFromHSV(double hue, double saturation, double value)
            {
                int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
                double f = hue / 60 - Math.Floor(hue / 60);

                value = value * 255;
                int v = Convert.ToInt32(value);
                int p = Convert.ToInt32(value * (1 - saturation));
                int q = Convert.ToInt32(value * (1 - f * saturation));
                int t = Convert.ToInt32(value * (1 - (1 - f) * saturation));

                if (hi == 0)
                    return Color.FromArgb(255, v, t, p);
                else if (hi == 1)
                    return Color.FromArgb(255, q, v, p);
                else if (hi == 2)
                    return Color.FromArgb(255, p, v, t);
                else if (hi == 3)
                    return Color.FromArgb(255, p, q, v);
                else if (hi == 4)
                    return Color.FromArgb(255, t, p, v);
                else
                    return Color.FromArgb(255, v, p, q);
            }
        }
        public struct EndColor
        {
            public string HTMLCol { get; set; }
        }
    }
}