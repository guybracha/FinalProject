using FinalProject.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FinalProject
{
    public enum Role
    {
        Student,
        Lecturer,
        HeadOfDepartment
    }

    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string ID { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime LastLogin { get; set; }
        public Role Role { get; set; }

        public User(string name, string password, string email, int age, string id, string phoneNumber, DateTime lastLogin, Role role)
        {
            Name = name;
            Password = password;
            Email = email;
            Age = age;
            ID = id;
            PhoneNumber = phoneNumber;
            LastLogin = lastLogin;
            Role = role;
        }
    }

    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of Form1
            Form1 form1 = new Form1();

            // Start the application loop with Form1
            Application.Run(form1);
        }

        public static List<User> LoadUsersFromRoleFile(string filePath, Role role)
        {
            List<User> users = new List<User>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');

                    string name = data[0];
                    string password = data[1];
                    string email = data[2];
                    int age = int.Parse(data[3]);
                    string id = data[4];
                    string phoneNumber = data[5];
                    DateTime lastLogin = DateTime.Parse(data[6]);

                    User user = new User(name, password, email, age, id, phoneNumber, lastLogin, role);
                    users.Add(user);
                }
            }

            return users;
        }

        public static void SaveUsersToCombinedFile(List<User> users, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (User user in users)
                {
                    string userData = $"{user.Name},{user.Password},{user.Email},{user.Age},{user.ID},{user.PhoneNumber},{user.LastLogin},{user.Role}";
                    writer.WriteLine(userData);
                }
            }
        }
    }
}
