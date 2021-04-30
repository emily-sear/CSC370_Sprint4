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
            /**
            //this method is to add new data to all data tables

            Form3.addTextToInstanceFields();
            DataRow rowGraduated = Form1.theDataContainerGraduatedCylinder.NewRow();
            DataRow hydroRow = Form1.theDataContainerHydrometer.NewRow();
            DataRow buretteRow = Form1.theDataContainerBurette.NewRow();
            DataRow thermoRow = Form1. theDataContainerThermometer.NewRow();
            DataRow balanceRow = Form1.theDataContainerBalance.NewRow();
            DataRow masterRow = Form1.theMasterDataTable.NewRow();

            //adding the new data to each data table

            //names to each row
            rowGraduated[0] = Form3.nameBox;
            hydroRow[0] = Form3.nameBox;
            buretteRow[0] = Form3.nameBox;
            thermoRow[0] = Form3.nameBox;
            balanceRow[0] = Form3.nameBox;
            masterRow[0] = Form3.nameBox;

            //adding the graduated cylinder row
            string[] gradSplit = Form3.graduatedBoxes.Split();
            rowGraduated[1] = gradSplit[0];
            rowGraduated[2] = gradSplit[1];
            rowGraduated[3] = gradSplit[0];
            rowGraduated[4] = gradSplit[0];
            Form1.theDataContainerGraduatedCylinder.Rows.Add(rowGraduated);

            //adding the hydrometer row
            string[] hydroSplit = Form3.hydroBoxes.Split();
            hydroRow[1] = hydroSplit[0];
            hydroRow[2] = hydroSplit[1];
            hydroRow[3] = hydroSplit[0];
            hydroRow[4] = hydroSplit[0];
            Form1.theDataContainerHydrometer.Rows.Add(hydroRow);

            //adding the burette row
            string[] buretteSplit = Form3.buretteBoxes.Split();
            buretteRow[1] = buretteSplit[0];
            buretteRow[2] = buretteSplit[1];
            buretteRow[3] = buretteSplit[0];
            buretteRow[4] = buretteSplit[0];
            Form1.theDataContainerBurette.Rows.Add(buretteRow);

            //adding the thermometer row
            string[] thermoSplit = Form3.thermometerBoxes.Split();
            thermoRow[1] = thermoSplit[0];
            thermoRow[2] = thermoSplit[1];
            thermoRow[3] = thermoSplit[0];
            thermoRow[4] = thermoSplit[0];
            Form1.theDataContainerThermometer.Rows.Add(thermoRow);

            //adding the balance row
            string[] balanceSplit = Form3.balanceBoxes.Split();
            balanceRow[1] = balanceSplit[0];
            balanceRow[2] = balanceSplit[1];
            balanceRow[3] = balanceSplit[0];
            balanceRow[4] = balanceSplit[0];
            Form1.theDataContainerBalance.Rows.Add(balanceRow);

            //adding all to the master row 
            masterRow[1] = Form3.graduatedBoxes;
            masterRow[2] = Form3.hydroBoxes;
            masterRow[3] = Form3.buretteBoxes;
            masterRow[4] = Form3.thermometerBoxes;
            masterRow[5] = Form3.balanceBoxes;
            Form1.theMasterDataTable.Rows.Add(masterRow);
            **/

        }

        public static void addTextToInstanceFields()
        {
            /**
            nameBox = textBox11.Text;
            graduatedBoxes = textBox5.Text + " " + textBox6.Text;
            hydroBoxes = textBox4.Text + " " + textBox7.Text;
            buretteBoxes = textBox3.Text + " " + textBox8.Text;
            thermometerBoxes = textBox2.Text + " " + textBox9.Text;
            balanceBoxes = textBox1.Text + " " + textBox10.Text;
            **/
        }
    }
}
