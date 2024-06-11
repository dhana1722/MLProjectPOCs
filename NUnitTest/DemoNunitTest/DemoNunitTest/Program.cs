using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoNunitTest
{
    public class Program
    {
        public string Login(string UserId, string Password)
        {
            if(string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(Password))
            {
                return "Userid or password could not be Empty.";
            }
            else
            {
                if(UserId == "Admin" &&  Password == "Admin")
                {
                    return "Welcome Admin";
                }
                return "Incorrect UserId or Password.";
            }

        }
        public List<EmployeeDetails> AllUsers()
        {
            List<EmployeeDetails> li = new List<EmployeeDetails>();
            li.Add(new EmployeeDetails
            {
                id = 100,
                Name = "raju",
                Gender = "male",
                salary = 40000
            });
            li.Add(new EmployeeDetails
            {
                id = 101,
                Name = "dhanu",
                Gender = "Female",
                salary = 50000
            });
            li.Add(new EmployeeDetails
            {
                id = 103,
                Name = "ramu",
                Gender = "male",
                salary = 40000
            });
            li.Add(new EmployeeDetails
            {
                id = 104,
                Name = "Anil",
                Gender = "male",
                salary = 23000
            });
            li.Add(new EmployeeDetails
            {
                id = 105,
                Name = "Manasi",
                Gender = "Female",
                salary = 80000
            });
            li.Add(new EmployeeDetails
            {
                id = 106,
                Name = "Ranjit",
                Gender = "male",
                salary = 670000
            });
            return li;
        }
        
        static void Main(string[] args)
        {
        }
    }
}
