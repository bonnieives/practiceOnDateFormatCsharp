using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Coded by Bonnie Ives de Castro Nunes - 2023/03/16
// This code calculate due days between the date informed by the user and
// the actual day. Also it calculates the age based on the input birth date

namespace exerciseDate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime currentDateTime = DateTime.Now;
            DateTime inDate;
            try
            {
                inDate = DateTime.Parse(textBox1.Text.Trim());
                TimeSpan timeTillDue = inDate.Subtract(currentDateTime);
                int daysTillDue = timeTillDue.Days;

                if (daysTillDue > 0)
                {
                    MessageBox.Show("Current Date: " + currentDateTime.ToString("MM'/'dd'/'yyyy") + "\n\n" +
                        "Future Date: " + inDate.ToString("MM'/'dd'/'yyyy") + "\n\n" +
                        "Days until due: " + daysTillDue.ToString(), "Due Days Calculation");
                }
                else if (daysTillDue == 0)
                {
                    MessageBox.Show("Is due today.", "Due Days Calculation");
                }
                else
                {
                    MessageBox.Show("Past due.", "Due Days Calculation");
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "An error occurred");
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var inDate = DateTime.Parse(textBox2.Text.Trim());
                var currentDateTime = DateTime.Today;
                var ageYear = currentDateTime.Year - inDate.Year;
                
                if (currentDateTime.Month < inDate.Month)
                {
                    ageYear = ageYear - 1;
                }
                else if (currentDateTime.Month == inDate.Month && currentDateTime.Day < inDate.Day)
                {
                    ageYear = ageYear - 1;
                }

                if (currentDateTime == inDate)
                {
                    MessageBox.Show("Happy Birthday.", "Have a piece of cake!");
                }
                else
                {
                    MessageBox.Show("Current Date: " + 
                        currentDateTime.ToString("dddd, MMMM dd, yyyy") + "\n\n" + 
                        "Birth Date: " + inDate.ToString("dddd, MMMM dd, yyyy") + "\n\n" +
                        "Age: " + ageYear.ToString(), "Age Calculation");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "An error occurred");
            }
        }
    }
}
