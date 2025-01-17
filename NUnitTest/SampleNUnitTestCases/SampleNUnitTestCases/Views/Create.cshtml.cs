﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SampleNUnitTestCases.Models;

namespace SampleNUnitTestCases.Views
{
    public class CreateModel : PageModel
    {
        private readonly SampleNUnitTestCases.Models.RegisterContext _context;

        public CreateModel(SampleNUnitTestCases.Models.RegisterContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public SignUp Register { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Registers.Add(Register);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
