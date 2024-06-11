using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleNUnitTestCases.Models;
using SampleNUnitTestCases.Services;

namespace SampleNUnitTestCases.Controllers
{
    public class RegistersController : Controller
    {
       private readonly IRegister _repo;

        public RegistersController(IRegister repo)
        {
            _repo = repo;
        }

        // GET: Registers
        public ViewResult Index()
        {
            return View("Index",_repo.GetAllEmployee());
        }

        // GET: Registers/Details/5
        public ActionResult<SignUp> Details(int? id)
        {
            var register = _repo.GetDetailsById(id);
            if (register == null)
            {
                return NotFound();
            }

            return View("Details",register);
        }

        // GET: Registers/Create
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Create([Bind("Id,Email,Password,UserName,City")] SignUp register)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEmployee(register);
                return RedirectToAction(nameof(Index));
            }
            return View("Create",register);
        }

        // GET: Registers/Edit/5
        public ActionResult Edit(int? id)
        {
            var register = _repo.GetDetailsById(id);
            if (register == null)
            {
                return NotFound();
            }
            return View("Edit",register);
        }

        // POST: Registers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind("Id,Email,Password,UserName,City")] SignUp register)
        {

            SignUp reg = _repo.GetDetailsById(id);
            try
            {
                _repo.UpdateEmployee(register);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                    ViewData["EditError"] = ex.InnerException.ToString();
                else
                    ViewData["EditError"] = ex.ToString();
            }
            foreach (var modelState in ModelState.Values)
            {
                foreach (var error in modelState.Errors)
                {
                    if (error.Exception != null)
                    {
                        throw modelState.Errors[0].Exception;
                    }
                }
            }
            return View(reg);
        }

        // GET: Registers/Delete/5
        public ActionResult Delete(int? id)
        {
            var register = _repo.GetDetailsById(id);
            if (register == null)
            {
                return NotFound();
            }

            return View("Delete",register);
        }

        // POST: Registers/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var register = _repo.GetDetailsById(id);
            if (register != null)
            {
                _repo.RemoveEmployee(id);
                return RedirectToAction(nameof(Index));
            }
            return View(register);
        }
    }
}