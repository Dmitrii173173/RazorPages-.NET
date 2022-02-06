using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Models;
using RazorPagesLessons.Services;

namespace RazorPagesGeneral.Pages.Employees
{
    public class DetailsModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;

        public DetailsModel(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Language Employee { get; private set; }

        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            // Lesson 6
            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }
    }
}
