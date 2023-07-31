using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Classes
{
    public class Users : Person
    {
        public DateTime LastLogin { get; set; }
        public string PhotoPath { get; set; }
        public int StudentNum { get; set; }
        public string StudyType { get; set; }
        public string Internship { get; set; }
        public int CurrentCredit { get; set; }
        public int TotalCredit { get; set; }

        public Users(string name, string password, string email, int age, string id, string phoneNumber, DateTime lastLogin, string photoPath, int studentNum, string studyType, string internship, int currentCredit, int totalCredit)
            : base(name, password, email, age, id, phoneNumber)
        {
            LastLogin = lastLogin;
            PhotoPath = photoPath;
            StudentNum = studentNum;
            StudyType = studyType;
            Internship = internship;
            CurrentCredit = currentCredit;
            TotalCredit = totalCredit;
        }
    }
}