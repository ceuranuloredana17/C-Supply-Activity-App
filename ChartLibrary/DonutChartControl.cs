using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChartLibrary
{
	public partial class DonutChartControl : UserControl
	{
        #region Attributes
        private DonutChartCategory[] _data;
        

        public DonutChartCategory[] Data
		{
			get { return _data; }
			set
			{
				if (_data == value)
					return;

				_data = value;

				Invalidate();
			}
		}
		#endregion

		public DonutChartControl()
		{
			InitializeComponent();

			ResizeRedraw = true;

			Data = new[]
			{
				new DonutChartCategory("Category 1", 20, Color.Red),
				new DonutChartCategory("Category 2", 80, Color.Blue)
			};
		}

        #region Events
        private void DonutChartControl_Paint(object sender, PaintEventArgs e)
		{
			int legendWidth = 150;

			Graphics graphics = e.Graphics;
			Rectangle clipRectangle = e.ClipRectangle;

			float radius = Math.Min(clipRectangle.Height, clipRectangle.Width - legendWidth) / (float)2;
			float radius1 = Math.Min(clipRectangle.Height - 30, clipRectangle.Width - legendWidth - 30) / (float)2;


			int xCenter = (clipRectangle.Width - legendWidth) / 2;
			int yCenter = clipRectangle.Height / 2;

			float x = xCenter - radius;
			float y = yCenter - radius;
			float x1 = xCenter - radius1;
			float y1 = yCenter - radius1;


			float width = radius * 2;
			float height = radius * 2;
			float width1 = radius1 * 2;
			float height1 = radius1 * 2;

			float percent1 = 0;
			float percent2 = 0;
			for (int i = 0; i < Data.Length; i++)
			{
				if (i >= 1)
					percent1 += Data[i - 1].Percentage;

				percent2 += Data[i].Percentage;

				float angle1 = percent1 / 100 * 360;
				float angle2 = percent2 / 100 * 360;

				Brush b = new SolidBrush(Data[i].Color);
				Brush b1 = new SolidBrush(Color.FromArgb(51, 51, 68));

				try
				{
					graphics.FillPie(b, x, y, width, height, angle1, angle2 - angle1);
					graphics.FillPie(b1, x1, y1, width1, height1, angle1, angle2 - angle1);
                }
                catch {}
			}

			Pen pen = new Pen(Color.Black);
			try
			{
				graphics.DrawEllipse(pen, x, y, width, height);
				graphics.DrawEllipse(pen, x1, y1, width1, height1);
            }
            catch {}

			float xpos = x + width + 20;
			float ypos = y;
			for (int i = 0; i < Data.Length; i++)
			{
				Brush b = new SolidBrush(Data[i].Color);
				graphics.FillRectangle(b, xpos, ypos, 30, 30);
				graphics.DrawRectangle(pen, xpos, ypos, 30, 30);
				Brush b2 = new SolidBrush(Color.White);
				graphics.DrawString(Data[i].Description + ": " + Data[i].Percentage + "%",
				Font, b2,
				xpos + 35, ypos + 12);
				ypos += 35;
			}
		}
		#endregion
	}
}
