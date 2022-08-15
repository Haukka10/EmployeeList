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
        public string phtjobs = @"C:\SaveEmployee\EmployeeJobs.txt";
        public string phtLastName = @"C:\SaveEmployee\LastName.txt";
        public string phtjobsDone = @"C:\SaveEmployee\EmployeeJobIsDone.txt";

        public List<string> Firstname = new List<string>();
        public List<string> Lastname = new List<string>();
        public List<string> Jobs = new List<string>();
        public List<string> IsDone = new List<string>();

        /// <summary>
        /// Check file to exists if not create this 
        /// </summary>
        
        public void ChcekFile()
        {
            if (File.Exists(phtFirstName) && File.Exists(phtjobsDone) && File.Exists(phtjobs) && File.Exists(phtLastName))
            {
                Console.WriteLine("files is exists!");
            }
            else
            {
                File.Create(phtFirstName);
                File.Create(phtLastName);
                File.Create(phtjobs);
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

            Jobs.Add(pj);
            Jobs.Add(nj);
            IsDone.Add(dj);

            File.WriteAllLinesAsync(phtFirstName, Firstname, System.Text.Encoding.Unicode);
            File.WriteAllLinesAsync(phtLastName, Lastname, System.Text.Encoding.Unicode);

            File.WriteAllLinesAsync(phtjobsDone, IsDone, System.Text.Encoding.Unicode);
            File.WriteAllLinesAsync(phtjobs, Jobs, System.Text.Encoding.Unicode);
        }
    }
}