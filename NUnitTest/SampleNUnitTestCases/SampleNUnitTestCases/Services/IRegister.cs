using SampleNUnitTestCases.Models;

namespace SampleNUnitTestCases.Services
{
    public interface IRegister
    {
        SignUp AddEmployee(SignUp Reg);
        public void RemoveEmployee(int id);
        public IEnumerable<SignUp> GetAllEmployee();
        public SignUp GetDetailsById(int? id);
        public int UpdateEmployee(SignUp register);

    }
}
