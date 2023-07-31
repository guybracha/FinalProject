using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProject.Classes
{
    public class Login
    {
        public ArrayList usernames;
        public ArrayList passwords;
        public string filePath;

        public Login(string filePath)
        {
            this.filePath = filePath;
            usernames = LoadUsernames(filePath);
            passwords = LoadPasswords(filePath);
        }

        public Login()
        {
        }

        private ArrayList LoadUsernames(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            ArrayList usernames = new ArrayList();

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (values.Length == 2)
                {
                    string username = values[0];
                    usernames.Add(username);
                }
            }

            return usernames;
        }

        private ArrayList LoadPasswords(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            ArrayList passwords = new ArrayList();

            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (values.Length == 2)
                {
                    string password = values[1];
                    passwords.Add(password);
                }
            }

            return passwords;
        }

        public static bool CheckCredentials(string filePath, string username, string password)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] credentials = line.Split(',');
                string storedUsername = credentials[0].Trim();
                string storedPassword = credentials[1].Trim();

                if (storedUsername == username && storedPassword == password)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckUsernameExists(string filePath, string username)
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] credentials = line.Split(',');
                string storedUsername = credentials[0].Trim();

                if (storedUsername == username)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
