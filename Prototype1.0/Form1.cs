using System;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows;

namespace Prototype1._0
{
    /**
     * Emily Sear (Programmer), Trey Karsten (Design Architecture), Andrew Cizek, and Turner Frazier
     * 1 May 2021
     * Sprint 4
     * **/

    /**
     * Lost some files of this project? 
     * Go to: https://github.com/emily-sear/Prototype1.0 
     **/

    /**
     * Functionality of the sprint: 
     * Focus on the "View" portion of the application 
     * Make a working graph section 
     * Allow user to view the student names
     * allow user to enter in instructor values (not allowed to grade quite yet
     **/


    public partial class Form1 : Form
    {
        //generates tables for each corresponding instrument 
        public static DataTable theDataContainerGraduatedCylinder = new DataTable();
        public static DataTable theDataContainerHydrometer = new DataTable();
        public static DataTable theDataContainerBurette = new DataTable();
        public static DataTable theDataContainerThermometer = new DataTable();
        public static DataTable theDataContainerBalance = new DataTable();
        public static DataTable theMasterDataTable = new DataTable();

        //table booleans indicating if they are full or not
        bool created = false;

        //instructor values and tolerances 
        public static double[] instructorValues = new double[5];
        public static double[] tolerances = new double[5];

        //Next sprint will go through these and see what is actually still being used 
        public static double lowValue;
        public static double highValue;


        public Form1()
        {
            InitializeComponent();
        }

        private void dataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void resultsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void spreadSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;

            //Creates an open file dialog box to pull the .xml file from
            //
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Open Excel File with Data";
            //

