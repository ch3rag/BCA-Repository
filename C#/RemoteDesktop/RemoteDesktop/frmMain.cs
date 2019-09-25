using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSTSCLib;
using AxMSTSCLib;

namespace RemoteDesktop {
    public partial class frmMain : Form {
        TextBox txtServerName = new TextBox() { Text = "109.168.97.222" };
            TextBox txtPassword = new TextBox() { Text = "D3m02014*Test",  PasswordChar = '*' };
            TextBox txtUsername = new TextBox() { Text = "demo2" };
        AxMSTSCLib.AxMsTscAxNotSafeForScripting rpdConsole = new AxMSTSCLib.AxMsTscAxNotSafeForScripting();
        public frmMain() {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e) {
            this.Text = "Remote Desktop Client";
            Panel mainPanel = new Panel() {
                Dock = DockStyle.Fill,
            };

            TableLayoutPanel mainContainer = new TableLayoutPanel() {
                RowCount = 2,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
            };
            
            FlowLayoutPanel menuBar = new FlowLayoutPanel() {
                FlowDirection = FlowDirection.LeftToRight,
                BackColor = Color.AliceBlue,
                Padding = new Padding(10),
                Dock = DockStyle.Top,
                AutoSize = true
            };

            rpdConsole.Dock = DockStyle.Fill;


            Button btnConnect = new Button() { Text = "Connect" };
            Button btnDisconnect = new Button() { Text = "Disconnect" };

            btnConnect.Click += BtnConnect_Click;
            btnDisconnect.Click += BtnDisconnect_Click;
            menuBar.Controls.Add(new Label() {
                Text = "Server Name: " ,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                Padding  = new Padding(0, 5, 0, 5)
            });

            menuBar.Controls.Add(txtServerName);

            menuBar.Controls.Add(new Label() {
                Text = "UserName: ",
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                Padding = new Padding(0, 5, 0, 5)
            });
            menuBar.Controls.Add(txtUsername);

            menuBar.Controls.Add(new Label() {
                Text = "Password: ",
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = true,
                Padding = new Padding(0, 5, 0, 5)
            });

            menuBar.Controls.Add(txtPassword);

            menuBar.Controls.Add(btnConnect);
            menuBar.Controls.Add(btnDisconnect);

            mainContainer.Controls.Add(menuBar, 0, 0);
            mainContainer.Controls.Add(rpdConsole, 0, 1);
            mainPanel.Controls.Add(mainContainer);
            this.Controls.Add(mainPanel);
        }

        private void BtnDisconnect_Click(object sender, EventArgs e) {
            try {
                if(rpdConsole.Connected.ToString() == "1") {
                    rpdConsole.Disconnect();
                }
            } catch(Exception) {
                MessageBox.Show(String.Format("Error while Disonnecting from {0}/{1}", txtServerName.Text, txtUsername.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnConnect_Click(object sender, EventArgs e) {
            try {
                rpdConsole.Server = txtServerName.Text;
                rpdConsole.UserName = txtUsername.Text;
                IMsTscNonScriptable secured = (IMsTscNonScriptable)rpdConsole.GetOcx();
                secured.ClearTextPassword = txtPassword.Text;
                rpdConsole.Connect();
            } catch(Exception) {
                MessageBox.Show(String.Format("Error while Connecting to {0}/{1}", txtServerName.Text, txtUsername.Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
