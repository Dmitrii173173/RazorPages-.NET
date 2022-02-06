using System;
using System.Collections.Generic;
using System.Text;
using RazorPagesLessons.Models;
using System.Linq;


namespace RazorPagesLessons.Services
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Language> _languageList;
        public MockEmployeeRepository()
        {
            _languageList = new List<Language>()
            {
                new Language()
                {
                    Id = 0, Name = "English" , Email = "dmitrii@gmail.com" , PhotoPath = "English.jpg", Department = Dept.HR
                },

                new Language()
                {
                    Id = 1, Name = "Chinese" , Email = "egor@gmail.com" , PhotoPath = "Chinese.jpg", Department = Dept.IT
                },

                new Language()
                {
                    Id = 2, Name = "French" , Email = "bermet@gmail.com" , PhotoPath = "French.jpg", Department = Dept.IT
                },

                new Language()
                {
                    Id = 3, Name = "Japanese" , Email = "alexei@gmail.com" , PhotoPath = "Japanese.jpg", Department = Dept.Payroll
                },

                new Language()
                {
                    Id = 4, Name = "German" , Email = "stas@gmail.com" , PhotoPath = "German.jpg", Department = Dept.HR
                },

                new Language()
                {
                    Id = 5, Name = "Thai" , Email = "god@gmail.com" , PhotoPath = "Thai.jpg" , Department = Dept.Payroll
                }

            };
        }

        public IEnumerable<Language> GetAllLanguage()
        {
            return _languageList;
        }

        public Language GetLanguage(int id)
        {
            return _languageList.FirstOrDefault(x => x.Id == id);
        }

        public Language Update(Language updatedLanguage)
        {
            Language language = _languageList.FirstOrDefault(x => x.Id == updatedLanguage.Id);

            if (language != null)
            {
                language.Name = updatedLanguage.Name;
                language.Email = updatedLanguage.Email;
                language.Department = updatedLanguage.Department;
                language.PhotoPath = updatedLanguage.PhotoPath;


            }
            return language;
        }
    }

}