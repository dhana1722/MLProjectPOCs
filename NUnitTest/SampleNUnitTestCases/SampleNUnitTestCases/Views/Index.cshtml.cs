using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SampleNUnitTestCases.Models;

namespace SampleNUnitTestCases.Views
{
    public class IndexModel : PageModel
    {
        private readonly SampleNUnitTestCases.Models.RegisterContext _context;

        public IndexModel(SampleNUnitTestCases.Models.RegisterContext context)
        {
            _context = context;
        }

        public IList<SignUp> Register { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Register = await _context.Registers.ToListAsync();
        }
    }
}
