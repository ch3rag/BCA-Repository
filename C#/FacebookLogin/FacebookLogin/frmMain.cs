using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using MyControls;
using System.Text.RegularExpressions;
using Ciphers;

namespace FacebookLogin {
    public partial class frmMain : Form {
        string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Environment.CurrentDirectory + "\\Database\\Facebook.accdb";
        OleDbCommand command;
        OleDbConnection connection;
        Regex forName = new Regex(@"^[A-Za-z]+$");
        Regex forPassword = new Regex(@"^(?=.*\d)(?=.*[A-Za-z])(?=.*[@#%*_,\.]).{8,}$");
        Regex forPhone = new Regex(@"^(\+91|0)?\d{10}$");
        Regex forEmail = new Regex(@"^[A-Za-z]([_.-]?[A-Za-z0-9]+?)*\@[a-zA-Z0-9]+(\.[A-Za-z]+){1,2}$");
        BlockCipher blockCipher = new BlockCipher();
        
        public frmMain() {
            InitializeComponent();
        }

        TextBox txtName, txtSurName, txtMobile, txtPassword;
        DateTimePicker dobPicker;
        RadioButton female, male;
        TextBox txtLoginMobile, txtLoginPassword;

        private void frmMain_Load(object sender, EventArgs e) {
            Init();
        }

        private void BtnSignUp_Click(object sender, EventArgs e) {
            string firstName = txtName.Text;
            string surName = txtSurName.Text;
            string mobileOrEmail = txtMobile.Text;
            string password = txtPassword.Text;
            string gender;
            if (male.Checked) gender = "Male";
            else gender = "Female";
            DateTime dob = dobPicker.Value;
            // TODO: Validation
            if (ValidateData(firstName, surName, mobileOrEmail, password, gender, dob)) {
                InsertData(firstName, surName, mobileOrEmail, password, gender, dob);
            }
        }

        private bool CheckIfExists(string mobileOrEmail) {
            string query = "SELECT * FROM UserData WHERE MOBILE = '" + mobileOrEmail + "';";
            connection = new OleDbConnection(connectionString);
            connection.Open();
            command = new OleDbCommand(query, connection);
            bool hasRows = command.ExecuteReader().HasRows;
            connection.Close();
            command.Dispose();
            return hasRows;
        }

        private bool ValidateData(string firstName, string surName, string mobileOrEmail, string password, string gender, DateTime dob) {
            bool valid = true;
            string errorString = "Invalid";
            if (firstName == "First Name" || !forName.Match(firstName).Success) {
                valid = false;
                errorString +=" Name,";
            }
            if (surName == "Surname" || !forName.Match(surName).Success) {
                valid = false;
                errorString += " Surname,";
            }
            if (mobileOrEmail == "Mobile Or Email" || !(forEmail.Match(mobileOrEmail).Success || forPhone.Match(mobileOrEmail).Success)) {
                valid = false;
                errorString += " Mobile Or Email,";
            }
            if(password == "New Password" || !(forPassword.Match(password).Success)) {
                valid = false;
                errorString += " Password,";
            }
            if(DateTime.Today.Year - dob.Year < 18) {
                valid = false;
                errorString += " Date Of Birth,";
            }
            errorString = errorString.Substring(0, errorString.Length - 1) + ".";
            if (!valid) MessageBox.Show(errorString);

            return valid;
        }
        
