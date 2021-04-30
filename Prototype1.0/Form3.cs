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
    public partial class Form3 : Form
    {
        public static string nameBox;
        public static string graduatedBoxes;
        public static string hydroBoxes;
        public static string buretteBoxes;
        public static string balanceBoxes;
        public static string thermometerBoxes;

        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


        }

        public static void addTextToInstanceFields()
        {
            nameBox = textBox11.Text;
            graduatedBoxes = textBox5.Text + " " + textBox6.Text;
            hydroBoxes = textBox4.Text + " " + textBox7.Text;
            buretteBoxes = textBox3.Text + " " + textBox8.Text;
            thermometerBoxes = textBox2.Text + " " + textBox9.Text;
            balanceBoxes = textBox1.Text + " " + textBox10.Text;
        }
    }
}
