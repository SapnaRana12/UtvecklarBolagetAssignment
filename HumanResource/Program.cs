using System;
using System.Collections.Generic;
using System.Linq;

namespace HumanResource
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeeAtLevel = -1;
            getEmployee(employeeAtLevel);


        }
        private static string TopLevelEmployee()
        {
            return "Sapna";
        }

        private static List<string> GetManagedEmployees(string EmpName)
        {

            List<string> lstofEmp = new List<string>();
            if (EmpName == "Rana")
            {
                lstofEmp.Add("Supriyo");
                lstofEmp.Add("Angel");
                
            }
            else if(EmpName == "Soni")
            {
                lstofEmp.Add("Narendra");
                lstofEmp.Add("ChandraPrabha");
                lstofEmp.Add("Sunny");
            }
            else if(EmpName == "Sapna")
            {
                lstofEmp.Add("Rana");
                lstofEmp.Add("Soni");
                lstofEmp.Add("Soni1");
            }
            


                return lstofEmp;

        }

        private static void getEmployee(int employeeAtLevel)
        {
            List<int> lstEmpList = new List<int>();

            string topLevelEmpName = TopLevelEmployee();
            List<string> lstinternalemplyoolst = new List<string>();
            if (topLevelEmpName != string.Empty)
            {
                lstEmpList.Add(1);
                List<string> lstemplyoolst = GetManagedEmployees(topLevelEmpName);
                lstEmpList.Add(lstemplyoolst.Count);


                int i = 1;
                do
                {
                    int perlevelemp = 0;


                    foreach (var emp in lstemplyoolst)
                    {

                        lstinternalemplyoolst.AddRange(GetManagedEmployees(emp));
                        perlevelemp = lstinternalemplyoolst.Count;

                        if (perlevelemp != 0)
                        {
                            i = 1;

                        }
                        else
                        {
                            i = 0;
                        }
                    }
                    if (perlevelemp != 0)
                        lstEmpList.Add(perlevelemp);
                    if (perlevelemp != 0)
                    {
                        lstemplyoolst = new List<string>();
                        lstemplyoolst.AddRange(lstinternalemplyoolst);
                        lstinternalemplyoolst = new List<string>();
                    }


                } while (i > 0);

                if (lstEmpList.Count > 0 )
                {
                    if(employeeAtLevel != -1 && lstEmpList.Count-1 <= employeeAtLevel)                    
                    Console.WriteLine("The Employees in the Organization is at Level of" + employeeAtLevel + "is" + lstEmpList[employeeAtLevel]);
                    else if(employeeAtLevel != -1 && lstEmpList.Count - 1 > employeeAtLevel)
                        Console.WriteLine("The Employees in the Organization is at Level of "+ employeeAtLevel + " is 0" );
                    else
                    {
                        Console.WriteLine("The total Employees in the Organization is" + lstEmpList.Sum());
                    }

                }
            }
            else
            {
                Console.WriteLine("there is no employee");
            }
        }
    }
   
}
