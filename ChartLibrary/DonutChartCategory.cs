using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartLibrary
{
    public class DonutChartCategory
    {
		public string Description { get; set; }

		public float Percentage { get; set; }

		public Color Color { get; set; }

		public DonutChartCategory(string description, float percent, Color color)
		{
			Description = description;
			Percentage = percent;
			Color = color;
		}
	}
}
