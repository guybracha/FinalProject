using FinalProject.Classes;
using FinalProject.Forms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        Login login;
        private Person user;

        public Form1()
        {
            InitializeComponent();
            login = new Login();
            this.BackgroundImage = Properties.Resources.AU1_3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // user name
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            // user password
        }


        private void button1_Click(object sender, EventArgs e)
        {
            checkCred();
        }

        private void checkCred()
        {
            string combinedPath = "C:\\Users\\guybr\\source\\repos\\FinalProject\\UsersTxt\\Combined.txt";
            string username = richTextBox1.Text.Trim();
            string password = richTextBox2.Text.Trim();

            bool isRegistered = IsUserRegistered(combinedPath, username, password);

            if (isRegistered)
            {
                this.Hide();

                string studentsPath = "C:\\Users\\guybr\\source\\repos\\FinalProject\\UsersTxt\\Students.txt";
                string arg1 = "value1";
                string arg2 = "value2";
                string arg3 = "value3";

                Form3 form3 = new Form3(studentsPath, arg1, arg2, arg3);
                form3.ShowDialog();
                form3.Dispose();

                this.Show();
            }

            else
            {
                MessageBox.Show("Sorry, you are not registered.");
            }
        }
        private bool IsUserRegistered(string creditLogPath, string username, string password)
        {
            string[] lines = File.ReadAllLines(creditLogPath);

            foreach (string line in lines)
            {
                string[] fields = line.Split(',');

                string storedUsername = fields[0];
                string storedPassword = fields[1];

                if (username == storedUsername && password == storedPassword)
                {
                    return true; // User is registered
                }
            }

            return false; // User is not registered
        }
        public void DisplayStudentInformation(string username)
        {
            // Existing code...
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 signUpForm = new Form2();
            signUpForm.ShowDialog();
            signUpForm.Close();
            this.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.ariel.ac.il/wp/");
        }
    }
}