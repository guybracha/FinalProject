using FinalProject.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newUsername = richTextBox1.Text.Trim();
            string newPassword = richTextBox2.Text.Trim();

            // Validate if the input is not empty
            if (string.IsNullOrEmpty(newUsername) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            string filePath = "C:\\Users\\guybr\\source\\repos\\FinalProject\\UsersTxt\\Combined.txt";

            // Format the new user's information as a line
            string userInfo = $"{newUsername},{newPassword},john.doe@example.com,30,123456,555-1234,2021-09-01";

            // Add the new user's information as a new line in the text file
            using (StreamWriter writer = File.AppendText(filePath))
            {
                writer.WriteLine(userInfo);
            }

            MessageBox.Show("New user registered successfully.");

            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }





        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
