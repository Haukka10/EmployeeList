using System;
using System.Collections.Generic;
using System.Text;

namespace employeeListAndTask.cs.Iinterface
{
    internal interface Interface1
    {

        void AddEmployee(string Fname, string Lname, string job, int process, bool donejob);
        public void SetEmployee(string Fname, string Lname, string job, int process, bool donejob);
        void RemoveEmployee();
    }
}