            //We don't want anything expect excel files 
            //
            theDialog.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            theDialog.InitialDirectory = @"C:\";
            //

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = theDialog.OpenFile()) != null)
                    {
                        //generates some info about the file location in order to read the file
                        //
                        System.IO.FileInfo fInfo = new System.IO.FileInfo(theDialog.FileName);
                        string strFileLocation = fInfo.FullName;
                        //

                        //used for passing on the file name for future functions
                        //
                        string pathName = theDialog.FileName;
                        string fileName = System.IO.Path.GetFileNameWithoutExtension(theDialog.FileName);
                        //

                        //Opens the info from the first page of the excel sheet.
                        //
                        Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

                        Microsoft.Office.Interop.Excel.Workbook excelWorkbook = excelApp.Workbooks.Open(pathName);

                        Microsoft.Office.Interop.Excel._Worksheet excelWorksheet = excelWorkbook.Sheets[1];

                        Microsoft.Office.Interop.Excel.Range excelRange = excelWorksheet.UsedRange;

                        int rowCount = excelRange.Rows.Count;

                        //Add the labels to each dataContainer
                        theDataContainerGraduatedCylinder.Columns.Add("Names");
                        theDataContainerHydrometer.Columns.Add("Names");
                        theDataContainerBurette.Columns.Add("Names");
                        theDataContainerThermometer.Columns.Add("Names");
                        theDataContainerBalance.Columns.Add("Names");
                        theMasterDataTable.Columns.Add("Names");

                        theDataContainerGraduatedCylinder.Columns.Add("Values");
                        theDataContainerHydrometer.Columns.Add("Values");
                        theDataContainerBurette.Columns.Add("Values");
                        theDataContainerThermometer.Columns.Add("Values");
                        theDataContainerBalance.Columns.Add("Values");

                        theDataContainerGraduatedCylinder.Columns.Add("Sig Figs");
                        theDataContainerHydrometer.Columns.Add("Sig Figs");
                        theDataContainerBurette.Columns.Add("Sig Figs");
                        theDataContainerThermometer.Columns.Add("Sig Figs");
                        theDataContainerBalance.Columns.Add("Sig Figs");

                        theDataContainerGraduatedCylinder.Columns.Add("Units");
                        theDataContainerHydrometer.Columns.Add("Units");
                        theDataContainerBurette.Columns.Add("Units");
                        theDataContainerThermometer.Columns.Add("Units");
                        theDataContainerBalance.Columns.Add("Units");

                        theDataContainerGraduatedCylinder.Columns.Add("Counted Values");
                        theDataContainerHydrometer.Columns.Add("Counted Values");
                        theDataContainerBurette.Columns.Add("Counted Values");
                        theDataContainerThermometer.Columns.Add("Counted Values");
                        theDataContainerBalance.Columns.Add("Counted Values");

                        theMasterDataTable.Columns.Add("Graduated Cylinder");
                        theMasterDataTable.Columns.Add("Hydrometer");
                        theMasterDataTable.Columns.Add("Burette");
                        theMasterDataTable.Columns.Add("Thermometer");
                        theMasterDataTable.Columns.Add("Analytical Balance");

                        created = true;

                        for (int i = 2; i < rowCount; i++)
                        {
                            //add data to each specified data Container based on which part of the excel sheet it is at
                            DataRow row = theDataContainerGraduatedCylinder.NewRow(); //assign new row to DataTable
                            row[0] = excelRange.Cells[i, 1].Value2.ToString();
                            string[] currentRow = excelRange.Cells[i, 2].Value2.ToString().Split();
                            row[1] = currentRow[0];
                            row[2] = currentRow[0];
                            row[3] = currentRow[1];
                            row[4] = currentRow[0];
                            theDataContainerGraduatedCylinder.Rows.Add(row);


                            DataRow row2 = theDataContainerHydrometer.NewRow(); //assign new row to DataTable
                            row2[0] = excelRange.Cells[i, 1].Value2.ToString();
                            string[] currentRow2 = excelRange.Cells[i, 3].Value2.ToString().Split();
                            row2[1] = currentRow2[0];
                            row2[2] = currentRow2[0];
                            row2[3] = currentRow2[1];
                            row2[4] = currentRow2[0];
                            theDataContainerHydrometer.Rows.Add(row2);


                            DataRow row3 = theDataContainerBurette.NewRow(); //assign new row to DataTable
                            row3[0] = excelRange.Cells[i, 1].Value2.ToString();
                            string[] currentRow3 = excelRange.Cells[i, 4].Value2.ToString().Split();
                            row3[1] = currentRow3[0];
                            row3[2] = currentRow3[0];
                            //row3[3] = currentRow3[1];
                            row3[4] = currentRow3[0];
                            theDataContainerBurette.Rows.Add(row3);


                            DataRow row4 = theDataContainerThermometer.NewRow(); //assign new row to DataTable
                            row4[0] = excelRange.Cells[i, 1].Value2.ToString();
                            string[] currentRow4 = excelRange.Cells[i, 5].Value2.ToString().Split();
                            row4[1] = currentRow4[0];
                            row4[2] = currentRow4[0];
                            row4[3] = currentRow4[1];
                            row4[4] = currentRow4[0];
                            theDataContainerThermometer.Rows.Add(row4);


                            DataRow row5 = theDataContainerBalance.NewRow(); //assign new row to DataTable
                            row5[0] = excelRange.Cells[i, 1].Value2.ToString();
                            string[] currentRow5 = excelRange.Cells[i, 6].Value2.ToString().Split();
                            row5[1] = currentRow5[0];
                            row5[2] = currentRow5[0];
                            row5[3] = currentRow5[1];
                            row5[4] = currentRow5[0];
                            theDataContainerBalance.Rows.Add(row5);

                        }

                        // fill up master data table
                        DataRow masterRow;
                        for (int j = 2; j < rowCount; j++)
                        {
                            int rowCounter = 0;
                            masterRow = theMasterDataTable.NewRow();
                            masterRow[rowCounter] = excelRange.Cells[j, 1].Value.ToString();
                            for (int k = 1; k <= theMasterDataTable.Columns.Count; k++)
                            {
                                masterRow[rowCounter] = excelRange.Cells[j, k].Value.ToString();
                                rowCounter++;
                            }
                            theMasterDataTable.Rows.Add(masterRow);
                        }

                        dataGridView1.DataSource = theDataContainerGraduatedCylinder; //assign DataTable as Datasource for DataGridview
                        dataGridView1.Columns[0].Visible = false; //makes the names invisible originally
                        //close and clean excel process
                        //
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        Marshal.ReleaseComObject(excelRange);
                        Marshal.ReleaseComObject(excelWorksheet);
                        //

                        //quit apps
                        //
                        excelWorkbook.Close();
                        Marshal.ReleaseComObject(excelWorkbook);
                        excelApp.Quit();
                        Marshal.ReleaseComObject(excelApp);

                        findAverage();
                        findStandardDev();
                        setHighValue();
                        setLowValue();

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. \nOriginal error " + ex.Message);
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2.theData = new double[dataGridView1.RowCount];
            //Creates and displays table when the "graph" button is clicked
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Form2.theData[i] = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
            }
            Form2 graphForm = new Form2();
            graphForm.Show();
            //

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void studentNamesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].Visible = true; //changes the names to visible
        }


        private void graduatedCylinderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void hydrometerToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void buretteToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void thermometerToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void analyticalBalanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public void setLowValue()
        {
            double lowest = Convert.ToDouble(dataGridView1.Rows[dataGridView1.RowCount - 2].Cells[1].Value);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value) < lowest && Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) > 0)
                {
                    lowest = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                }

            }
            lowValue = lowest;
        }

        public void setHighValue()
        {
            double highest = Convert.ToDouble(dataGridView1.Rows[1].Cells[1].Value);
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) > highest)
                {
                    highest = Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value);
                }

            }
            highValue = highest;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void findAverage()
        {
            //finds the average and puts this value in the average textbox (textBox3)
            double total = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                total += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);

            }

            total = total / (dataGridView1.RowCount - 1);
            textBox3.Text = Convert.ToString(total);
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Prototype1._0.ExcelUtility excelUtility = new Prototype1._0.ExcelUtility();
            excelUtility.WriteDataTableToExcel(theMasterDataTable, "ChemInfo", "@C:/", "Details");


        }


        private void localDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(created == true)
            {
                Form3 form3 = new Form3();
                form3.Show();
            }
            else
            {

                //Add the labels to each dataContainer
                theDataContainerGraduatedCylinder.Columns.Add("Names");
                theDataContainerHydrometer.Columns.Add("Names");
                theDataContainerBurette.Columns.Add("Names");
                theDataContainerThermometer.Columns.Add("Names");
                theDataContainerBalance.Columns.Add("Names");
                theMasterDataTable.Columns.Add("Names");

                theDataContainerGraduatedCylinder.Columns.Add("Values");
                theDataContainerHydrometer.Columns.Add("Values");
                theDataContainerBurette.Columns.Add("Values");
                theDataContainerThermometer.Columns.Add("Values");
                theDataContainerBalance.Columns.Add("Values");

                theDataContainerGraduatedCylinder.Columns.Add("Sig Figs");
                theDataContainerHydrometer.Columns.Add("Sig Figs");
                theDataContainerBurette.Columns.Add("Sig Figs");
                theDataContainerThermometer.Columns.Add("Sig Figs");
                theDataContainerBalance.Columns.Add("Sig Figs");

                theDataContainerGraduatedCylinder.Columns.Add("Units");
                theDataContainerHydrometer.Columns.Add("Units");
                theDataContainerBurette.Columns.Add("Units");
                theDataContainerThermometer.Columns.Add("Units");
                theDataContainerBalance.Columns.Add("Units");

                theDataContainerGraduatedCylinder.Columns.Add("Counted Values");
                theDataContainerHydrometer.Columns.Add("Counted Values");
                theDataContainerBurette.Columns.Add("Counted Values");
                theDataContainerThermometer.Columns.Add("Counted Values");
                theDataContainerBalance.Columns.Add("Counted Values");

                theMasterDataTable.Columns.Add("Graduated Cylinder");
                theMasterDataTable.Columns.Add("Hydrometer");
                theMasterDataTable.Columns.Add("Burette");
                theMasterDataTable.Columns.Add("Thermometer");
                theMasterDataTable.Columns.Add("Analytical Balance");
                created = true;

                Form3 form3 = new Form3();
                form3.Show();
                
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //gets rid of outliers specified by the instructor
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value != null)
                    {
                        if (Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString()) < Convert.ToDouble(textBox1.Text) || Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value.ToString()) > Convert.ToDouble(textBox2.Text))
                        {
                            DataGridViewCell newCell = dataGridView1.Rows[i].Cells[4];
                            newCell.Value = 0;
                        }
                    }

                }
                if (lowValue < Convert.ToDouble(textBox1.Text))
                {
                    this.setLowValue();
                }
                if (highValue > Convert.ToDouble(textBox2.Text))
                {
                    this.setHighValue();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not compare high and low values. Please double check that both a high and low value is inputted. \nOriginal error " + ex.Message);
            }
        }

        private void graduatedCylinderToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = theDataContainerGraduatedCylinder; //changes the dataSource to the Graduated Cylinder
            this.findAverage();
            findStandardDev();

            //changes the image to the new image
            pictureBox1.Image = Properties.Resources._25014;
            pictureBox1.Refresh();
            pictureBox1.Visible = true;

        }

        private void hydrometerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = theDataContainerHydrometer;
            this.findAverage();
            findStandardDev();

            //changes the image to the new image
            pictureBox1.Image = Properties.Resources._25014;
            pictureBox1.Refresh();
            pictureBox1.Visible = true;

        }

        private void buretteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = theDataContainerBurette;
            this.findAverage();
            findStandardDev();

            pictureBox1.Image = Properties.Resources.Capture22;
            pictureBox1.Refresh();
            pictureBox1.Visible = true;
        }

        private void thermometerToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = theDataContainerThermometer;
            this.findAverage();
            findStandardDev();

            pictureBox1.Image = Properties.Resources._71Bt_oSijtL__SL1500_;
            pictureBox1.Refresh();
            pictureBox1.Visible = true;
        }

        private void analyticalBalanceToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = theDataContainerBalance;
            this.findAverage();
            findStandardDev();

            pictureBox1.Image = Properties.Resources._118976197_183548856633170_5248159684347062085_o;
            pictureBox1.Refresh();
            pictureBox1.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void findStandardDev()
        {
            //first find the mean of the dataset 
            double mean = 0;
            int count = 0;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[i].Cells[4].Value) != 0)
                {
                    mean += Convert.ToDouble(dataGridView1.Rows[i].Cells[1].Value);
                    count++;

                }
            }
            mean = mean / count;

            //next subtract each of the numbers and square the result && add up all the values 
            double runningTotal = 0;
            for (int j = 0; j < dataGridView1.RowCount; j++)
            {
                if (Convert.ToDouble(dataGridView1.Rows[j].Cells[4].Value) != 0)
                {
                    double temp = mean - Convert.ToDouble(dataGridView1.Rows[j].Cells[1].Value);
                    runningTotal = temp * temp;
                }

            }
            runningTotal = runningTotal / count;

            textBox5.Text = Convert.ToString(Math.Sqrt(runningTotal));

        }

        private void instructorValuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void calculateGradesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //add new columns to each datatable 
            theDataContainerGraduatedCylinder.Columns.Add("Graded Value");
            theDataContainerHydrometer.Columns.Add("Graded Value");
            theDataContainerBurette.Columns.Add("Graded Value");
            theDataContainerThermometer.Columns.Add("Graded Value");
            theDataContainerBalance.Columns.Add("Graded Value");
            theMasterDataTable.Columns.Add("Total Grade (Out of 5)");

            //look at the values in each given table and determine if it is within the correct tolerance 
            for (int i = 0; i < theDataContainerGraduatedCylinder.Rows.Count; i++)
            {
                if (Convert.ToDouble(theDataContainerGraduatedCylinder.Rows[i][1]) > (instructorValues[0] + tolerances[0]) || Convert.ToDouble(theDataContainerGraduatedCylinder.Rows[i][1]) < (instructorValues[0] - tolerances[0]))
                {
                    theDataContainerGraduatedCylinder.Rows[i].BeginEdit();
                    theDataContainerGraduatedCylinder.Rows[i][5] = 0;
                    theDataContainerGraduatedCylinder.Rows[i].AcceptChanges();
                    theDataContainerGraduatedCylinder.Rows[i].EndEdit();
                }
                else
                {
                    theDataContainerGraduatedCylinder.Rows[i].BeginEdit();
                    theDataContainerGraduatedCylinder.Rows[i][5] = 1;
                    theDataContainerGraduatedCylinder.Rows[i].AcceptChanges();
                    theDataContainerGraduatedCylinder.Rows[i].EndEdit();
                }
            }

            for (int i = 0; i < theDataContainerHydrometer.Rows.Count; i++)
            {
                if (Convert.ToDouble(theDataContainerHydrometer.Rows[i][1]) > (instructorValues[1] + tolerances[1]) || Convert.ToDouble(theDataContainerHydrometer.Rows[i][1]) < (instructorValues[1] - tolerances[1]))
                {
                    theDataContainerHydrometer.Rows[i].BeginEdit();
                    theDataContainerHydrometer.Rows[i][5] = 0;
                    theDataContainerHydrometer.Rows[i].AcceptChanges();
                    theDataContainerHydrometer.Rows[i].EndEdit();
                }
                else
                {
                    theDataContainerHydrometer.Rows[i].BeginEdit();
                    theDataContainerHydrometer.Rows[i][5] = 1;
                    theDataContainerHydrometer.Rows[i].AcceptChanges();
                    theDataContainerHydrometer.Rows[i].EndEdit();
                }
            }

            for (int i = 0; i < theDataContainerBurette.Rows.Count; i++)
            {
                if (Convert.ToDouble(theDataContainerBurette.Rows[i][1]) > (instructorValues[2] + tolerances[2]) || Convert.ToDouble(theDataContainerBurette.Rows[i][1]) < (instructorValues[2] - tolerances[2]))
                {
                    theDataContainerBurette.Rows[i].BeginEdit();
                    theDataContainerBurette.Rows[i][5] = 0;
                    theDataContainerBurette.Rows[i].AcceptChanges();
                    theDataContainerBurette.Rows[i].EndEdit();
                }
                else
                {
                    theDataContainerBurette.Rows[i].BeginEdit();
                    theDataContainerBurette.Rows[i][5] = 1;
                    theDataContainerBurette.Rows[i].AcceptChanges();
                    theDataContainerBurette.Rows[i].EndEdit();
                }
            }

            for (int i = 0; i < theDataContainerThermometer.Rows.Count; i++)
            {
                if (Convert.ToDouble(theDataContainerThermometer.Rows[i][1]) > (instructorValues[3] + tolerances[3]) || Convert.ToDouble(theDataContainerThermometer.Rows[i][1]) < (instructorValues[3] - tolerances[3]))
                {
                    theDataContainerThermometer.Rows[i].BeginEdit();
                    theDataContainerThermometer.Rows[i][5] = 0;
                    theDataContainerThermometer.Rows[i].AcceptChanges();
                    theDataContainerThermometer.Rows[i].EndEdit();
                }
                else
                {
                    theDataContainerThermometer.Rows[i].BeginEdit();
                    theDataContainerThermometer.Rows[i][5] = 1;
                    theDataContainerThermometer.Rows[i].AcceptChanges();
                    theDataContainerThermometer.Rows[i].EndEdit();
                }
            }

            for (int i = 0; i < theDataContainerBalance.Rows.Count; i++)
            {
                if (Convert.ToDouble(theDataContainerBalance.Rows[i][1]) > (instructorValues[4] + tolerances[4]) || Convert.ToDouble(theDataContainerBalance.Rows[i][1]) < (instructorValues[4] - tolerances[4]))
                {
                    theDataContainerBalance.Rows[i].BeginEdit();
                    theDataContainerBalance.Rows[i][5] = 0;
                    theDataContainerBalance.Rows[i].AcceptChanges();
                    theDataContainerBalance.Rows[i].EndEdit();
                }
                else
                {
                    theDataContainerBalance.Rows[i].BeginEdit();
                    theDataContainerBalance.Rows[i][5] = 1;
                    theDataContainerBalance.Rows[i].AcceptChanges();
                    theDataContainerBalance.Rows[i].EndEdit();
                }
            }

            for (int i = 0; i < theMasterDataTable.Rows.Count; i++)
            {
                theMasterDataTable.Rows[i].BeginEdit();
                theMasterDataTable.Rows[i][6] = Convert.ToDouble(theDataContainerBalance.Rows[i][5]) + Convert.ToDouble(theDataContainerThermometer.Rows[i][5]) + Convert.ToDouble(theDataContainerBurette.Rows[i][5]) + Convert.ToDouble(theDataContainerHydrometer.Rows[i][5]) + Convert.ToDouble(theDataContainerGraduatedCylinder.Rows[i][5]);
                theMasterDataTable.Rows[i].AcceptChanges();
                theMasterDataTable.Rows[i].EndEdit();
            }

        }

        public void makingTheDataTable()
        {
            dataGridView1.DataSource = theDataContainerGraduatedCylinder; //assign DataTable as Datasource for DataGridview
            dataGridView1.Columns[0].Visible = false; //makes the names invisible originally


            findAverage();
            findStandardDev();
            setHighValue();
            setLowValue();
        }
    }
}
