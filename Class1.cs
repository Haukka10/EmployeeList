using System;
using System.Collections.Generic;
using System.Text;
using employeeListAndTask.cs.Iinterface;

namespace employeeListAndTask.cs
{
    internal class EmployeeData : Interface1
    {
        public static string LastName { set; get; } = "Not set";
        public static string FirstName { set; get; } = "Not set";
        public static string Job { set; get; } = "Not set";
        public static int? ProcessJob { set; get; }
        public static bool? DoneJob { set; get; }
        // add employee
        public void AddEmployee(string Fname,string Lname,string job, int process,bool donejob)
        {
            LastName = Lname;
            FirstName = Fname;
            Job = job;
            DoneJob = donejob;
            ProcessJob = process;
        }
        public void SetEmployee(string Fname, string Lname, string job, int process, bool donejob)
        {
            job = Job;
            Lname = LastName;
            Fname = FirstName;
            donejob = (bool)DoneJob;
            process = (int)ProcessJob;
        }
        // remove employee 
        public void RemoveEmployee()
        {
            LastName = null;
            FirstName = null;
            Job = null;
            ProcessJob = null;

            if (DoneJob == true || DoneJob == false)
                DoneJob = null;
            else
                return;
        }
    }
}
