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
using System.Xml;
using FinalProject.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FinalProject.Forms
{
    public partial class Form3 : Form
    {
        private List<Student> students;
        private List<User> users; // Add this line

        public Form3(string combinedPath, string arg1, string arg2, string arg3)
        {
            InitializeComponent();
            users = LoadUsersFromCombinedFile(combinedPath); // Update this line
        }

        private void LoadStudentsFromCombinedFile(string filePath)
        {
            students = new List<Student>();

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

                    Student student = new Student(name, password, email, age, id, phoneNumber, lastLogin);
                    students.Add(student);
                }
            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
        }


        private bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath);
            string[] imageExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
            return imageExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        private void LoadLecturerInformation()
        {
            string lecturersPath = "path_to_lecturers_file"; // Replace with the actual path to the lecturers file

            if (File.Exists(lecturersPath))
            {
                // Load and display lecturer information
                string[] lines = File.ReadAllLines(lecturersPath);
                // Add your code to display lecturer information in the form
            }
        }

        private void LoadHeadOfDepartmentInformation()
        {
            string headsOfDepartmentsPath = "path_to_heads_of_departments_file"; // Replace with the actual path to the heads of departments file

            if (File.Exists(headsOfDepartmentsPath))
            {
                // Load and display head of department information
                string[] lines = File.ReadAllLines(headsOfDepartmentsPath);
                // Add your code to display head of department information in the form
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string input = richTextBox1.Text.Trim();

            if (!string.IsNullOrEmpty(input))
            {
                string filePath = "C:\\Users\\guybr\\source\\repos\\FinalProject\\UsersTxt\\Combined.txt";

                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        string[] userInfo = line.Split(',');

                        if (userInfo.Length > 0 && userInfo[0].Equals(input, StringComparison.OrdinalIgnoreCase))
                        {
                            string userName = userInfo[0];
                            string email = userInfo[2];
                            string age = userInfo[3];

                            MessageBox.Show($"Match found!\nName: {userName}\nEmail: {email}\nAge: {age}");
                            return; // Exit the method after finding a match
                        }
                    }

                    // If the loop completes without finding a match
                    MessageBox.Show("No match found.");
                }
                else
                {
                    MessageBox.Show("Combined file does not exist.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a search input.");
            }
        }



        private void button5_Click(object sender, EventArgs e)
        {
            tabControl1 = new TabControl();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // Change Font
            ChangeFonts(this.Controls);
        }

        private void ChangeFonts(Control.ControlCollection controls)
        {
            Font newFont = new Font("Arial", 14, FontStyle.Italic);

            foreach (Control control in controls)
            {
                control.Font = newFont;
                if (control.HasChildren)
                    ChangeFonts(control.Controls);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // change window color by button
            Random random = new Random();
            Color randomColor = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
            this.BackColor = randomColor;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            // Event handler code
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {
            // Event handler code
        }

        private void Form3_Load1(object sender, EventArgs e)
        {
            // Event handler code
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            // Event handler code
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            // Event handler code
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            // Event handler code
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
            // Event handler code
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UploadImage();
        }

        // Function to upload and save image
        private void UploadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Generate a unique filename for the saved image
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imagePath);

                // Create the destination directory if it doesn't exist
                string destinationDirectory = Path.Combine(Application.StartupPath, "Image");
                if (!Directory.Exists(destinationDirectory))
                    Directory.CreateDirectory(destinationDirectory);

                // Construct the full path for the saved image
                string destinationPath = Path.Combine(destinationDirectory, fileName);

                // Save the image to the destination path
                File.Copy(imagePath, destinationPath);

                // Perform further operations with the image, such as displaying it
                // For example, you can assign the image to a PictureBox control:
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Image = Image.FromFile(destinationPath);
            }
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["Date"], ListSortDirection.Descending);
        }


        private void LoadUsers()
        {
            string combinedPath = "C:\\Users\\guybr\\source\\repos\\FinalProject\\UsersTxt\\Combined.txt";
            users = LoadUsersFromCombinedFile(combinedPath);
        }


        private List<User> LoadUsersFromCombinedFile(string filePath)
        {
            List<User> users = new List<User>();

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');

                    if (data.Length >= 8) // Check if the data array has enough elements
                    {
                        string name = data[0];
                        string password = data[1];
                        string email = data[2];
                        int age = int.Parse(data[3]);
                        string id = data[4];
                        string phoneNumber = data[5];
                        DateTime lastLogin = DateTime.Parse(data[6]);

                        Role role;
                        if (Enum.TryParse(data[7], out role)) // Handle parsing the role enum
                        {
                            User user = new User(name, password, email, age, id, phoneNumber, lastLogin, role);
                            users.Add(user);
                        }
                        else
                        {
                            // Handle invalid role value
                            Console.WriteLine($"Invalid role value: {data[7]}");
                        }
                    }
                    else
                    {
                        // Handle insufficient data in the line
                        Console.WriteLine($"Insufficient data: {line}");
                    }
                }
            }

            return users;
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {
            List<string> stringList = new List<string>
                {
                    "Math",
                    "Ui .net",
                    "Python",
                    "Java",
                    "JavaScript"
                };

                richTextBox3.Clear();

                foreach (string str in stringList)
                {
                    richTextBox3.AppendText(str + Environment.NewLine);
                }
            }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\guybr\\source\\repos\\FinalProject\\UsersTxt\\UserInfo.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    string[] userInfo = lines[0].Split(',');

                    if (userInfo.Length >= 1)
                    {
                        string name = userInfo[0]; // First element is the name
                        richTextBox4.Text = $"Hello, {name}";
                    }
                }
            }
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {
            string filePath = "C:\\Users\\guybr\\source\\repos\\FinalProject\\UsersTxt\\UserInfo.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    string[] userInfo = lines[0].Split(',');

                    List<string> stringList = new List<string>
            {
                $"Year of Birth: {userInfo[1]}",
                $"Age: {userInfo[2]}",
                $"Student of: {userInfo[3]}",
                $"GPA Score: {userInfo[4]}"
            };

                    richTextBox2.Clear();

                    foreach (string str in stringList)
                    {
                        richTextBox2.AppendText(str + Environment.NewLine);
                    }
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridView1.Columns["Favorite"].Index)
            {
                DataGridViewCheckBoxCell checkboxCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[e.RowIndex].Cells["Favorite"];
                bool isFavorite = (bool)checkboxCell.Value;

                // Toggle the favorite status
                checkboxCell.Value = !isFavorite;
            }
        }

        private void AddMessage(DateTime date, string importance, string sender, string content, bool isStarred)
        {
            // Add the message directly to the existing columns
            dataGridView1.Rows.Add(date.ToString(), importance, sender, content, isStarred);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Create a BindingSource for the DataGridView
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataGridView1.DataSource;

            // Filter the rows based on the starred status
            bindingSource.Filter = "Favorite = true";

            // Set the filtered data as the new DataSource for the DataGridView
            dataGridView1.DataSource = bindingSource;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns["importance"], ListSortDirection.Descending);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string senderName = "John Doe";
            string content = "Hello, world!";
            DateTime date = DateTime.Now;
            string importance = "High";
            bool isStarred = true;

            AddMessage(date, importance, senderName, content, isStarred);
        }
    }
}
