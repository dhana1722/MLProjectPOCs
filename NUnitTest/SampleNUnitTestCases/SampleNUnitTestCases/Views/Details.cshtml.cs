﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleNUnitTestCases.Models;

namespace SampleNUnitTestCases.Views
{
    public class DetailsModel : PageModel
    {
        private readonly SampleNUnitTestCases.Models.RegisterContext _context;

        public DetailsModel(SampleNUnitTestCases.Models.RegisterContext context)
        {
            _context = context;
        }

        public SignUp Register { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var register = await _context.Registers.FirstOrDefaultAsync(m => m.Id == id);
            if (register == null)
            {
                return NotFound();
            }
            else
            {
                Register = register;
            }
            return Page();
        }
    }
}