        private byte[] GenerateKey(params string[] words) {
            byte[] key = new byte[words.Length];
            for (int i = 0; i < words.Length; i++) {
                byte byt = (byte)(words[i][0] - 65);
                key[i] = byt;
            }
            return key;
        }
        private void InsertData(string firstName, string surName, string mobileOrEmail, string password, string gender, DateTime dob) {
            if(CheckIfExists(mobileOrEmail)) {
                MessageBox.Show("Mobile/Email Already Registered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try {
                connection = new OleDbConnection(connectionString);
                password = blockCipher.Encrypt(password, GenerateKey(firstName, surName, mobileOrEmail));
                string query = String.Format("INSERT INTO UserData (FirstName, SurName, Mobile, [Password], Gender, DateOfBirth) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5} 00:00:00');", firstName, surName, mobileOrEmail, password, gender, dob.ToString("yyyy-MM-dd"));
                connection.Open();
                using (command = new OleDbCommand(query, connection)) {
                    int rows = command.ExecuteNonQuery();
                    if(rows > 0) {
                        MessageBox.Show("Sign Up Sucessful.", "Facebook", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("Sign Up Failed.", "Facebook", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    } 
                } 
            } catch(Exception ex) {
                MessageBox.Show(ex.Message, "Facebook", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally {
                connection.Close();
            }
        }

        private void Init() {
            Text = "Facebook - Login & SignUp";
            MyTableLayoutPanel mainPanel = new MyTableLayoutPanel(2, 1, DockStyle.Fill);
            MyTableLayoutPanel topPanel = new MyTableLayoutPanel(1, 3, DockStyle.Fill, new Padding(10), Color.DarkBlue) {
                AutoSize = true
            };

            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            topPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            TableLayoutPanel loginContainer = new TableLayoutPanel() {
                RowCount = 2,
                ColumnCount = 3,
                Dock = DockStyle.Right,
                AutoSize = true
            };
            
            loginContainer.Controls.Add(new Label() {
                Text = "Email Or Phone",
                ForeColor = Color.White
            }, 0, 0);

            txtLoginMobile = new TextBox() {};

            loginContainer.Controls.Add(txtLoginMobile, 0, 1);

            loginContainer.Controls.Add(new Label() {
                Text = "Password",
                ForeColor = Color.White
            }, 1, 0);

            txtLoginPassword = new TextBox() { PasswordChar = '*' };

            loginContainer.Controls.Add(txtLoginPassword, 1, 1);

            Button btnLogin = new Button() {
                Text = "Log In",
                ForeColor = Color.White,
            };
            btnLogin.Click += BtnLogin_Click;

            loginContainer.Controls.Add(btnLogin, 2, 1);

            topPanel.Controls.Add(loginContainer, 2, 0);
            topPanel.Controls.Add(new Label() {
                Text = "facebook",
                Font = new Font("Helvetica", 30, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true
            }, 1, 0);

            MyTableLayoutPanel bottomPanel = new MyTableLayoutPanel(1, 2, DockStyle.Fill);
            bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            bottomPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            bottomPanel.SetGradientBackground(Color.White, System.Drawing.Color.FromArgb(211, 216, 232), 90f);

            Panel bottomLeftPanel = new Panel() {
                Dock = DockStyle.Fill,
                BackgroundImage = Image.FromFile(Environment.CurrentDirectory + "\\Images\\bg.png"),
                BackgroundImageLayout = ImageLayout.Zoom
            };

            MyTableLayoutPanel bottomRightPanel = new MyTableLayoutPanel(10, 1, DockStyle.Fill);
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            bottomRightPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            bottomRightPanel.AutoSize = true;

            bottomRightPanel.Controls.Add(new Label() {
                Text = "Create an account",
                Font = new Font("Helvetica", 20, FontStyle.Bold),
                AutoSize = true
            }, 0, 0);

            bottomRightPanel.Controls.Add(new Label() {
                Text = "It's quick and easy.",
                Font = new Font("Helvetica", 10),
                AutoSize = true
            }, 0, 1);

            txtName = new TextBox() {
                Text = "First Name",
                Dock = DockStyle.Fill,
                Font = new Font("Helvetica", 15),
                ForeColor = Color.Gray
            };

            txtSurName = new TextBox() {
                Text = "Surname",
                Dock = DockStyle.Fill,
                Font = new Font("Helvetica", 15),
                ForeColor = Color.Gray
            };

            txtMobile = new TextBox() {
                Text = "Mobile Or Email",
                Dock = DockStyle.Fill,
                Font = new Font("Helvetica", 15),
                ForeColor = Color.Gray
            };

            txtPassword = new TextBox() {
                Text = "New Password",
                Dock = DockStyle.Fill,
                Font = new Font("Helvetica", 15),
                ForeColor = Color.Gray
            };

            txtName.Enter += (s, args) => txtName.Text = txtName.Text == "First Name" ? "" : txtName.Text;
            txtName.Leave += (s, args) => txtName.Text = txtName.Text == "" ? "First Name" : txtName.Text;
            txtSurName.Enter += (s, args) => txtSurName.Text = txtSurName.Text == "Surname" ? "" : txtSurName.Text;
            txtSurName.Leave += (s, args) => txtSurName.Text = txtSurName.Text == "" ? "Surname" : txtSurName.Text;
            txtMobile.Enter += (s, args) => txtMobile.Text = txtMobile.Text == "Mobile Or Email" ? "" : txtMobile.Text;
            txtMobile.Leave += (s, args) => txtMobile.Text = txtMobile.Text == "" ? "Mobile Or Email" : txtMobile.Text;
            txtPassword.Enter += (s, args) => {
                if (txtPassword.Text == "New Password") {
                    txtPassword.Text = "";
                    txtPassword.PasswordChar = '*';
                }
            };
            txtPassword.Leave += (s, args) => {
                if (txtPassword.Text == "") {
                    txtPassword.Text = "New Password";
                    txtPassword.PasswordChar = '\0';
                }
            };

            MyTableLayoutPanel namePanel = new MyTableLayoutPanel(1, 2, DockStyle.Fill, new Padding(0, 5, 0, 5));
            namePanel.AutoSize = true;
            namePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            namePanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            namePanel.Controls.Add(txtName, 0, 0);
            namePanel.Controls.Add(txtSurName, 1, 0);

            bottomRightPanel.Controls.Add(namePanel, 0, 2);
            bottomRightPanel.Controls.Add(txtMobile, 0, 3);
            bottomRightPanel.Controls.Add(txtPassword, 0, 4);

            GroupBox birthdayBox = new GroupBox() {
                Text = "Birthday",
                Dock = DockStyle.Fill,
                AutoSize = true,
                Padding = new Padding(10)
            };

            dobPicker = new DateTimePicker() {
                Dock = DockStyle.Top
            };

            MyTableLayoutPanel radioButtonContainer = new MyTableLayoutPanel(1, 2, DockStyle.Fill);

            radioButtonContainer.AutoSize = true;
            radioButtonContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            radioButtonContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            male = new RadioButton() {
                Text = "Male",
                Checked = true
            };
            female = new RadioButton() {
                Text = "Female"
            };

            radioButtonContainer.Controls.Add(male, 0, 0);
            radioButtonContainer.Controls.Add(female, 1, 0);

            birthdayBox.Controls.Add(dobPicker);

            bottomRightPanel.Controls.Add(birthdayBox, 0, 5);
            bottomRightPanel.Controls.Add(radioButtonContainer, 0, 6);

            bottomRightPanel.Controls.Add(new Label() {
                Text = "By clicking Sign Up, you agree to our Terms, Data Policy and\nCookie Policy. You may receive SMS notifications from us and\ncan opt out at any time.",
                Font = new Font("Helvetica", 8),
                AutoSize = true
            }, 0, 7);

            Button btnSignUp = new Button() {
                Text = "Sign Up",
                Font = new Font("Helvetica", 12, FontStyle.Bold),
                AutoSize = true,
                ForeColor = Color.White,
                BackColor = System.Drawing.Color.FromArgb(95, 155, 76),
                Padding = new Padding(15, 10, 15, 10)
            };

            bottomRightPanel.Controls.Add(btnSignUp, 0, 8);
            bottomPanel.Controls.Add(bottomLeftPanel, 0, 0);
            bottomPanel.Controls.Add(bottomRightPanel, 1, 0);
            mainPanel.Controls.Add(topPanel, 0, 0);
            mainPanel.Controls.Add(bottomPanel, 0, 1);

            this.Controls.Add(mainPanel);

            btnSignUp.Click += BtnSignUp_Click;

        }

        private void BtnLogin_Click(object sender, EventArgs e) {
            string emailOrMobile = txtLoginMobile.Text;
            string password = txtLoginPassword.Text;
            if(!(forEmail.Match(emailOrMobile).Success || forPhone.Match(emailOrMobile).Success)) {
                MessageBox.Show("Invalid Username Or Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                connection = new OleDbConnection(connectionString);
                string query = "SELECT * FROM UserData WHERE MOBILE = '" + emailOrMobile + "';";
                connection.Open();
                command = new OleDbCommand(query, connection);
                OleDbDataReader reader = command.ExecuteReader();
                if(reader.HasRows) {
                    reader.Read();
                    string firstName = reader[1].ToString();
                    string surName = reader[2].ToString();
                    string mobileOrEmail = reader[3].ToString();
                    byte[] key = GenerateKey(firstName, surName, mobileOrEmail);
                    string dbPassword = blockCipher.Decrypt(reader[4].ToString(), key);
                    if(password == dbPassword) {
                        MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else {
                        MessageBox.Show("Invalid Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } else {
                    MessageBox.Show("Invalid Username.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                connection.Close();
                command.Dispose();
            }
        }
    }
}
