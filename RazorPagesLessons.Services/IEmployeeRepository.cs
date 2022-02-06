using System;
using System.Collections.Generic;
using System.Text;
using RazorPagesLessons.Models;


namespace RazorPagesLessons.Services
{
    public interface IEmployeeRepository
    {
        IEnumerable<Language> GetAllLanguage();
        Language GetLanguage(int id);

        Language Update(Language updatedEmployee);
    }
}

