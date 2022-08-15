using System;
using System.Windows.Forms;
using employeeListAndTask.cs;
using employeeListAndTask;

namespace employeeListAndTask
{
    public partial class Form2 : Form
    {
        private string First, Last , job;
        private int prcess;
        private bool IsDone;
        private const string set = "You set 0";
        private const string sure = "You sure ?";
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void button1_Click(object sender, EventArgs e)
        {
            First = textBox1.Text;
            Last = textBox2.Text;
            job = textBox3.Text;

            bool isNum = int.TryParse(textBox4.Text, out prcess);

            IsDone = checkBox1.Checked;

            if (prcess == 0)
            {
                var a = MessageBox.Show(set, sure, MessageBoxButtons.YesNo);

                if(a == DialogResult.Yes)
                {
                    prcess = 0;
                    EmployeeData @class = new EmployeeData();
                    @class.AddEmployee(First, Last, job, prcess, IsDone);
                }
                if (a == DialogResult.No)
                {
                    First = String.Empty;
                    Last = String.Empty;
                    job = String.Empty;

                }
            }

            if (prcess != 0)
            {
                EmployeeData @class = new EmployeeData();
                @class.AddEmployee(First, Last, job, prcess, IsDone);
            }
            this.Close();
        }
    }
}
