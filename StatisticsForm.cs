using ChartLibrary;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace supply_activity_app
{
    public partial class StatisticsForm : Form
    {
        #region Attributes
        private List<Contract> contracts = new List<Contract>();
        #endregion

        public StatisticsForm(List<Contract> _contracts)
        {
            InitializeComponent();
            contracts = _contracts;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        #region Events
        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            List<string> years = new List<string>();

            foreach(Contract c in contracts)
            {
                if (!years.Contains(c.SignDate.Year.ToString()))
                {
                    years.Add(c.SignDate.Year.ToString());
                }
            }

            Dictionary<string, double> appear = new Dictionary<string, double>();
            foreach(string s in years)
            {
                appear[s] = 0;
            }

            foreach(Contract c in contracts)
            {
                appear[c.SignDate.Year.ToString()] += 1;
            }

            double total = 0;
            foreach (string s in years)
            {
                total += appear[s];
            }


            float percentage = 0;
            int d = 0;
            Color[] colors = new Color[]
            {
                Color.Red,
                Color.Green,
                Color.Yellow,
                Color.HotPink,
                Color.Brown,
                Color.DarkOrange
            };

            //List<Color> col = new List<Color>();
            //foreach(string s in years)
            //{
            //    Random rand = new Random();
            //    int max = byte.MaxValue + 1; // 256
            //    int r = rand.Next(max);
            //    int g = rand.Next(max);
            //    int b = rand.Next(max);
            //    Color c = new Color();
            //    c = Color.FromArgb(r, g, b);
            //    col.Add(c);
            //}
            
            List<DonutChartCategory> donutCategories = new List<DonutChartCategory>();
            foreach(string s in years)
            {
                percentage = (float)(appear[s] / total) * 100;

                donutCategories.Add(new DonutChartCategory(s, percentage, colors[d]));
                d++;
            }

            donutChartControl1.Data = donutCategories.ToArray();
        }
        #endregion
    }
}
