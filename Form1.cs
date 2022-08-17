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

        private string[] dataJobsName;
        private string[] dataJobsProcess;
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

            dataJobsProcess = File.ReadAllLines(checkFile.phtjobsProcess);
            dataFirstNames = File.ReadAllLines(checkFile.phtFirstName);
            dataLastNames = File.ReadAllLines(checkFile.phtLastName);
            dataJobsName = File.ReadAllLines(checkFile.phtjobsName);
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
            dataJobsProcess = Array.Empty<string>();
            dataJobsName = Array.Empty<string>();
            dataJobsName = Array.Empty<string>();
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
                   if (IsDoneJoba.Length > i && dataLastNames.Length > i && dataJobsProcess.Length > i && dataJobsName.Length > i)
                         dataGridView1.Rows.Add(dataFirstNames[i], dataLastNames[i], dataJobsName[i], dataJobsProcess[i], IsDoneJoba[i]);
                    else
                        dataGridView1.Rows.Add(dataFirstNames[i], MD, MD, MD, MD);
                    i++;
                    await Task.Delay(1);

                    label1.Text = " Check file : " + dataFirstNames.Length / 2;

                    bool a = int.TryParse(dataJobsProcess[i], out int Value);

                    progressBar1.Value = Value;
                    
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
