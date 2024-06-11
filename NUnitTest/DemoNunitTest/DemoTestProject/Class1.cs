using DemoNunitTest;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTestProject
{
    [TestFixture]
    public class DemoTests
    {
        List<EmployeeDetails> li;
        [Test]
        public void TestLogin()
        {
            Program pobj = new Program();
            string x = pobj.Login("Aravind", "1234");
            string y = pobj.Login("", "");
            string z = pobj.Login("Admin", "Admin");
            Assert.Equals("Userid or password could not be Empty.", y);
            Assert.Equals("Incorrect UserId or Password.", x);
            Assert.Equals("Welcome Admin.", z);
        }
    }
}
