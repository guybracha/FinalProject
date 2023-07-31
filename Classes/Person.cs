using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Classes
{
    public class Person
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string PhoneNumber { get; set; }

        public Person(string name, string password, string email, int age, string id, string phoneNumber)
        {
            Name = name;
            Password = password;
            Email = email;
            Age = age;
            ID = id;
            PhoneNumber = phoneNumber;
        }
    }

    public class Student : Person
    {
        public DateTime LastLogin { get; set; }
        public string PhotoPath { get; set; } // Add the PhotoPath property

        public Student(string name, string password, string email, int age, string id, string phoneNumber, DateTime lastLogin)
            : base(name, password, email, age, id, phoneNumber) // Call base class constructor
        {
            LastLogin = lastLogin;
        }
    }

    public class Lecturer : Person
    {
        public int WorkerNum { get; set; }
        public List<string> Lectures { get; set; }
        public string Experience { get; set; }
        public int Stars { get; set; }

        public Lecturer(string name, string password, string email, int age, string id, string phoneNumber, int workerNum, string experience, int stars)
            : base(name, password, email, age, id, phoneNumber)
        {
            WorkerNum = workerNum;
            Lectures = new List<string>();
            Experience = experience;
            Stars = stars;
        }
    }

    public class HeadClass : Person
    {
        public int HeadNum { get; set; }
        public List<string> Courses { get; set; }
        public List<string> Lecturers { get; set; }
        public List<string> Students { get; set; }

        public HeadClass(string name, string password, string email, int age, string id, string phoneNumber, int headNum)
            : base(name, password, email, age, id, phoneNumber)
        {
            HeadNum = headNum;
            Courses = new List<string>();
            Lecturers = new List<string>();
            Students = new List<string>();
        }
    }
}
