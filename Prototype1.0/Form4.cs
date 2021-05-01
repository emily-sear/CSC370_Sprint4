using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototype1._0
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //fill up instructors array with the values from the textbox
                Form1.instructorValues[0] = Convert.ToDouble(textBox2.Text);
                Form1.instructorValues[1] = Convert.ToDouble(textBox3.Text);
                Form1.instructorValues[2] = Convert.ToDouble(textBox4.Text);
                Form1.instructorValues[3] = Convert.ToDouble(textBox5.Text);
                Form1.instructorValues[4] = Convert.ToDouble(textBox6.Text);

                //fill up the tolerance array with the values from the textboxes
                Form1.tolerances[0] = Convert.ToDouble(textBox7.Text);
                Form1.tolerances[1] = Convert.ToDouble(textBox8.Text);
                Form1.tolerances[2] = Convert.ToDouble(textBox9.Text);
                Form1.tolerances[3] = Convert.ToDouble(textBox10.Text);
                Form1.tolerances[4] = Convert.ToDouble(textBox11.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not add instructor values, be sure to make sure all values are valid and that student values are added first! \nOriginal error:\n " + ex.Message);
            }

        }
    }
}
