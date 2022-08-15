using System;
using System.IO;
using Checkfile;
using System.Windows.Forms;
using employeeListAndTask.cs;
using System.Threading.Tasks;

namespace employeeListAndTask
{
    
    public partial class Form1 : Form
    {
        private const string pht = @"C:\SaveEmployee";
        private const string MD = "Not set";

        private static string[] dataFirstNames;
        private static string[] dataLastNames;

        private string[] dataJ;
        private string[] IsDoneJoba;


        public Form1()
        {
            InitializeComponent();

            if (!Directory.Exists(pht))
            {
                Directory.CreateDirectory(pht);
            }

            CheckFile checkFile = new CheckFile();
            checkFile.ChcekFile();

            dataFirstNames = File.ReadAllLines(checkFile.phtFirstName);
            dataLastNames = File.ReadAllLines(checkFile.phtLastName);
            dataJ = File.ReadAllLines(checkFile.phtjobs);
            IsDoneJoba = File.ReadAllLines(checkFile.phtjobsDone);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.ShowDialog();
            Add();
        }
        /// <summary>
        /// add Value to data grid 
        /// </summary>
        public void Add()
        {
            dataGridView1.Refresh();
            dataGridView1.Rows.Add(EmployeeData.FirstName, EmployeeData.LastName, EmployeeData.Job, EmployeeData.ProcessJob, EmployeeData.DoneJob);

            CheckFile checkFile = new CheckFile();
            checkFile.AddToFile(EmployeeData.FirstName,EmployeeData.LastName,EmployeeData.ProcessJob,EmployeeData.DoneJob,EmployeeData.Job);
        }
        private async void button2_Click(object sender, EventArgs e)
        {
            await LoadingData();
            dataFirstNames = Array.Empty<string>();
            dataJ = Array.Empty<string>();
        }
        int i = 0;
        /// <summary>
        /// Loading data from file to dataGridView
        /// </summary>
        private async Task LoadingData()
        {
            foreach(var item in dataFirstNames)
            {
                try
                {
                   if (IsDoneJoba.Length > i)
                         dataGridView1.Rows.Add(dataFirstNames[i], dataLastNames[i], dataJ[i], dataJ[i], IsDoneJoba[i]);
                    else
                        dataGridView1.Rows.Add(dataFirstNames[i], dataLastNames[i], dataJ[i], dataJ[i], MD);
                    i++;
                    await Task.Delay(1);
                    label1.Text = " Check file : " + dataFirstNames.Length / 2;
                    
                }
                catch (Exception)
                {
                    MessageBox.Show("Error");
                    return;
                }
            }
        }
    }
}
