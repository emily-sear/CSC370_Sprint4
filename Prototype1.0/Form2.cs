using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Prototype1._0
{
    public partial class Form2 : Form
    {
        public static double[] theData;
        public Form2()
        {
            InitializeComponent();
            var theDataSeries = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                //Initialize the table (name, and some general parameters).
                //
                Name = "TheDataSeries",
                IsVisibleInLegend = false,
                ChartType = SeriesChartType.Column,
                IsXValueIndexed = true
                //
            };

           
            //Pre-defining veriables.
            double num1 = 0;
            double num2 = 0;
            double num3 = 0;
            double num4 = 0;
            double num5 = 0; //mid point variable
            double num6 = 0;
            double num7 = 0;
            double num8 = 0;


            double midPoint = (Form1.highValue + Form1.lowValue) / 2;
            double valuesInBetween = (midPoint - Form1.lowValue) / 3;
            //This entire nested for-if is used to sort the data gotten in Form1 from the spreadsheet into different columns.

            for (int i = 0; i < theData.Length; i++)
            {
                if (theData[i] <= Form1.lowValue && theData[i] > 0)
                {
                    num1++;
                }
                else if (theData[i] > Form1.lowValue && theData[i] <= (Form1.lowValue + valuesInBetween))
                {
                    num2++;
                }
                else if (theData[i] > (Form1.lowValue + valuesInBetween) && theData[i] <= (Form1.lowValue + (2 * valuesInBetween)))
                {
                    num3++;
                }
                else if (theData[i] > Form1.lowValue + (2 * valuesInBetween) && theData[i] <= (Form1.lowValue + (3 * valuesInBetween)))
                {
                    num4++;
                }
                else if (theData[i] > midPoint && theData[i] <= (midPoint + (1 * valuesInBetween)))
                {
                    num5++;
                }
                else if (theData[i] > midPoint + (1 * valuesInBetween) && theData[i] <= (midPoint + (2 * valuesInBetween)))
                {
                    num6++;
                }
                else if (theData[i] > midPoint + (2 * valuesInBetween) && theData[i] < (midPoint + (3 * valuesInBetween)))
                {
                    num7++;
                }
                else if (theData[i] >= Form1.highValue)
                {
                    num8++;
                }

            }

            //This points data to the correct X,Y coordinate on the table.
            int point1 =  theDataSeries.Points.AddY(num1);
            int point2 = theDataSeries.Points.AddY(num2);
            int point3 = theDataSeries.Points.AddY(num3);
            int point4 = theDataSeries.Points.AddY(num4);
            int point5 = theDataSeries.Points.AddY(num5);
            int point6 = theDataSeries.Points.AddY(num6);
            int point7 = theDataSeries.Points.AddY(num7);
            int point8 = theDataSeries.Points.AddY(num8);

            theDataSeries.Points[point1].AxisLabel = "0 - " + Convert.ToString(Form1.lowValue);
            theDataSeries.Points[point2].AxisLabel = Convert.ToString(Form1.lowValue) + " - " + Convert.ToString(Form1.lowValue + valuesInBetween);
            theDataSeries.Points[point3].AxisLabel = Convert.ToString(Form1.lowValue + valuesInBetween) + " - " + Convert.ToString(Form1.lowValue + (2 * valuesInBetween));
            theDataSeries.Points[point4].AxisLabel = Convert.ToString(Form1.lowValue + (2*valuesInBetween)) + " - " + Convert.ToString(midPoint);
            theDataSeries.Points[point5].AxisLabel = Convert.ToString(midPoint) + " - " + Convert.ToString(midPoint + (1 * valuesInBetween));
            theDataSeries.Points[point6].AxisLabel = Convert.ToString(midPoint + (1 * valuesInBetween)) + " - " + Convert.ToString(midPoint + (2 * valuesInBetween));
            theDataSeries.Points[point7].AxisLabel = Convert.ToString(midPoint + (2 * valuesInBetween)) + " - " + Convert.ToString(Form1.highValue);
            theDataSeries.Points[point8].AxisLabel = "≥" + Convert.ToString(Form1.highValue);

            theDataSeries.XValueMember = "Values";
            theDataSeries.YValueMembers = "Amount";

            this.chart1.Series.Add(theDataSeries); //This stores the data into the table.
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
