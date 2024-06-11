using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Moq;
using SampleNUnitTestCases.Controllers;
using SampleNUnitTestCases.Services;
using SampleNUnitTestCases.Models;
using NuGet.Protocol;
using System.Text.Json.Nodes;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeUnitTest.Controller
{
    public class Tests
    {
        Mock<IRegister> _registerMock;

        [SetUp]
        public void Setup()
        {
            _registerMock = new Mock<IRegister>();
        }

        [Test]
        public void AddEmployee_HappyPath_Success()
        {
            List<SignUp> users = GetSampleUsers();
            SignUp newusers = users[0];
            RegistersController sut = new RegistersController(_registerMock.Object);
            _registerMock.Setup(x => x.AddEmployee(newusers)).Returns(newusers);
            Object result = sut.Create(newusers);
            Assert.IsInstanceOf<Object>(result.GetHashCode());
        }
        [Test]
        public void Index_ListOfUsers_UsersExistsInRepo()
        {

            RegistersController obj = new RegistersController(_registerMock.Object);

            var actResult = obj.Index() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("Index"));
        }

        [Test]
        public void GetDetailsById_Test_Users()
        {
            List<SignUp> users = GetSampleUsers();
            SignUp firstuser = users[1];
            _registerMock.Setup(x => x.GetDetailsById(1))
                .Returns(firstuser);
            RegistersController sut = new RegistersController(_registerMock.Object);
            ActionResult<SignUp> result = sut.Details(1);
            var value = ((SampleNUnitTestCases.Models.SignUp)((Microsoft.AspNetCore.Mvc.ViewResult)result.Result).Model).Id;
            Assert.AreEqual(firstuser.Id,value);

        }


        private List<SignUp> GetSampleUsers()
        {
            List<SignUp> users = new List<SignUp>()
            {
              new SignUp
                {
                  Id=1,
                  Email="dhanu@gmail.com",
                  Password="123456",
                  UserName="dhanu",
                  City="wgl",
                  },
                new SignUp
                {
                   Id=2,
                  Email="imran@gmail.com",
                  Password="123456",
                  UserName="imran",
                  City="hyd",

                },

            };
            return users;
        }

    }
}