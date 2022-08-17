using System;
using System.IO;
using System.Collections.Generic;

namespace Checkfile
{
    /// <summary>
    /// All operation on file 
    /// </summary>
    internal class CheckFile
    {
        public string phtFirstName = @"C:\SaveEmployee\FirstName.txt";
        public string phtjobsName = @"C:\SaveEmployee\EmployeeJobsName.txt";
        public string phtjobsProcess = @"C:\SaveEmployee\EmployeeJobsProcess.txt";
        public string phtLastName = @"C:\SaveEmployee\LastName.txt";
        public string phtjobsDone = @"C:\SaveEmployee\EmployeeJobIsDone.txt";

        public List<string> JobsProcess = new List<string>();
        public List<string> Firstname = new List<string>();
        public List<string> Lastname = new List<string>();
        public List<string> JobsName = new List<string>();
        public List<string> IsDone = new List<string>();

        /// <summary>
        /// Check file to exists if not create this 
        /// </summary>
        
        public void ChcekFile()
        {
            if (File.Exists(phtFirstName) && File.Exists(phtjobsDone) && File.Exists(phtjobsProcess) && File.Exists(phtLastName)&&File.Exists(phtjobsName))
            {
                Console.WriteLine("files is exists!");
            }
            else
            {
                File.Create(phtFirstName);
                File.Create(phtLastName);
                File.Create(phtjobsName);
                File.Create(phtjobsProcess);
                File.Create(phtjobsDone);
            }
        }

        /// <summary>
        /// Add to file text 
        /// </summary>
        
        public void AddToFile(string FirstName,string LastName, int? ProcessJob, bool? DoneJob, string Job)
        {
            Firstname.Add(FirstName);
            Lastname.Add(LastName);

            string pj = ProcessJob.ToString();
            string dj = DoneJob.ToString();
            string nj = Job.ToString();

            JobsProcess.Add(pj);
            JobsName.Add(nj);
            IsDone.Add(dj);

            File.WriteAllLinesAsync(phtFirstName, Firstname, System.Text.Encoding.Unicode);
            File.WriteAllLinesAsync(phtLastName, Lastname, System.Text.Encoding.Unicode);

            File.WriteAllLinesAsync(phtjobsDone, IsDone, System.Text.Encoding.Unicode);
            File.WriteAllLinesAsync(phtjobsName, JobsName, System.Text.Encoding.Unicode);
            File.WriteAllLinesAsync(phtjobsProcess, JobsProcess, System.Text.Encoding.Unicode);
        }
    }
}