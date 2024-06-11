using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SampleNUnitTestCases.Models;
using System.Data;

namespace SampleNUnitTestCases.Services
{
    public class RegisterSL : IRegister
    {
        private readonly RegisterContext _context;

        public RegisterSL(RegisterContext context)
        {
            _context = context;
        }

        // GET: Registers
        public IEnumerable<SignUp> GetAllEmployee()
        {
            return _context.Registers.ToList();
        }

        // GET: Registers/Details/5
        public SignUp GetDetailsById(int? id)
        {
         return _context.Registers.FirstOrDefault(m => m.Id == id);

        }

        public SignUp AddEmployee(SignUp Reg)
        {
            SignUp data = new SignUp();
            if (data.Id == 0)
            {
                data.UserName = Reg.UserName;
                data.City = Reg.City;
                data.Email = Reg.Email;
                data.Password = Reg.Password;
                _context.Registers.Add(data);
                _context.SaveChanges();
            }

            return Reg;
        }

        public void RemoveEmployee(int id)
        {
            var reg = GetDetailsById(id);
            _context.Registers.Remove(reg);
            _context.SaveChanges();
        }

       public  int UpdateEmployee(SignUp register)
        {
            int updatedregisters = _context.SaveChanges();
            return updatedregisters;
        }
    }
}
