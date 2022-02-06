using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesLessons.Services;
using RazorPagesLessons.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace RazorPagesGeneral.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public Language Employee { get; set; }
        [BindProperty]
        public IFormFile Photo { get; set; }

        [BindProperty]
        public bool Notify { get; set; }
        public string Massage { get; set; }


        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            if (Employee == null)
                return RedirectToPage("/NotFound");
            return Page();
        }

        public IActionResult OnPost(Language employee)
        {
            if(Photo != null)
            {
                if(employee.PhotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", employee.PhotoPath);
                    System.IO.File.Delete(filePath);
                }

                employee.PhotoPath = ProcessUploadedFile();
            }

            Employee = _employeeRepository.Update(employee);

            TempData["SeccessMessage"] = $"Update{Employee.Name} successful!";

            return RedirectToPage("Employees");
        }


        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
                Massage = "Thank you for turning on notifications";
            else
                Massage = "You have turned off email notifications";

            Employee = _employeeRepository.GetEmployee(id);

        }


        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if(Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using(var fs = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fs);
                }
            }
            return uniqueFileName;
        }

    }
}
